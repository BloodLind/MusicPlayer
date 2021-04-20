using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface ITrackInfoEditor
    {
        void EditTitle(string title);
        void EditSinger(string singer);
        void EditAlbum(string album);
        void EditTrackImage(byte[] image);
    }
}
