using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core
{
    public class CoreAppStart : MvxAppStart
    {
        

    public CoreAppStart(IMvxApplication mvxApplication, IMvxNavigationService mvxNavigationService)
        : base(mvxApplication, mvxNavigationService)
    {
            CoreApp.Navigation = new ViewModels.NavigationPresenter(mvxNavigationService);
            
    }
    protected override Task NavigateToFirstViewModel(object hint = null)
    {
            return CoreApp.Navigation.MvxNavigationService.Navigate<RootViewModel>();
    }

}
}
