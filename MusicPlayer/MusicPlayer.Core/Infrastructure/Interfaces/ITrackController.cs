using MusicPlayer.Core.Models;
using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.Interfaces
{
    public interface ITrackController
    {
        #region Properties
        Track SelectedTrack { get; set; }
        bool IsPlaying { get; set; }
        double CurrentPosition { get; set; }
        double Volume { get; set; }
        bool IsPositionChanging { get; set; }
        #endregion

        #region Commands
        IMvxCommand ShuffleCommand { get; }
        IMvxCommand RandomCommand { get; }
        IMvxCommand PreviousCommand { get; }
        IMvxCommand NextCommand { get; }
        IMvxCommand PauseCommand { get; }
        IMvxCommand PlayCommand { get; }
        #endregion
    }
}
