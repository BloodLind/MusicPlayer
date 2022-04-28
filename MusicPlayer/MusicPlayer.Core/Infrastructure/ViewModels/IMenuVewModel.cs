using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.ViewModels
{
    public interface IMenuViewModel
    {
        IMvxAsyncCommand ShowMenu { get; }
        IMvxAsyncCommand ShowHome { get; }
        IMvxAsyncCommand ShowPlaylists { get; }
    }
}
