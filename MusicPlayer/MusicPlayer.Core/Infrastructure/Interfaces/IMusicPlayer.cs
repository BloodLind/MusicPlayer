using MusicPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface IMusicPlayer : IDisposable
    {
        double CurrentPosition { get; set; }
        Track CurrentTrack { get; }
        List<Track> Queue { get; set; }
        
        void Play();
        void Pause();
        void Stop();
        void CleanupPlayback();
        void ChangeCurrentTrack(Track track);

        event Action<Track> CurrentTrackChanged;
        event Action<double> PositionChanged;
    }
}
