using MusicPlayer.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MusicPlayer.Core.ViewModels
{

    public class NowPlayingViewModel : MvxViewModel
    {

        #region Fields
        private double volume = 0.5;
        private bool isPlaying = false;
        private Timer trackPositionTimer;
        private double currentPosition;
        #endregion
        public NowPlayingViewModel()
        {
            InitCommands();
            trackPositionTimer = new Timer(1000);
            trackPositionTimer.Elapsed += TrackPositionTimer_Elapsed;
        }
        public override void ViewAppearing()
        {
            if(CoreApp.Player != null)
                CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
            base.ViewAppearing();
        }

        private void Player_CurrentTrackChanged(Track obj)
        {
            RaisePropertyChanged(() => CurrentTrack);
        }

        private void TrackPositionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!IsPositionChanging)
            {
                CurrentPosition += 1;
            }
        }

        public void InitCommands()
        {
            ReturnCommand = new MvxCommand( () =>
            {
                 CoreApp.Navigation.MvxNavigationService.Navigate(CoreApp.Navigation.HomeView);
            });
           
            ShuffleCommand = new MvxCommand(() =>
            {
                CoreApp.Player.ShuffleQueue();
                CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[0]);
            });
            RandomCommand = new MvxCommand(() =>
            {
                isPlaying = true;
                Random rnd = new Random();
                CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[rnd.Next(0, CoreApp.Player.Queue.Count())]);
                ResetTimer();
            });
            PreviousCommand = new MvxCommand(() =>
            {
                if ((CoreApp.Player.Queue.IndexOf(CoreApp.Player.CurrentTrack) - 1) >= 0)
                {
                    CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[CoreApp.Player.Queue.IndexOf(CoreApp.Player.CurrentTrack) - 1]);
                }
                else
                {
                    CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[CoreApp.Player.Queue.Count - 1]);
                }
                ResetTimer();

            });
            NextCommand = new MvxCommand(() =>
            {
                if ((CoreApp.Player.Queue.IndexOf(CoreApp.Player.CurrentTrack) + 1) < CoreApp.Player.Queue.Count())
                {
                    CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[CoreApp.Player.Queue.IndexOf(CoreApp.Player.CurrentTrack) + 1]);
                }
                else
                {
                    CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[0]);
                }
                ResetTimer();
            });
            PauseCommand = new MvxCommand(() =>
            {
                isPlaying = false;
                ResetTimer();
                CoreApp.Player.Pause();
            });
            PlayCommand = new MvxCommand(() =>
            {
                isPlaying = true;
                ResetTimer();
                CoreApp.Player.Play();
            });
        }
        #region Methods
        private void ResetTimer()
        {

            if (CoreApp.Player.PlaybackState == ManagedBass.PlaybackState.Stopped)
            {
                if (isPlaying)
                {
                    CurrentPosition = 0;
                    trackPositionTimer.Start();
                }
            }
            if (!isPlaying)
            {
                trackPositionTimer.Stop();
            }
            else
            {
                trackPositionTimer.Start();
            }
        }
        #endregion

        #region Properties
        public Track CurrentTrack
        {
            get => CoreApp.Player.CurrentTrack;
        }
       
        public double CurrentPosition
        {
            get => currentPosition;
            set
            {

                currentPosition = value;
                RaisePropertyChanged(() => CurrentPosition);

            }
        }
        public bool IsPositionChanging { get; set; } = false;
        #endregion


        #region Commands
        public IMvxCommand ReturnCommand { get; set; }
        public IMvxCommand ShuffleCommand { get; private set; }
        public IMvxCommand RandomCommand { get; private set; }
        public IMvxCommand PreviousCommand { get; private set; }
        public IMvxCommand NextCommand { get; private set; }
        public IMvxCommand PauseCommand { get; private set; }
        public IMvxCommand PlayCommand { get; private set; }
        #endregion
    }
}
