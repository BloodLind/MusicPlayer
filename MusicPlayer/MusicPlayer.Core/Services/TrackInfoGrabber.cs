using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Models;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class TrackInfoGrabber : ITrackInfoGrabber
    {

        public ITrackInfoEditor EditFile(Track track)
        {
            throw new NotImplementedException();
        }

        public Track TrackByPath(string path)
        {
            
            var tmp = TagLib.File.Create(path);
            Track track = new Track();

            track.Title = tmp.Tag.Title;
            track.FilePath = path;
            track.PlayTime = tmp.Properties.Duration.TotalSeconds;
            track.Artist = tmp.Tag.Performers.Count() >= 1 ? tmp.Tag.Performers[0] : "Undefined";
            track.Album = tmp.Tag.Album;
            track.Genre = tmp.Tag.Genres.Count() >= 1 ? tmp.Tag.Genres[0] : "Undefined";
            track.Image = tmp.Tag.Pictures.Length>= 1 ? tmp.Tag.Pictures.ElementAt(0).Data.ToArray() : null;

           

            return track;
        }
    }
}
