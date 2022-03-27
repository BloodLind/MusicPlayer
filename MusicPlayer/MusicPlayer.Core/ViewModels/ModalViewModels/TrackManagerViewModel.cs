using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Services;
using MusicPlayer.PulseAudio.Tracks.Services.Interfaces;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels.ModalViewModels
{
    public class TrackManagerViewModel : MvxNavigationViewModel
    {
        private IUserInteractionService interactionService;
        private void InitializeCommands()
        {
            ToFolderCommand = new MvxCommand(() =>
            {
                interactionService.OpenExplorer(Path.GetDirectoryName(CurrentTrack.FilePath));   
            });
            BrowseLyricsCommand = new MvxCommand(() =>
            {
                interactionService.OpenBrowser("http://google.com/search?q=" + CurrentTrack.Title.Replace(' ', '+') + "+lyrics");
            });

            DeleteCommand = new MvxCommand(() =>
            {

            });
            InfoTrackCommand = new MvxCommand(() =>
            {

            });
            EditTrackCommand = new MvxCommand(() =>
            {

            });
            AddToPlaylistCommand = new MvxCommand(() =>
            {

            });
        }

        


        public TrackManagerViewModel(Track currentTrack, ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            InitializeCommands();
            CurrentTrack = currentTrack;
            TrackExtension = Mvx.IoCProvider.Resolve<ITrackInfoGrabber>().GetExtension(CurrentTrack.FilePath);
            interactionService = Mvx.IoCProvider.Resolve<IUserInteractionService>();
        }

        #region Properties
        public Track CurrentTrack { get; set; }
        public string TrackExtension { get; set; }
        #endregion


        #region Commands
        public IMvxCommand AddToPlaylistCommand { get; private set; }
        public IMvxCommand EditTrackCommand { get; private set; }
        public IMvxCommand InfoTrackCommand { get; private set; }
        public IMvxCommand DeleteCommand { get; private set; }
        public IMvxCommand ToFolderCommand { get; private set; }
        public IMvxCommand BrowseLyricsCommand { get; private set; }
        #endregion
    }
}
