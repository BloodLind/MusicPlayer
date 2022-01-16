using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure.ViewModels;
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
    public class RootViewModel : MusicViewModel
    {
       

        public RootViewModel(ILoggerFactory mvxLog, IMvxNavigationService mvxNavigationService)
            : base(mvxLog, mvxNavigationService)
        {
            InitializeCommands();
            ShowHome = new MvxCommand(() => this.NavigationService.Navigate<HomeViewModel>());
        }

        public override void ViewCreated()
        {
            base.ViewCreated();
        }
        private void InitializeCommands()
        {
            //ShowHome = new MvxCommand(() => ContentPage = CoreApp.Navigation.HomeView);

        }

        #region Properties
  
        #endregion

        #region Commands
        public IMvxCommand ShowMenu { get; private set; }
        public IMvxCommand ShowHome { get; private set; }
        public IMvxCommand ShowPlaylists { get; private set; }
        #endregion
    }
}
