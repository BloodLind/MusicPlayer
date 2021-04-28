
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
        
        public Queue<Track> Queue { get; set; }
        public Track CurrentTrack { get; set; }

      
        public event EventHandler Disposed;
        public event Action<Track> CurrentTrackChanged;

        public MusicPlayer(IEnumerable<Track> tracks)
        {
            
            Queue = new Queue<Track>(tracks);
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
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void CleanupPlayback()
        {
            throw new NotImplementedException();
        }
    }
}
