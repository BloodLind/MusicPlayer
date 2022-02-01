using Microsoft.Extensions.Logging;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
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
    public class NowPlayingViewModel : MvxNavigationViewModel<Track>
    {
        private Track selectedTrack;

        public NowPlayingViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            InitCommands();
        }

        private void InitCommands()
        {
            ReturnCommand = new MvxCommand(() =>
            {
                NavigationService.Close(this);
            });
        }

        public override void Prepare(Track parameter)
        {
            SelectedTrack = parameter;
        }


        #region Commands
        public IMvxCommand ReturnCommand { get; private set; }
        #endregion

        #region Properties
        public Track SelectedTrack { get => selectedTrack; set { selectedTrack = value; RaisePropertyChanged(() => ReturnCommand); } }
        #endregion

    }
}
