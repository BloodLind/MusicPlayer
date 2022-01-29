using Microsoft.Extensions.Logging;
using MusicPlayer.Core.ViewModels;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class NavigationPresenter
    {
        public NavigationPresenter(IMvxNavigationService mvxNavigationService, ILoggerFactory logger)
        {
            MvxNavigationService = mvxNavigationService;
            Logger = logger;
            HomeView = new HomeViewModel(MvxNavigationService, Logger);
        }
        public IMvxNavigationService MvxNavigationService { get; }
        public ILoggerFactory Logger { get; }
        public HomeViewModel HomeView { get; private set; }
    }
}
