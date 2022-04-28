using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MusicPlayer.PulseAudio.Tracks.Models
{
    [XmlRoot(ElementName = "playlist", Namespace = "http://xspf.org/ns/0/", IsNullable = false)]
    public class Playlist : ITracksContainer
    {
        [XmlElement(ElementName = "title")]
        public string Name { get; set; }
        [XmlArray(ElementName ="trackList")]
        [XmlArrayItem(ElementName ="track")]
        public List<Track> Tracks { get; set; }

        [XmlElement(ElementName = "info")]
        public double PlayTime { get => Tracks.Sum(x => x.PlayTime); }
        [XmlIgnore]
        public int TracksCount { get => Tracks.Count();}

        public override string ToString()
        {
            return Name;
        }

        public static Playlist DeserializeXML(string text, IEnumerable<Track> scannedTracks)
        {
            XmlReader reader = XmlReader.Create(new StringReader(text));
            Playlist playlist = new Playlist();
            Type type = playlist.GetType();
            while (reader.Read())
            {
                if(reader.NodeType == XmlNodeType.Element)
                {
                    var property = type.GetProperties().
                        FirstOrDefault(x => x.GetCustomAttributes(true)
                        .Any(attribute =>
                        {
                            var attributeType = attribute.GetType();
                            return attributeType.GetProperty("ElementName")?
                            .GetValue(attribute).ToString() == reader.Name;
                        }));
                    if (property == null)
                        continue;

                    if (property.Name == nameof(Tracks))
                    {
                        var subtree = reader.ReadSubtree();
                        var tracks = new List<Track>();
                        while(subtree.Read())
                        {
                            if (subtree.NodeType != XmlNodeType.Text)
                                continue;
                            string content = System.Web.HttpUtility.UrlDecode(subtree.Value);
                            var track = scannedTracks.FirstOrDefault (x => x.FilePath == content);
                            if(track != null)
                                tracks.Add(track);
                        }
                        playlist.Tracks = tracks;
                    }
                    else
                    {
                        property.SetValue(playlist, TypeDescriptor.GetConverter(property.PropertyType)
                            .ConvertFromString(System.Web.HttpUtility.UrlDecode(reader.ReadInnerXml())));
                    }
                }
            }
            return playlist;
        }
    }
}
