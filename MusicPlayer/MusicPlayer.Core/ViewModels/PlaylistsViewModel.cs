using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels
{
    public class PlaylistsViewModel : MvxNavigationViewModel
    {
        public PlaylistsViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }


        #region Properties
            public IMvxCommand ShowPlaylist { get; private set; }
            
        #endregion
    }
}
