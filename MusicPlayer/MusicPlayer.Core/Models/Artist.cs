﻿using MusicPlayer.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Models
{
    public class Artist : ITracksContainer
    {
        public double PlayTime { get; set; }
        public int TracksCount { get; set; }
        public string Name { get; set; }
        public IEnumerable<Track> Tracks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
