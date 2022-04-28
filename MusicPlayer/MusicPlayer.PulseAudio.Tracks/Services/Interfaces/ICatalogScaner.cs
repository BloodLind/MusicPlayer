using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Services.Interfaces
{
    public interface ICatalogScaner
    {
        void ScanFolder(string path);
        IEnumerable<string> ScannedFiles { get; set; }
    }
}
