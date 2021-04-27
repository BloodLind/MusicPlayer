using CSCore;
using CSCore.CoreAudioAPI;
using CSCore.SoundOut;
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
        private IWaveSource waveSource;
        
        public ISoundOut SoundOut { get; set; }
        public Queue<Track> Queue { get; set; }
        public Track CurrentTrack { get; set; }

        public event EventHandler<PlaybackStoppedEventArgs> PlaybackStopped;
        public event EventHandler Disposed;
        public event Action<Track> CurrentTrackChanged;

        public MusicPlayer(IEnumerable<Track> tracks, ISoundOut soundOut)
        {
            SoundOut = soundOut;
            Queue = new Queue<Track>(tracks);
        }




        public PlaybackState PlaybackState
        {
            get
            {
                if (SoundOut != null)
                    return SoundOut.PlaybackState;
                return PlaybackState.Stopped;
            }
        }

        public TimeSpan Position
        {
            get
            {
                if (waveSource != null)
                    return waveSource.GetPosition();
                return TimeSpan.Zero;
            }
            set
            {
                if (waveSource != null)
                    waveSource.SetPosition(value);
            }
        }

        public TimeSpan Length
        {
            get
            {
                if (waveSource != null)
                    return waveSource.GetLength();
                return TimeSpan.Zero;
            }
        }

        public int Volume
        {
            get
            {
                if (SoundOut != null)
                    return Math.Min(100, ((int)SoundOut.Volume * 100));
                return 100;
            }
            set
            {
                if (SoundOut != null)
                {
                    SoundOut.Volume = Math.Min(1.0f, (value / 100f));
                }
            }
        }

        public void ShuffleQueue()
        {
            Random rng = new Random();
            int n = Queue.Count;
            List<Track> queueToList = Queue.ToList();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Track value = queueToList[k];
                queueToList[k] = queueToList[n];
                queueToList[n] = value;
            }

            Queue = new Queue<Track>(queueToList);
        }

        public void CleanupPlayback()
        {
            if (SoundOut != null)
            {
                SoundOut.Dispose();
                SoundOut = null;
            }
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }
        }

        public void Pause()
        {

            if (SoundOut != null)
                SoundOut.Pause();


        }

        public void Play()
        {

            if (SoundOut != null)
                SoundOut.Play();


        }

        public void Stop()
        {
            if (SoundOut != null)
                SoundOut.Stop();
        }

        public virtual void Dispose()
        {
            if (Disposed != null)
            {
                Disposed(this, EventArgs.Empty);
            }
            CleanupPlayback();
        }
    }
}
