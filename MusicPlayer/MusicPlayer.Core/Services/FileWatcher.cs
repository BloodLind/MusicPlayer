using MusicPlayer.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class FileWatcher : IFileWatcher
    {
        private List<string> trackingFolders;
        private List<FileSystemWatcher> watchers;

        private FileSystemWatcher GetWatcher(string path) 
        {
            var watcher = new FileSystemWatcher(path);
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Changed += Watcher_Changed;
            watcher.NotifyFilter = NotifyFilters.Attributes
                             | NotifyFilters.CreationTime
                             | NotifyFilters.DirectoryName
                             | NotifyFilters.FileName
                             | NotifyFilters.LastWrite
                             | NotifyFilters.Security
                             | NotifyFilters.Size;
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
            return watcher;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
                return;

            FolderFileChanged?.Invoke(e.FullPath);
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            FolderFileRemoved?.Invoke(e.FullPath);
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            FolderFileCreated?.Invoke(e.FullPath);
        }

        private void InitWatcher()
        {
            this.watchers = new ();
            watchers.AddRange(trackingFolders.Select(x => GetWatcher(x)));
        }

       

        public event Action<string> FolderFileCreated;
        public event Action<string> FolderFileRemoved;
        public event Action<string> FolderFileChanged;

        public FileWatcher(List<string> folders) 
        { 
            this.trackingFolders = folders;
            InitWatcher();
        }


        public FileWatcher(string folder)
        {
            this.trackingFolders = new() { folder };
            InitWatcher();
        }
        public FileWatcher() 
        {
            this.trackingFolders = new();
            this.watchers = new();
        }
        public void AddFolderToWatch(string path) 
        {
            trackingFolders.Add(path);
            watchers.Add(GetWatcher(path));
        }
        public IEnumerable<string> GetWatchingFolders() => trackingFolders.ToList();

        public void RemoveWathcingFolder(string path)
        {
            trackingFolders.Remove(path);
            watchers.Remove(watchers.First(x => x.Path == path));
        }

        public void ClearList()
        {
            trackingFolders.Clear();
            watchers.ForEach(x => x.Changed -= Watcher_Changed);
            watchers.Clear();
        }
    }
}
