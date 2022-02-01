using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.PulseAudio.Base
{
    public enum PlaybackState
    {
        /// <summary>Channel is not active</summary>
        Stopped,
        /// <summary>Channel is active and reproducing</summary>
        Playing,
        /// <summary>Channel has not all data to reprodusing</summary>
        Stalled,
        /// <summary>Channel is paused</summary>
        Paused,
    }
}
