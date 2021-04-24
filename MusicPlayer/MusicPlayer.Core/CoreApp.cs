
using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Models;
using MusicPlayer.Core.ViewModels;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core
{
    public class CoreApp : MvxApplication
    {
       
        public override void Initialize()
        {
            this.RegisterAppStart<NowPlayingViewModel>();
        }

        public static List<Track> Tracks { get; set; } = new List<Track>();
        public static List<Playlist> Playlists { get; set; } = new List<Playlist>();
        public static List<Artist> Artists { get; set; } = new List<Artist>();
        public static List<Album> Albums { get; set; } = new List<Album>();
        public static IMusicPlayer Player { get; set; }

    }
}
