using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

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
        }

        private void OnCreated(object sender, FileSystemEventArgs e) {
            Console.WriteLine(string.Format("[{0}] {1}:{2}", DateTime.Now.ToString(), e.ChangeType.ToString(), e.FullPath));
        }

        private void OnChanged(object sender, FileSystemEventArgs e) {
            Console.WriteLine(string.Format("[{0}] {1}:{2}", DateTime.Now.ToString(), e.ChangeType.ToString(), e.FullPath));
        }

        private void OnDeleted(object sender, FileSystemEventArgs e) {
            Console.WriteLine(string.Format("[{0}] {1}:{2}", DateTime.Now.ToString(), e.ChangeType.ToString(), e.FullPath));
        }

        private void OnRenamed(object sender, RenamedEventArgs e) {
            Console.WriteLine(string.Format("[{0}] {1}:{2}", DateTime.Now.ToString(), e.ChangeType.ToString(), e.FullPath));
        }
    }
}
