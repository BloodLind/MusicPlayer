using MusicPlayer.PulseAudio.Tracks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Services.Interfaces
{
    public interface IPlaylistParser
    {
        string Serialize(Playlist playlist);
        string Serialize(IEnumerable<Playlist> playlists);

        Playlist Deserialize(string data);

       
    }
}
