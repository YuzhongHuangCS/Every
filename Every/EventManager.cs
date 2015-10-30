using System;
using System.Diagnostics;
using System.IO;

namespace Every {
    class EventManager {
        private FileSystemWatcher watcher;

        public EventManager(string path) {
            watcher = new FileSystemWatcher();
            watcher.Filter = Path.GetFileName(path);
            watcher.Path = Path.GetDirectoryName(path);
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Created += new FileSystemEventHandler(OnCreated);
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnDeleted);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.EnableRaisingEvents = true;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C git status";
            startInfo.WorkingDirectory = Path.GetDirectoryName(path);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;

            using (Process process = Process.Start(startInfo)) {
                Console.WriteLine(process.StandardOutput.ReadToEnd());
                Console.WriteLine(process.ExitCode);
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
        }

        private void OnChanged(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
        }

        private void OnDeleted(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
        }

        private void OnRenamed(object sender, RenamedEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
        }
    }
}
