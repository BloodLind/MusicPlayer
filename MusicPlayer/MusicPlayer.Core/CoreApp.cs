

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
using System.Timers;

namespace MusicPlayer.Core
{
    public class CoreApp : MvxApplication
    {
        private static bool isScanned = false;
        

        public override void Initialize()
        {

            this.RegisterCustomAppStart<CoreAppStart>();
            
        }
        
        static CoreApp()
        {
            WorkTimer.Elapsed += WorkTimer_Elapsed;
            WorkTimer.Start();
        }

        private static void WorkTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimerElapsed?.Invoke();
        }
        public static Timer WorkTimer { get; } = new Timer(1000);
        public static NavigationPresenter Navigation { get; set; }
        public static IMusicPlayer Player { get; private set; }
        public static bool IsScaned
        {
            get => isScanned;
        }
    
        public static void SetScanned()
        {
            isScanned = true;
        }
        public static void InitializatePlayer(IEnumerable<Track> tracks) 
        {
            if(Player == null)
                Player = new Services.MusicPlayer(tracks);
         }

        public static event Action TimerElapsed;
    }
}
