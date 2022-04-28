using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MusicPlayer.WPF.Controls.Converters
{
    public class ThumbSizeConverter : IValueConverter
    {
        public int ScaleCoficient { get; set; } = 3;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return value == null;
            else
                return (double)value / ScaleCoficient;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
