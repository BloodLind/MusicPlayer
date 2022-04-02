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
        private List<int> playingQueue = new List<int>();
        private double volume = 0.5;
        private int currentIndex;
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
            queue.OrderBy(x => x.Title);
            CurrentTrack = Queue.Count >= 1 ? Queue.First() : null;
        }




        #region Properties
        public List<Track> Queue => queue;
        public List<int> PlayingQueue => playingQueue;
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
            set => musicPlayer.Volume = volume = value;
            get => volume;
        }
        public bool IsQueueLooped { get; set; } = false;

        public IAudioOutput AudioOutput => throw new NotImplementedException();

        public int CurrentTrackIndex => currentIndex;
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
            if (currentIndex < Queue.Count - 1)
            {
                CurrentTrack = Queue.ElementAt(playingQueue[currentIndex++]);
            }
            else if (Queue.Count >= 1)
            {
                CurrentTrack = Queue.First();
                currentIndex = 0;
            }
            else
            {
                CurrentTrack = null;
                currentIndex = -1;
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
            int n = Queue.Count;
            while (n-- > 1)
            {
                int k = rng.Next(n + 1);
                int value = playingQueue[k];
                playingQueue[k] = playingQueue[n];
                playingQueue[n] = value;
            }

            if(CurrentTrack != null)
            {
                int tmp = playingQueue[currentIndex];
                playingQueue[currentIndex] = playingQueue[0];
                playingQueue[0] = tmp;
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
                this.StateChanged?.Invoke((MusicPlayer.PulseAudio.Base.PlaybackState)musicPlayer.State);
                musicPlayer.Volume = this.Volume;
            }
            else if (Queue.Count >= 1)
            {
                CurrentTrack = CurrentTrack == null ? Queue.First() : CurrentTrack;
                    musicPlayer.LoadAsync(CurrentTrack.FilePath)
                        .ContinueWith((x) => {
                            musicPlayer.Play();
                            this.StateChanged?.Invoke((MusicPlayer.PulseAudio.Base.PlaybackState)musicPlayer.State);
                            musicPlayer.Volume = this.Volume;
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
            currentIndex = playingQueue.IndexOf(queue.IndexOf(track));

            if (isPlayed && CurrentTrack != null)
                Play();
        }

        public void RemoveTrackFromQueue(Track track)
        {
            int index = Queue.IndexOf(track);
            if (index < 0)
                return;

            playingQueue.Remove(playingQueue.ElementAt(index));
            queue.Remove(track);
        }
       

        public void ChangeOutputDevice(IAudioOutput output)
        {
            throw new NotImplementedException();
        }

        public void SetQueue(IEnumerable<Track> tracks)
        {
            queue = new List<Track>();
            foreach (var track in tracks)
                queue.Add(track);

            CurrentTrack = queue.First();
            CurrentPosition = 0;
            currentIndex = 0;
            UnshuffleQueue();
            if (IsQueueLooped)
                ShuffleQueue();
        }

        public void UnshuffleQueue()
        {
            playingQueue.Clear();
            for(int i = 0; i < Queue.Count; i++)
            {
                playingQueue.Add(i);
            }
        }

        public void AddTrackToQueue(Track track)
        {
            this.Queue.Add(track);
            this.PlayingQueue.Add(playingQueue.Count);
        }
        #endregion
    }
}
