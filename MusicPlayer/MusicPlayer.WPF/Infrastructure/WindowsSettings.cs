using MusicPlayer.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.WPF.Infrastructure
{
    public class WindowsSettings : AppSettings
    {
        public WindowsSettings()
        {
            DefaultScanningFolder = "A:\\Music";
            DefaultPlaylistPath = Path.Combine(Directory.GetCurrentDirectory(), "playlists");

            if(!Directory.Exists(DefaultPlaylistPath))
                Directory.CreateDirectory(DefaultPlaylistPath);
        }
    }
}
