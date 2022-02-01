using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure.ViewModels;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels
{
    public class RootViewModel : MusicViewModel, IMenuViewModel
    {
        #region Fields
        #endregion

        public RootViewModel(ILoggerFactory mvxLog, IMvxNavigationService mvxNavigationService)
            : base(mvxLog, mvxNavigationService)
        {
            InitializeCommands();
            ShowHome = new MvxCommand(() => this.NavigationService.Navigate<HomeViewModel>());
        }

        private void InitializeCommands()
        {
            ShowHome = new MvxCommand(() => NavigationService.Navigate(CoreApp.Navigation.HomeView));
            TrackInfoCommand = new MvxCommand(() => NavigationService.Navigate<NowPlayingViewModel, Track>(SelectedTrack));

        }

        #region Properties

        #endregion


        #region Commands
        public IMvxCommand TrackInfoCommand { get; private set; }
        public IMvxCommand ShowMenu { get; private set; }
        public IMvxCommand ShowHome { get; private set; }
        public IMvxCommand ShowPlaylists { get; private set; }
        #endregion
    }
}
