using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface ICatalogScaner
    {
        void ScanFolder(string path);
        void RemoveFolderFromScan(string path);
        IEnumerable<string> ScannedFiles { get; set; }
    }
}
