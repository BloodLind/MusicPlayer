﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Models
{
    public class Track
    {
        public string Title { get; set; }
        public string FilePath { get; set; }
        public double PlayTime { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
        public byte[] Image { get; set; }
    }
}
