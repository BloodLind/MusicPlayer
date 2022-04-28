using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MusicPlayer.WPF.Services
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is double || value is TimeSpan))
                return Binding.DoNothing;

            var ts = TimeSpan.Zero;

            if (value is double)
            {
                var i = (double)value;

                ts = TimeSpan.FromSeconds(i < 0 ? 0 : i);
            }

            if (value is TimeSpan)
                ts = (TimeSpan)value;

            return ts.Hours == 0
                ? $"{ts.Minutes:D2}:{ts.Seconds:D2}"
                : $"{ts.Hours:D2}:{ts.Minutes:D2}:{ts.Seconds:D2}";


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
    }
}
