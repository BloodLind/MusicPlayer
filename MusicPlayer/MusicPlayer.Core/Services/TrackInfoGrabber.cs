using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            MemoryStream ms = new MemoryStream(tmp.Tag.Pictures[0].Data.ToArray());
            Track track = new Track();

            track.Title = tmp.Tag.Title;
            track.FilePath = path;
            track.PlayTime = tmp.Properties.Duration;
            track.Artist = tmp.Tag.Performers[0];
            track.Album = tmp.Tag.Album;
            track.Genre = tmp.Tag.Genres[0];
            track.Image = Image.FromStream(ms);

            ms.Dispose();

            return track;
        }
    }
}
