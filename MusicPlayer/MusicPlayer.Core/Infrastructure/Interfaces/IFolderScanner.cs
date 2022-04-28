using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface IFolderScanner
    {
        IEnumerable<string> ScanFolders(List<string> folders);
        IEnumerable<string> ScanFolder(string folder);
    }
}
