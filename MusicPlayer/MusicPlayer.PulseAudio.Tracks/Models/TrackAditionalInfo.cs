using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Models
{
    public class TrackAditionalInfo
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Singer { get; set; }
        public string Codec { get; set; }
        public string Time { get; set; }
        public string Frequency { get; set; }
        public string Bitrate { get; set; }
        public string Bandwith { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int Disk { get; set; }
        public int TrackNumber { get; set; }
    }
}
