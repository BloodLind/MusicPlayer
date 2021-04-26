using MusicPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface ITrackInfoGrabber
    {
        ITrackInfoEditor EditFile(Track track);
        Track TrackByPath(string path);
    }
}
