using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure.ViewModels;
using MusicPlayer.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
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
        private bool isMenuExpanded;
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
            ChangeMenuStatement = new MvxCommand(() => IsMenuExpanded = !IsMenuExpanded);
        }

        #region Properties
            public bool IsMenuExpanded { get => isMenuExpanded; set { isMenuExpanded = value; RaisePropertyChanged(() => IsMenuExpanded); } }
        #endregion


        #region Commands
        public IMvxCommand TrackInfoCommand { get; private set; }
        public IMvxCommand ShowMenu { get; private set; }
        public IMvxCommand ShowHome { get; private set; }
        public IMvxCommand ShowPlaylists { get; private set; }
        public IMvxCommand ChangeMenuStatement { get; private set; }
        #endregion
    }
}
