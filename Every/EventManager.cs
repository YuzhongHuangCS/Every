using System;
using System.Diagnostics;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using DeltaCompressionDotNet;
using DeltaCompressionDotNet.MsDelta;

namespace Every {
    class EventManager {
        private string path;
        private string filename;
        private string directory;
        private string workDirectory;
        private string patchDirectory;
        private string refFilename;
        private string refPath;
        private FileSystemWatcher watcher;
        private MsDeltaCompression deltaCompression;
        private BlockingCollection<string> queue;
        private Thread worker;

        public EventManager(string path) {
            this.path = path;
            filename = Path.GetFileName(path);
            directory = Path.GetDirectoryName(path);
            workDirectory = Path.Combine(directory, "_every");
            patchDirectory = Path.Combine(workDirectory, "patch");
            refFilename = filename + ".ref";
            refPath = Path.Combine(workDirectory, refFilename);

            if (!Directory.Exists(workDirectory)) {
                Directory.CreateDirectory(workDirectory);
            }
            if (!Directory.Exists(patchDirectory)) {
                Directory.CreateDirectory(patchDirectory);
            }
            if (!File.Exists(refPath)) {
                File.Copy(path, refPath);
            }

            watcher = new FileSystemWatcher();
            watcher.Filter = filename;
            watcher.Path = directory;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;

            deltaCompression = new MsDeltaCompression();
            queue = new BlockingCollection<string>();
            worker = new Thread(new ThreadStart(ProcessQueue));
            worker.IsBackground = true;
            worker.Start();
        }

        private void OnCreated(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
        }

        private void OnChanged(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
            Enqueue();
        }

        private void OnDeleted(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
        }

        private void OnRenamed(object sender, RenamedEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}:{3}", DateTime.Now, e.ChangeType, e.FullPath, e.OldFullPath);
            Enqueue();
        }

        private string TimeStringNow {
            get {
                DateTime now = DateTime.Now;
                return string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
            }
        }

        private void Enqueue() {
            string thisPath = string.Format("{0}_{1}.this", Path.Combine(workDirectory, filename), TimeStringNow);
            File.Copy(path, thisPath, true);
            queue.Add(thisPath);
        }

        private void ProcessQueue() {
            while (true) {
                string thisPath = queue.Take();
                string deltaPath = Path.Combine(patchDirectory, string.Format("{0}_{1}.delta", filename, TimeStringNow));

                //using (FileStream fs = File.Open(thisPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)) {
                //    Console.WriteLine(fs.Length);
                //}
                Stopwatch timer = new Stopwatch();
                timer.Start();
                deltaCompression.CreateDelta(thisPath, refPath, deltaPath);
                timer.Stop();
                Console.WriteLine("Time Used: {0}s", timer.Elapsed);
                Console.WriteLine("{0}, {1}, {2}", thisPath, refPath, deltaPath);
                Console.WriteLine("About to copy");
                if (File.Exists(refPath)) {
                    File.Delete(refPath);
                }
                File.Move(thisPath, refPath);
            }
        }
    }
}
