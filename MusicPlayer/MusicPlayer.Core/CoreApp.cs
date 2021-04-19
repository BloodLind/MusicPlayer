
using MusicPlayer.Core.ViewModels;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core
{
    public class CoreApp : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<HomeViewModel>();
        }
    }
}
