using ManagedBass;
using MusicPlayer.PulseAudio.Base;
using MusicPlayer.PulseAudio.Base.Audio;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.WPF.PulseAudio
{
    public class WindowsPulseAudio : IPulseAudioBase
    {
        #region Fields
        private ManagedBass.MediaPlayer musicPlayer;
        private Track currentTrack;
        private List<Track> queue;
        #endregion

        public WindowsPulseAudio()
        {
            musicPlayer = new MediaPlayer();
            musicPlayer.MediaEnded += TrackPlayEnded;
        }

        public WindowsPulseAudio(IEnumerable<Track> tracks)
        {
            musicPlayer = new MediaPlayer();
            musicPlayer.MediaEnded += TrackPlayEnded;

            queue = new List<Track>(tracks);
            CurrentTrack = Queue.Count >= 1 ? Queue[0] : null;
        }




        #region Properties
        public List<Track> Queue => queue;
        public Track CurrentTrack { get => currentTrack; private set { currentTrack = value; CurrentTrackChanged?.Invoke(CurrentTrack); } }
        public double CurrentPosition
        {
            get => musicPlayer.Position.TotalSeconds;
            set => musicPlayer.Position = TimeSpan.FromSeconds(value);
        }

        public MusicPlayer.PulseAudio.Base.PlaybackState State
        {
            get => (MusicPlayer.PulseAudio.Base.PlaybackState)musicPlayer.State;
        }

        public double Volume
        {
            set => musicPlayer.Volume = value;
            get => musicPlayer.Volume;
        }
        public bool IsQueueLooped { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IAudioOutput AudioOutput => throw new NotImplementedException();
        #endregion

        #region Events
        public event EventHandler Disposed;
        public event Action<Track> CurrentTrackChanged;
        public event Action<MusicPlayer.PulseAudio.Base.PlaybackState> StateChanged;
        public event Action QueueChanged;
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

            if (musicPlayer.State == ManagedBass.PlaybackState.Stopped
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
            Track value = null;
            int n = Queue.Count;
            while (n-- > 1)
            {
                int k = rng.Next(n + 1);
                value = Queue[k];
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

            if (musicPlayer.State == ManagedBass.PlaybackState.Paused)
            {
                musicPlayer.Play();
            }
            else if (Queue.Count >= 1)
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
            bool isPlayed = State != MusicPlayer.PulseAudio.Base.PlaybackState.Paused && State 
                != MusicPlayer.PulseAudio.Base.PlaybackState.Stopped;
            Stop();
            CurrentTrack = track;
            CurrentPosition = 0;

            if (isPlayed)
                Play();
        }

       

        public void ChangeOutputDevice(IAudioOutput output)
        {
            throw new NotImplementedException();
        }

        public void SetQueue(IEnumerable<Track> tracks)
        {
            queue = tracks.ToList();
            CurrentTrack = queue.First();
            CurrentPosition = 0;
        }
        #endregion
    }
}
