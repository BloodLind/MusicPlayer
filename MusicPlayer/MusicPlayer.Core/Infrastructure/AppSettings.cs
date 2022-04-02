using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure
{
    public abstract class AppSettings
    {
        public string DefaultScanningFolder { get; set; }
    }
}
