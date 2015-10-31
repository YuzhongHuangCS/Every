using System;
using System.IO;
using System.Threading;
using SharpSvn;

namespace Every {
    class EventManager {
        private string path;
        private string filename;
        private string directory;
        private string svnDirectory;
        private SvnClient client;
        private SvnRepositoryClient repo;
        private FileSystemWatcher watcher;

        public EventManager(string path) {
            this.path = path;
            filename = Path.GetFileName(path);
            directory = Path.GetDirectoryName(path);
            svnDirectory = Path.Combine(directory, "svn");
            client = new SvnClient();
            repo = new SvnRepositoryClient();
            
            if (!Directory.Exists(svnDirectory)) {           
                repo.CreateRepository(svnDirectory);
                client.CheckOut(new SvnUriTarget(svnDirectory), directory);
                client.Add(path);
                client.Commit(directory, new SvnCommitArgs { LogMessage = "Initialize repository" });
            } else {
                client.CheckOut(new SvnUriTarget(svnDirectory), directory, new SvnCheckOutArgs { AllowObstructions = true });
                client.Resolved(directory);
                //client.Add(path);
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
        }

        private void OnCreated(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
        }

        private void OnChanged(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
            Commit();
        }

        private void OnDeleted(object sender, FileSystemEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}", DateTime.Now, e.ChangeType, e.FullPath);
            Commit();
        }

        private void OnRenamed(object sender, RenamedEventArgs e) {
            Console.WriteLine("[{0}] {1}:{2}:{3}", DateTime.Now, e.ChangeType, e.FullPath, e.OldFullPath);
            Commit();
        }

        private string TimeStringNow {
            get {
                DateTime now = DateTime.Now;
                return string.Format("{0}_{1}_{2}_{3}_{4}_{5}_{6}", now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, now.Millisecond);
            }
        }

        private void Commit() {
            Console.WriteLine("Before Commit");
            client.Commit(directory, new SvnCommitArgs { LogMessage = "Automatic commit" });
            Console.WriteLine("After Commit, Before Cleanup");
            client.CleanUp(directory);
            Console.WriteLine("After Cleanup");
        }

        ~EventManager() {
            Console.WriteLine("I am called");
            try {
                Directory.Delete(Path.Combine(directory, ".svn"), true);
            } catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            
        }
    }
}
