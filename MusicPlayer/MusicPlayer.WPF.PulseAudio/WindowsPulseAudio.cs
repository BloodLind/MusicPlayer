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
    public enum QueueMoves
    {
        Next = 1,
        Previous = -1
    }
    public class WindowsPulseAudio : IPulseAudioBase
    {
        #region Fields
        private ManagedBass.MediaPlayer musicPlayer;
        private Track currentTrack;
        private List<Track> queue;
        private List<int> playingQueue = new List<int>();
        private double volume = 0.5;
        private int currentIndex;
        private LoopState loopState;
        private int trackPlayCount = 0;
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
        public bool IsQueueShuffled { get; set; } = false;

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
            if(LoopState.LoopedTrack == loopState && trackPlayCount++ < 1)
            {
                ChangeCurrentTrack(CurrentTrack);
            }
            else
            {
                QueueMove((int)QueueMoves.Next);
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
                int tmp = playingQueue[0];
                int index = playingQueue.IndexOf(queue.IndexOf(CurrentTrack));
                playingQueue[0] = playingQueue[index];
                playingQueue[index] = tmp;
            }
            currentIndex = 0;
            QueueChanged?.Invoke();
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
            StateChanged?.Invoke(MusicPlayer.PulseAudio.Base.PlaybackState.Paused);
        }

        public void Stop()
        {
            musicPlayer.Stop();
            StateChanged?.Invoke(MusicPlayer.PulseAudio.Base.PlaybackState.Stopped);
        }

        public void CleanupPlayback()
        {
            CurrentTrack = null;
            Stop();
            PlayingQueue.Clear();
            Queue.Clear();
            QueueChanged?.Invoke();
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
            if (IsQueueShuffled)
                ShuffleQueue();
        }

        public void UnshuffleQueue()
        {
            playingQueue.Clear();
            for(int i = 0; i < Queue.Count; i++)
            {
                playingQueue.Add(i);
            }
            QueueChanged?.Invoke();
        }

        public void AddTrackToQueue(Track track)
        {
            this.Queue.Add(track);
            this.PlayingQueue.Add(playingQueue.Count);
        }

        public void ChangeLoopState(LoopState state)
        {
            loopState = state;
        }

        public void Previous()
        {
            QueueMove((int)QueueMoves.Previous);
        }

        public void Next()
        {
            QueueMove((int)QueueMoves.Next);
        }

        private void QueueMove(int index)
        {
            trackPlayCount = 0;
            if (CurrentTrackIndex + index >= 0 && CurrentTrackIndex + index <= PlayingQueue.Count - 1)
            {
                ChangeCurrentTrack(Queue[PlayingQueue[CurrentTrackIndex + index]]);
            }
            else if (loopState == LoopState.Looped)
            {
                ChangeCurrentTrack(Queue[PlayingQueue[index > 0 ? 0 : PlayingQueue.Count + index]]);
            }
            else
            {
                Stop();
            }
        }
        #endregion
    }
}
