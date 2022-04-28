using MusicPlayer.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.WPF.Services.OSServices
{
    public class WindowsUserInteractionService : IUserInteractionService
    {
        public void OpenBrowser(string url)
        {
            Process.Start(new ProcessStartInfo (url.Replace("&", "^&")) { UseShellExecute = true });
        }

        public void OpenExplorer(string path)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = path
            });
        }
    }
}
