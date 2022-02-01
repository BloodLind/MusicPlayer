using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.PulseAudio.Base.Models
{
    
    public class Track
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public double PlayTime { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
    }
}
