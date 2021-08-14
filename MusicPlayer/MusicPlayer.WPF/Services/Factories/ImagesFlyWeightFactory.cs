using MusicPlayer.Core.Services.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MusicPlayer.WPF.Services.Factories
{
    public class ImagesFlyWeightFactory : FlyWeightFactory<string, BitmapImage>
    {
        public override string GetKey(BitmapImage value)
        {
            if (CachedData.ContainsValue(value))
            {
                return (from data in CachedData
                        where data.Value.Equals(value)
                        select data.Key).First();
            }
            return null;
        }
        
        
    }
}
