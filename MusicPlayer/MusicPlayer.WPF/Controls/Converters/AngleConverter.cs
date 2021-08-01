using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MusicPlayer.WPF.Controls.Converters
{
    public class AngleConverter : IValueConverter
    {
        public double Step { get; set; } = 1.8;
        public double Maximum { get; set; } = 180;
        public double Minimum { get; set; } = -180;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int relativeValue = System.Convert.ToInt32(value);
                while (relativeValue > 100) relativeValue /= 10;
                double angle = Step * relativeValue + Minimum;
                return angle >= Maximum ? Maximum : angle <= Minimum ? Minimum : angle;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
