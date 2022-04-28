using Microsoft.Extensions.Logging;
using MusicPlayer.Core.ViewModels;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core
{
    public class CoreAppInitializer : MvxAppStart
    {
        public CoreAppInitializer(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {
            CoreApp.Navigation = new Services.NavigationPresenter(navigationService, Mvx.IoCProvider.Resolve<ILoggerFactory>());
        }

        protected override Task NavigateToFirstViewModel(object hint = null)
        {
            return NavigationService.Navigate<RootViewModel>();
        }
    }
}
