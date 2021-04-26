using MusicPlayer.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Models
{
    public class Playlist : ITrackContainer
    {
        public string Name { get; set; }
        public List<Track> Tracks {get; set;}
        public TimeSpan PlayTime { get; set; }
        public int TracksCount { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
