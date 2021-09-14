using MusicPlayer.Core.Infrastructure.ViewModels;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels
{
    public class MainViewModel : MusicViewModel
    {
        public MainViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ShowHome = new MvxCommand(() => CoreApp.Navigation.MvxNavigationService.Navigate(CoreApp.Navigation.HomeView));

        }

        #region Commands
        public IMvxCommand ShowMenu { get; private set; }
        public IMvxCommand ShowHome { get; private set; }
        public IMvxCommand ShowPlaylists { get; private set; }
        #endregion
    }
}
