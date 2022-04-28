using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace MusicPlayer.PulseAudio.Base.Models
{
    
    public class Track
    {
        [XmlIgnore]
        public string Title { get; set; }
        [XmlElement(ElementName ="location")]
        public string FilePath { get; set; }
        [XmlIgnore]
        public double PlayTime { get; set; }
        [XmlIgnore]
        public string Artist { get; set; }
        [XmlIgnore]
        public string Album { get; set; }
        [XmlIgnore]
        public string Genre { get; set; }
    }
}
