using MusicPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface ITrackContainer
    {
        TimeSpan PlayTime { get; set; }
        int TracksCount { get; set; }
        List<Track> Tracks { get; set; }
    }
}
