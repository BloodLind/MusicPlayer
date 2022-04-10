﻿
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.PulseAudio.Tracks.Models
{
    public class Album : ITracksContainer
    {
        public double PlayTime { get; set; }
        public int TracksCount { get => Tracks.Count(); }
        public string Name { get; set; }
        public IEnumerable<Track> Tracks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}