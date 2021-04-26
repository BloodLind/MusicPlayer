using CSCore.Codecs;
using MusicPlayer.Core.Infrastructure.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class CatalogScaner : ICatalogScaner
    {
        public IEnumerable<string> ScannedFiles { get; set; }
        string[] extensions = CodecFactory.Instance.GetSupportedFileExtensions();

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

            foreach (string extension in extensions)
            {
                tmpList.AddRange(Directory.GetFiles(path, $"*.{extension}", SearchOption.AllDirectories));
            }


        }
    }
}
