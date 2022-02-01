using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using MusicPlayer.PulseAudio.Tracks.Services.Interfaces;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Services
{
    public class TrackInfoGrabber : ITrackInfoGrabber
    {

        public ITrackInfoEditor EditFile(Track track)
        {
            throw new NotImplementedException();
        }

        public Track TrackByPath(string path)
        {
            using (var tmp = TagLib.File.Create(path))
            {
                return new Track
                {
                    Title = tmp.Tag.Title == null ? path : tmp.Tag.Title,
                    FilePath = path,
                    PlayTime = tmp.Properties.Duration.TotalSeconds,
                    Artist = tmp.Tag.Performers.Count() >= 1 ? tmp.Tag.Performers[0] : "Undefined",
                    Album = tmp.Tag.Album == null ? "Undefined" : tmp.Tag.Album,
                    Genre = tmp.Tag.Genres.Count() >= 1 ? tmp.Tag.Genres[0] : "Undefined"
                };

            }
        }

        public byte[] GetTrackImage(string path)
        {
            using (var tmp = TagLib.File.Create(path))
            {
                return tmp.Tag.Pictures.Length >= 1 ? tmp.Tag.Pictures.ElementAt(0).Data.ToArray() : null;
            }
        }
    }
}
