using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.PulseAudio.Tracks.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.WPF.Services.OSServices
{
    public class FolderScanner : IFolderScanner
    {
        private CatalogScaner catalogScaner = new CatalogScaner();

        public IEnumerable<string> ScanFolder(string folder)
        {
            catalogScaner.ScanFolder(folder);
            return catalogScaner.ScannedFiles;
        }

        public IEnumerable<string> ScanFolders(List<string> folders)
        {
            folders.ForEach(x => catalogScaner.ScanFolder(x));
            return catalogScaner.ScannedFiles;
        }
    }
}
