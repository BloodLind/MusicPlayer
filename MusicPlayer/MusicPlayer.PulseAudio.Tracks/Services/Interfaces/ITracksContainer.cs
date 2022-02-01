using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Services.Interfaces
{
    public interface ITracksContainer
    {
        double PlayTime { get; set; }
        int TracksCount { get; set; }
        IEnumerable<Track> Tracks { get; set; }
    }
}
