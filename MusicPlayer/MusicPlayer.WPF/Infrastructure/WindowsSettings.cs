using MusicPlayer.Core.Infrastructure;
using System;
using System.Collections.Generic;
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
        }
    }
}
