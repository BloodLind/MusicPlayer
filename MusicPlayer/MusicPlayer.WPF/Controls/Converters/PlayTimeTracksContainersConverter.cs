using MusicPlayer.PulseAudio.Tracks.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MusicPlayer.WPF.Controls.Converters
{
    public class PlayTimeTracksContainersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is not ITracksContainer)
                return null;
            var container = (ITracksContainer)value;
            var ts = TimeSpan.FromSeconds((int)container.Tracks?.Sum(x => x.PlayTime));
            return ts.Hours == 0
                ? $"{ts.Minutes:D2}:{ts.Seconds:D2}"
                : $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}"; ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
