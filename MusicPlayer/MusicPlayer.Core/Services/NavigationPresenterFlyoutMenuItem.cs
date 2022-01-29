using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class NavigationPresenterFlyoutMenuItem
    {
        public NavigationPresenterFlyoutMenuItem()
        {
            TargetType = typeof(NavigationPresenterFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}