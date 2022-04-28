using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Services
{
    public class TracksManager
    {
        TrackInfoGrabber grabber = new TrackInfoGrabber();


        //Remake it to hash set or another sorted container with distinct elements
        public IEnumerable<Track> GetTracksList(IEnumerable<string> paths)
        {
            return (from path in paths
                    select grabber.TrackByPath(path)).OrderBy(x => x.Title);
        }

        public async Task<IEnumerable<Track>> GetTracksListAsync(IEnumerable<string> paths)
        {
            return await Task.Run(() => GetTracksList(paths));
        }

        public IEnumerable<Artist> GetArtists(IEnumerable<Track> tracks)
        {
            var artists = from track in tracks
                    group track by track.Artist;

            return artists.Select(x => new Artist
            {
                Name = x.Key,
                Tracks = x.ToList(),
            }).OrderBy(x => x.Name);

        }

        public IEnumerable<Album> GetAlbums(IEnumerable<Track> tracks)
        {
            var albums = from track in tracks
                          group track by track.Album;

            return albums.Select(x => new Album
            {
                Name = x.Key,
                Tracks = x.ToList(),
            }).OrderBy(x => x.Name);
        }

        

        public IEnumerable<Playlist> GetPlaylistsList(IEnumerable<string> paths,IEnumerable<Track> tracks)
        {
            CatalogScaner scaner = new CatalogScaner();
            List<string> xmlContent = new List<string>();
            foreach (var path in paths)
            {
                var content = scaner.ScanPlaylistFile(path);
                if(content != null)
                    xmlContent.Add(content);   
            }
            
            return xmlContent.Select(x => Playlist.DeserializeXML(x, tracks));
        }
    }
}
