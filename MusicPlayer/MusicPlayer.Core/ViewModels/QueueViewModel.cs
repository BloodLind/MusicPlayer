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

        #region Methods
        private void InitializeCommands()
        {

        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();
            CoreApp.Player.QueueChanged += Player_QueueChanged;
            CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
            Tracks = new(CoreApp.Player.Queue);
            SelectedTrack = CoreApp.Player.CurrentTrack;
        }

        private void Player_CurrentTrackChanged(Track obj)
        {
            this.SelectedTrack = obj;   
        }

        public override void ViewDisappearing()
        {
            base.ViewDisappearing();
            CoreApp.Player.QueueChanged -= Player_QueueChanged;
            CoreApp.Player.CurrentTrackChanged -= Player_CurrentTrackChanged;
        }
        private void Player_QueueChanged()
        {
           
        }
        #endregion

        #region Properties
        public Track SelectedTrack { get => selectedTrack; set { selectedTrack = value; RaisePropertyChanged(() => SelectedTrack); } }
        public MvxObservableCollection<Track> Tracks { get; set; }        
        #endregion

        #region Commands
        public IMvxCommand ClearQueueCommand { get; private set; }
        public IMvxCommand AddToQueueCommand { get; private set; }
        public IMvxCommand MoreActionCommand { get; private set; }
        #endregion
    }
}
