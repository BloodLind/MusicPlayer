using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels
{
    public class NavigationPresenter
    {
        public IMvxNavigationService MvxNavigationService { get; }
        
        public NavigationPresenter(IMvxNavigationService mvxNavigationService)
        {
            this.MvxNavigationService = mvxNavigationService;
        }

        public HomeViewModel HomeView { get; } = new HomeViewModel();
        public NowPlayingViewModel NowPlayingView { get; } = new NowPlayingViewModel();
    }
}
