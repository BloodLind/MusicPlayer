using MusicPlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class TracksManager
    {
        TrackInfoGrabber grabber = new TrackInfoGrabber();

        public IEnumerable<Track> GetTracksList(IEnumerable<string> paths)
        {
            IEnumerable<Track> tracks = new List<Track>();

            foreach (var a in paths)
            {
                tracks.Append(grabber.TrackByPath(a));
            }

            return tracks;
        }
        public IEnumerable<Artist> GetArtists(IEnumerable<Track> tracks)
        {
            IEnumerable<Artist> artists = new List<Artist>();

            foreach (var track in tracks)
            {
                bool check = true;
                string artistName = track.Artist;
                foreach (var b in artists)
                {
                    if (artistName == b.Name)
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    Artist newArtist = new Artist() { Name = artistName };
                    IEnumerable<Track> tracksToAdd = tracks.Where(x => x.Artist == artistName);
                    newArtist.Tracks = tracksToAdd.ToList();
                    newArtist.PlayTime = GetPlayTime(newArtist.Tracks);
                    newArtist.TracksCount = newArtist.Tracks.Count;
                    artists.Append(newArtist);
                }

            }

            
            return artists;
        }
        public IEnumerable<Album> GetAlbums(IEnumerable<Track> tracks)
        {
            IEnumerable<Album> albums = new List<Album>();

            foreach (var track in tracks)
            {
                bool check = true;
                string albumName = track.Album;
                foreach (var b in albums)
                {
                    if (albumName == b.Name)
                    {
                        check = false;
                        break;
                    }
                }

                if (check)
                {
                    Album newAlbum = new Album() { Name = albumName };
                    IEnumerable<Track> tracksToAdd = tracks.Where(x => x.Album == albumName);
                    newAlbum.Tracks = tracksToAdd.ToList();
                    newAlbum.PlayTime = GetPlayTime(newAlbum.Tracks);
                    newAlbum.TracksCount = newAlbum.Tracks.Count;
                    albums.Append(newAlbum);
                }

            }


            return albums;
        }

        private TimeSpan GetPlayTime(IEnumerable<Track> tracks)
        {
            TimeSpan playTime = new TimeSpan();
            foreach (var a in tracks)
            {
                playTime.Add(a.PlayTime);
            }

            return playTime;
        }

    }
}
