using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels
{

    public class NowPlayingViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService mvxNavigationService;
        public NowPlayingViewModel(IMvxNavigationService mvxNavigationService)
        {
            this.mvxNavigationService = mvxNavigationService;
        }
    }
}
