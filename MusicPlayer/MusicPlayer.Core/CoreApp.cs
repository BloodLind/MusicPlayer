

using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Models;
using MusicPlayer.Core.ViewModels;
using MvvmCross;
using MvvmCross.Navigation;
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

        public CoreApp()
        {
            
        }

        public override void Initialize()
        {

            this.RegisterCustomAppStart<CoreAppStart>();
            
        }

        public static NavigationPresenter Navigation { get; set; }
        public static IMusicPlayer Player { get; set; }

        public static void InitializatePlayer(IEnumerable<Track> tracks) => Player = new Services.MusicPlayer(tracks);
    }
}
