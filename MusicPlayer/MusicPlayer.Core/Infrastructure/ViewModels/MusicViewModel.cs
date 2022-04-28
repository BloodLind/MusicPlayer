using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.PulseAudio.Base;
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

namespace MusicPlayer.Core.Infrastructure.ViewModels
{
    public class MusicViewModel : MvxNavigationViewModel, ITrackController
    {
        #region Fields
        private double volume = 0.5;
        private bool isPlaying = false;
        private double currentPosition;
        #endregion

        private Track selectedTrack = new Track();
        private bool isShuffled = false;
        private LoopState loopState = LoopState.Looped;
        private bool isMuted;

        public MusicViewModel(ILoggerFactory mvxLog, IMvxNavigationService service)
            : base(mvxLog, service)
        {
            InitCommands();
            CoreApp.TimerElapsed += CoreApp_TimerElapsed;
            CurrentPosition = CoreApp.Player == null ? 0 : CoreApp.Player.CurrentPosition;
            IsPlaying = CoreApp.Player == null ? false : CoreApp.Player.State == PlaybackState.Playing;
            CoreApp.PlayerLoaded += PlayerLoaded;
        }

        protected virtual void Player_CurrentTrackChanged(Track obj)
        {
            SelectedTrack = (Track)obj;
            ResetTimer();
            if(selectedTrack == null)
                isPlaying = false;
        }

        private void Player_StateChanged(PlaybackState obj)
        {
            IsPlaying = obj == PlaybackState.Playing;
            if (obj == PlaybackState.Stopped)
            {
                isPlaying = false;
                CurrentPosition = 0;
                ResetTimer();
            }
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
                IsShuffled = !IsShuffled;
                CoreApp.Player.IsQueueShuffled = isShuffled;

                if (isShuffled)
                    CoreApp.Player.ShuffleQueue();
                else
                    CoreApp.Player.UnshuffleQueue();
            });
           ChangeLoopStateCommand = new MvxCommand(() =>
            {
                var state = (int)LoopState + 1;
                LoopState = state > (int)LoopState.LoopedTrack ? LoopState.NoLoop : (LoopState)state;
                CoreApp.Player.ChangeLoopState(loopState);
            });
            PreviousCommand = new MvxCommand(() =>
            {
                CoreApp.Player.Previous();
                ResetTimer();
            });
            NextCommand = new MvxCommand(() =>
            {
                CoreApp.Player.Next();
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
                if (SelectedTrack == null)
                    return;

                IsPlaying = true;
                CoreApp.Player.Play();
                ResetTimer();
            });

            ChangeLoopStateCommand = new MvxCommand(() =>
            {
                var state = (int)LoopState + 1;
                LoopState = state <= (int)LoopState.LoopedTrack ? (LoopState)state : LoopState.NoLoop;
                CoreApp.Player.ChangeLoopState(LoopState);
            });

            MuteAudioCommand = new MvxCommand(() =>
            {
                IsMuted = !isMuted;
                if (isMuted)
                    CoreApp.Player.Volume = 0;
                else
                    CoreApp.Player.Volume = Volume;
            });
        }

        private void PlayerLoaded()
        {
            if (CoreApp.Player != null)
            {
                CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
                CoreApp.Player.StateChanged += Player_StateChanged;
                CoreApp.Player.IsQueueShuffled = IsShuffled;
                CoreApp.Player.ChangeLoopState(LoopState);
                IsPlaying = CoreApp.Player.State == PlaybackState.Playing;
                CurrentPosition = CoreApp.Player.CurrentPosition;
                Volume = CoreApp.Player.Volume;
                SelectedTrack = (Track)CoreApp.Player.CurrentTrack;
            }
        }

        protected void ResetTimer()
        {
            if (CoreApp.Player.State == PlaybackState.Stopped)
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
        public double CurrentPosition
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
                IsMuted = false;
                volume = value;
                CoreApp.Player.Volume = value;
                RaisePropertyChanged(() => Volume);
            }
        }
        public bool IsPositionChanging { get; set; } = false;
        public bool IsMuted { get => isMuted; set 
            { 
                isMuted = value;
                if (!isMuted)
                    CoreApp.Player.Volume = Volume;
                RaisePropertyChanged(() => IsMuted); 
            } }
        public LoopState LoopState { get => loopState; set { loopState = value; RaisePropertyChanged(() => LoopState); } } 
        public bool IsShuffled { get => isShuffled; set { isShuffled = value; RaisePropertyChanged(() => IsShuffled); } }
        #endregion

        #region Commands
        public IMvxCommand MuteAudioCommand { get; private set;}
        public IMvxCommand ShuffleCommand { get; private set; }
        public IMvxCommand RandomCommand { get; private set; }
        public IMvxCommand PreviousCommand { get; private set; }
        public IMvxCommand NextCommand { get; private set; }
        public IMvxCommand PauseCommand { get; private set; }
        public IMvxCommand PlayCommand { get; private set; }
        public IMvxCommand ChangeLoopStateCommand { get; private set; }
        #endregion
    }
}
