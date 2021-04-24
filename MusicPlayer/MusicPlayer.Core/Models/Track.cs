using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Models
{
    public class Track
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public TimeSpan PlayTime { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public Image Image { get; set; }
    }
}
