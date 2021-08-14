using ManagedBass;
using MusicPlayer.Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MusicPlayer.Core.Infrastructure.ViewModels
{
    public class MusicViewModel : MvxViewModel
    {
        #region Fields
        private double volume = 0.5;
        private bool isPlaying = false;
        private double currentPosition;
        #endregion

        private Track selectedTrack = new Track();

        public MusicViewModel()
        {
            InitCommands();
            CoreApp.TimerElapsed += CoreApp_TimerElapsed;
            CurrentPosition = CoreApp.Player == null ? 0 : CoreApp.Player.CurrentPosition;
            IsPlaying = CoreApp.Player == null? false : CoreApp.Player.PlaybackState == PlaybackState.Playing;
        }

        protected virtual void Player_CurrentTrackChanged(Track obj)
        {
            SelectedTrack = obj;
            ResetTimer();
        }

        private void CoreApp_TimerElapsed()
        {
            if (IsPlaying)
            {
                CurrentPosition++;
            }
        }

        private void InitCommands()
        {
            ShuffleCommand = new MvxCommand(() =>
            {
                CoreApp.Player.ShuffleQueue();
            });
            RandomCommand = new MvxCommand(() =>
            {
                IsPlaying = true;
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
                IsPlaying = false;
                ResetTimer();
                CoreApp.Player.Pause();
            });

            PlayCommand = new MvxCommand(() =>
            {
                IsPlaying = true;
                ResetTimer();
                CoreApp.Player.Play();
            });
        }

        public override void ViewAppearing()
        {
            if (CoreApp.Player != null)
            {
                CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
                IsPlaying = CoreApp.Player.PlaybackState == ManagedBass.PlaybackState.Playing;
                CurrentPosition = CoreApp.Player.CurrentPosition;
                Volume = CoreApp.Player.Volume;
                SelectedTrack = CoreApp.Player.CurrentTrack;
            }
            base.ViewAppearing();
        }

        protected void ResetTimer()
        {

            if (CoreApp.Player.PlaybackState == ManagedBass.PlaybackState.Stopped)
            {
                if (isPlaying)
                {
                    CurrentPosition = 0;
                }
            }
        }


        #region Properties

        public Track SelectedTrack
        {
            get => selectedTrack;
            set
            {
                selectedTrack = value;
                RaisePropertyChanged(() => SelectedTrack);

            }
        }

        public bool IsPlaying
        {
            get => isPlaying;
            set
            {
                isPlaying = value;
                RaisePropertyChanged(() => IsPlaying);
            }
        }
        public  double CurrentPosition
        {
            get => currentPosition;
            set
            {
                currentPosition = value;
                RaisePropertyChanged(() => CurrentPosition);
            }
        }

        public double Volume
        {
            get => volume;
            set
            {
                volume = value;
                CoreApp.Player.Volume = value;

                RaisePropertyChanged(() => Volume);
            }
        }
        public bool IsPositionChanging { get; set; } = false;

        #endregion

        #region Commands
        public IMvxCommand ShuffleCommand { get; private set; }
        public IMvxCommand RandomCommand { get; private set; }
        public IMvxCommand PreviousCommand { get; private set; }
        public IMvxCommand NextCommand { get; private set; }
        public IMvxCommand PauseCommand { get; private set; }
        public IMvxCommand PlayCommand { get; private set; }
        #endregion
    }
}
