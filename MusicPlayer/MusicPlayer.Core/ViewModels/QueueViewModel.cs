using Microsoft.Extensions.Logging;
using MusicPlayer.PulseAudio.Base.Models;
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
    public class QueueViewModel : MvxNavigationViewModel
    {

        #region Fields
        private Track selectedTrack;
        #endregion
        public QueueViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            InitializeCommands();
        }

        #region Commands Realization
      
        #endregion 

        #region Methods
        private void InitializeCommands()
        {
            ClearQueueCommand = new MvxCommand(() => CoreApp.Player.CleanupPlayback());
            PlaySelectedCommand = new MvxCommand(() =>
            {
                CoreApp.Player.Stop();
                CoreApp.Player.ChangeCurrentTrack(SelectedTrack);
                CoreApp.Player.Play();
            });
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            CoreApp.Player.QueueChanged += Player_QueueChanged;
            CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
            CoreApp.Player.PlayingQueue.ForEach(i => Tracks.Add(CoreApp.Player.Queue[i]));
            SelectedTrack = CoreApp.Player.CurrentTrack;
        }


        public override void ViewDisappearing()
        {
            base.ViewDisappearing();
            CoreApp.Player.QueueChanged -= Player_QueueChanged;
            CoreApp.Player.CurrentTrackChanged -= Player_CurrentTrackChanged;
        }
        #endregion
        
        #region Events Handlers
        private void Player_CurrentTrackChanged(Track obj)
        {
            this.SelectedTrack = obj;   
        }
        
        private void Player_QueueChanged()
        {
            this.Tracks.Clear();
            CoreApp.Player.PlayingQueue.ForEach(i => Tracks.Add(CoreApp.Player.Queue[i]));
            SelectedTrack = CoreApp.Player.CurrentTrack;
        }

        #endregion
        #region Properties
        public Track SelectedTrack { get => selectedTrack; set { selectedTrack = value; RaisePropertyChanged(() => SelectedTrack); } }
        public MvxObservableCollection<Track> Tracks { get; set; } = new MvxObservableCollection<Track>();
        #endregion

        #region Commands
        public IMvxCommand PlaySelectedCommand { get; private set; }
        public IMvxCommand ClearQueueCommand { get; private set; }
        public IMvxCommand AddToQueueCommand { get; private set; }
        public IMvxCommand MoreActionCommand { get; private set; }
        #endregion
    }
}
