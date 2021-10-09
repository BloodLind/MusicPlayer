using MusicPlayer.Core.Infrastructure.ViewModels;
using MusicPlayer.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MusicPlayer.Core.ViewModels
{

    public class NowPlayingViewModel : MvxViewModel
    {
        public NowPlayingViewModel()
        {
            InitCommands();
        }

        private void InitCommands()
        {
            ReturnCommand = new MvxCommand(() =>
            {
                CoreApp.Navigation.MvxNavigationService.Close(this);
            });
            PlayPauseCommand = new MvxCommand(() =>
            {
            });
        }
     

        #region Commands
        public IMvxCommand ReturnCommand { get; private set; }
        public IMvxCommand PlayPauseCommand { get; private set; }
        #endregion

    }
}
