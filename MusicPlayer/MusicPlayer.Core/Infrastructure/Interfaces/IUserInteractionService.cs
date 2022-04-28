using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface IUserInteractionService
    {
        void OpenExplorer(string path);
        void OpenBrowser(string url);
    }
}
