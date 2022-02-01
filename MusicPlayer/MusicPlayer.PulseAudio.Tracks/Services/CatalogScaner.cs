using MusicPlayer.PulseAudio.Tracks.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Services
{
    public class CatalogScaner : ICatalogScaner
    {
        private string[] extensions = { "*.mp3", "*.wav", "*.wma", "*.aac", "*.m4a", "*.flac" };
        
        public IEnumerable<string> ScannedFiles { get; set; }

        public void RemoveFolderFromScan(string path)
        {
            throw new NotImplementedException();
        }

        public void ScanFolder(string path)
        {
            if(ScannedFiles == null)
            {
                ScannedFiles = new List<string>();
            }

            List<string> tmpList = (List<string>)ScannedFiles;

            var r = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories).ToList();
            foreach (string extension in extensions)
            {
                tmpList.AddRange(Directory.GetFiles(path, extension, SearchOption.AllDirectories));
            }


        }
    }
}
