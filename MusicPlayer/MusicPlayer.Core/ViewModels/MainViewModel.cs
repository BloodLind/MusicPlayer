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
    public class MainViewModel : MvxNavigationViewModel
    {
        private IMvxViewModel menuPage;
        private HomeViewModel contentPage;

        public MainViewModel(IMvxLogProvider mvxLog, IMvxNavigationService mvxNavigationService)
            : base(mvxLog, mvxNavigationService)
        {
            InitializeCommands();
            contentPage = new HomeViewModel(mvxNavigationService, mvxLog);
            CoreApp.Navigation.HomeView = contentPage;
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
        public IMvxViewModel MenuPage
        {
            get => menuPage;
            private set
            {
                menuPage = value;
                RaisePropertyChanged(() => MenuPage);
            }
        }
        public HomeViewModel ContentPage
        {
            get => contentPage;
            private set
            {
                contentPage = value;
                RaisePropertyChanged(() => MenuPage);
            }
        }
        #endregion

        #region Commands
        public IMvxCommand ShowMenu { get; private set; }
        public IMvxCommand ShowHome { get; private set; }
        public IMvxCommand ShowPlaylists { get; private set; }
        #endregion
    }
}
