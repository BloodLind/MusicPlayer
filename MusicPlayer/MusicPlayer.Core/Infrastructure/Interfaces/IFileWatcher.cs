using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface IFileWatcher
    {
        event Action<string> FolderFileCreated;
        event Action<string> FolderFileRemoved;
        event Action<string> FolderFileChanged;
        void RemoveWathcingFolder(string path);
        void AddFolderToWatch(string path);
        void ClearList();
        IEnumerable<string> GetWatchingFolders();
    }
}
