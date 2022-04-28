
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Services.Interfaces
{
    public interface ITrackInfoGrabber
    {
        ITrackInfoEditor EditFile(Track track);
        Track TrackByPath(string path);
        string GetExtension(string path);
        TrackAditionalInfo GetTrackAditionalInfo(string path);
    }
}
