using ManagedBass;
using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class MusicPlayer : IMusicPlayer
    {
        #region Fields
        private ManagedBass.MediaPlayer musicPlayer;
        private Track currentTrack;
        #endregion

        public MusicPlayer(IEnumerable<Track> tracks)
        {
            musicPlayer = new MediaPlayer();
            musicPlayer.MediaEnded += TrackPlayEnded;

            Queue = new List<Track>(tracks);
            CurrentTrack = Queue.Count >= 1 ? Queue[0] : null;
        }


        #region Properties
        public List<Track> Queue { get; set; }
        public Track CurrentTrack { get => currentTrack; private set { currentTrack = value; CurrentTrackChanged?.Invoke(CurrentTrack); } }
        public double CurrentPosition
        {
            get => musicPlayer.Position.TotalSeconds;
            set => musicPlayer.Position = TimeSpan.FromSeconds(value);  
        }

        public PlaybackState PlaybackState 
        {
            get => musicPlayer.State;
        }

        public double Volume 
        {
            set => musicPlayer.Volume = value;
            get => musicPlayer.Volume;
        }
        #endregion

        #region Events
        public event EventHandler Disposed;
        public event Action<Track> CurrentTrackChanged; 
        #endregion

        #region Events Methods
        private void TrackPlayEnded(object sender, EventArgs e)
        {

            int index = Queue.IndexOf(CurrentTrack);
            if (index < Queue.Count - 1)
            {
                CurrentTrack = Queue[index + 1];
            }
            else if (Queue.Count >= 1)
            {
                CurrentTrack = Queue[0];
            }
            else
            {
                CurrentTrack = null;
            }

            if(musicPlayer.State == PlaybackState.Stopped 
                && CurrentTrack != null)
            {
                CurrentPosition = 0;
                Play();
            }


        }
        #endregion

        #region Methods
        public void ShuffleQueue()
        {
            Random rng = new Random();
            int n = Queue.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Track value = Queue[k];
                Queue[k] = Queue[n];
                Queue[n] = value;
            }
        }

        public virtual void Dispose()
        {
            if (Disposed != null)
            {
                Disposed(this, EventArgs.Empty);
            }
            CleanupPlayback();
        }

        public void Play()
        {
            if(musicPlayer.State == PlaybackState.Paused)
            {
                musicPlayer.Play();
            }
            else if(Queue.Count >= 1)
            {
                CurrentTrack = CurrentTrack == null ? Queue[0] : CurrentTrack;
                musicPlayer.LoadAsync(CurrentTrack.FilePath)
                    .ContinueWith((x) => {
                        musicPlayer.Play();
                    });

            }
        }

        public void Pause()
        {
            musicPlayer.Pause();
        }

        public void Stop()
        {
            musicPlayer.Stop();
        }

        public void CleanupPlayback()
        {
            musicPlayer.Dispose();
            Queue.Clear();
        }

        public void ChangeCurrentTrack(Track track)
        {
            bool isPlayed = PlaybackState != PlaybackState.Paused && PlaybackState != PlaybackState.Stopped;
            Stop();
            CurrentTrack = track;
            CurrentPosition = 0;

            if(isPlayed)
                Play();
        }
        #endregion
    }
}
