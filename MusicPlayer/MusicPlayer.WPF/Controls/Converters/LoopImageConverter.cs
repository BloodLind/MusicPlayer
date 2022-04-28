using MusicPlayer.PulseAudio.Base;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MusicPlayer.WPF.Controls.Converters
{
    public class LoopImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is LoopState))
                return null;

            switch ((LoopState)value)
            {
                case LoopState.Looped:
                    return App.Current.TryFindResource("Loop");
                case LoopState.LoopedTrack:
                    return App.Current.TryFindResource("LoopTrack");
                case LoopState.NoLoop:
                    return App.Current.TryFindResource("NoLoop");
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
