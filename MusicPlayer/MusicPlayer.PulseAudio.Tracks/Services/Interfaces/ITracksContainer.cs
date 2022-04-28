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
        double PlayTime { get; }
        int TracksCount { get; }
        List<Track> Tracks { get; set; }
    }
}
