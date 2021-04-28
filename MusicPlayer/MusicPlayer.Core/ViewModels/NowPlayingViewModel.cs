using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels
{

    public class NowPlayingViewModel : MvxViewModel
    {
        public NowPlayingViewModel()
        {
            
            InitCommands();
        }

        public void InitCommands()
        {
            ReturnCommand = new MvxCommand( () =>
            {
                 CoreApp.Navigation.MvxNavigationService.Navigate(CoreApp.Navigation.HomeView);
            });
        }

        public IMvxCommand ReturnCommand { get; set; }
    }
}
