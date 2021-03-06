using Microsoft.Extensions.Logging;
using MusicPlayer.Core.ViewModels.ModalViewModels;
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
        private string lyrics;

        public NowPlayingViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            InitCommands();
            CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
        }

        private void Player_CurrentTrackChanged(Track obj)
        {
            this.SelectedTrack = obj;
        }

        private void InitCommands()
        {
            ReturnCommand = new MvxAsyncCommand(() =>
            {
                return NavigationService.Close(this);
            });

            MoreCommand = new MvxAsyncCommand(() =>
            {
               TrackManagerViewModel viewModel = new(selectedTrack, this.LoggerFactory, this.NavigationService);
               viewModel.CurrentTrack = SelectedTrack;
               return NavigationService.Navigate<ModalViewModel, Action<IMvxNavigationService>>((service) => service.Navigate(viewModel));
            });
        }

        public override void Prepare(Track parameter)
        {
            SelectedTrack = parameter;
        }


        #region Commands
        public IMvxAsyncCommand ReturnCommand { get; private set; }
        public IMvxAsyncCommand MoreCommand { get; private set; }
        #endregion

        #region Properties
        public string TrackLyrics { get => lyrics; set { lyrics = value; RaisePropertyChanged(() => TrackLyrics); } }
        public Track SelectedTrack { get => selectedTrack; set { selectedTrack = value; RaisePropertyChanged(() => SelectedTrack); } }
        #endregion

    }
}
