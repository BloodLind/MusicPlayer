using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class MusicPlayer
    {
        public List<Track> Tracks { get; set; }
        public List<Playlist> Playlist { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Album> Albums { get; set; }
        public List<Track> Queue { get; set; }
    }
}
