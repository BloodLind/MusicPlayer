using MusicPlayer.PulseAudio.Base.Audio;
using MusicPlayer.PulseAudio.Base.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.PulseAudio.Base
{

    public interface IPulseAudioBase
    {
        #region PulseAudio Properties
        
        /// <summary>
        /// Indicates show is queue looped in default may be set false
        /// </summary>
        bool IsQueueShuffled { get; set; }
        
        /// <summary>
        /// Volume of tracks reprodusing
        /// </summary>
        double Volume { get; set; }
        
        /// <summary>
        /// Audio output device for reprodusing audio. Before change value resolve current resourses.
        /// </summary>
        IAudioOutput AudioOutput { get; }
        #endregion

        #region Audio reprodusing properties
        /// <summary>
        /// Playing position of current track
        /// </summary>
        double CurrentPosition { get; set; }

        /// <summary>
        /// Current player state
        /// </summary>
        PlaybackState State { get; }
        #endregion

        #region Tracks Properties
        Track CurrentTrack { get; }
        List<Track> Queue { get; }
        List<int> PlayingQueue { get; }
        int CurrentTrackIndex { get; }
        #endregion

        #region Methods


        /// <summary>
        /// Set reproducing queue. Change current track with first element of collection.
        /// </summary>
        /// <param name="tracks">
        /// Collection of tracks that will be reproduced
        /// </param>
        void SetQueue(IEnumerable<Track> tracks);

        void RemoveTrackFromQueue(Track track);
        void AddTrackToQueue(Track track);
        /// <summary>
        /// Shuffle queue list
        /// </summary>
        void ShuffleQueue();

        void Previous();
        void Next();
        void UnshuffleQueue();

        /// <summary>
        /// Changes Playback state to "Playing" and starts reproducing audio
        /// </summary>
        void Play();

        /// <summary>
        /// Changes Playback state to "Paused" and suspends reproducing audio
        /// </summary>
        void Pause();

        /// <summary>
        /// Changes Playback state to "Stopped" and stops reproducing audio
        /// </summary>
        void Stop();

        /// <summary>
        /// Cleans Playing queue and resolves playing files
        /// </summary>
        void CleanupPlayback();

        /// <summary>
        /// Changes current reprodusing track with new one
        /// </summary>
        void ChangeCurrentTrack(Track track);

        /// <summary>
        /// Changes current audio output device. 
        /// Before change will stop audio reproducing and resume playback after the new output has been correctly set.
        /// </summary>
        void ChangeOutputDevice(IAudioOutput output);

        void ChangeLoopState(LoopState state);
        #endregion

        #region Events
        event Action<Track> CurrentTrackChanged;
        event Action<PlaybackState> StateChanged;
        event Action QueueChanged;
        #endregion
    }
}
