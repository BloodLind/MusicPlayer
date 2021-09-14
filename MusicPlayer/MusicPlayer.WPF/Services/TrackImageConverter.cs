using MusicPlayer.WPF.Services.Factories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using MusicPlayer.Core.Models;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
using System.Windows;
using MusicPlayer.Core.Services;

namespace MusicPlayer.WPF.Services
{

    public class TrackImageConverter : IMultiValueConverter
    {
        
        private int SCREEN_DPI;
        private double SCREEN_SIZE_COEFICIENT = System.Windows.SystemParameters.PrimaryScreenWidth / 1920;
        private TrackInfoGrabber trackInfoGrabber = new TrackInfoGrabber();

        private void ChangeDecodeOfImage(int dpiSize, BitmapImage image)
        {
            if (dpiSize != 0)
            {
                image.DecodePixelWidth = dpiSize;
                image.DecodePixelHeight = dpiSize;
            }
        }
        private void SetScreenDPI()
        {
            if (Application.Current.MainWindow.IsVisible == true)
            {
                Matrix m = PresentationSource.FromVisual(Application.Current.MainWindow).CompositionTarget.TransformToDevice;
                SCREEN_DPI = (int)(m.M11);
                SCREEN_SIZE_COEFICIENT = System.Windows.SystemParameters.PrimaryScreenWidth * SCREEN_DPI / 1920;
            }
        }
        public TrackImageConverter()
        {
            SetScreenDPI();
        }
        
        public TrackImageConverter(bool isImagesCached)
        {
            this.IsImagesCached = isImagesCached;
            SetScreenDPI();
        }

        public bool IsImagesCached { get; set; } = true;
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int dpiSize = 0;
            
            if (values.Length < 1)
            {
                return null;
            }
            else if (values.Length != 1 && values.ElementAt(1) is int)
                dpiSize = (int)(((int)values[1] + 10)  * SCREEN_SIZE_COEFICIENT) ;

            if (!(values[0] is Track) && values[0] == null)
            {
                return null;
            }
            else
            {
                Track track = values[0] as Track;
                string key = String.Join("_", track.Artist, track.Album);
                BitmapImage image = App.images.GetData(key);
                if (image != null)
                {
                    return image;
                }
                else
                {

                    var byteImage = track.FilePath == null ? null : trackInfoGrabber.GetTrackImage(track.FilePath);
                    if(byteImage == null)
                        return Application.Current.Resources["Cover"];
                    else
                    {
                        try
                        {
                            image = new BitmapImage();
                            image.BeginInit();
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            MemoryStream memoryStream = new MemoryStream(byteImage);
                            image.StreamSource = memoryStream;
                            ChangeDecodeOfImage(dpiSize, image);
                            image.EndInit();

                            if(IsImagesCached)
                                App.images.AddData(key, image);

                            return image;
                        }
                        catch
                        {
                            return Application.Current.Resources["Cover"];
                        }
                    }
                }
                //else
                //{
                //    try
                //    {
                //        image = new BitmapImage();
                //        image.BeginInit();
                //        image.CacheOption = BitmapCacheOption.OnLoad;

                //        MemoryStream memoryStream = new MemoryStream(track.Image);
                //        image.StreamSource = memoryStream;
                //        ChangeDecodeOfImage(dpiSize, image);
                //        image.EndInit();

                //        App.images.AddData(key, image);
                //        return image;
                //    }
                //    catch
                //    {
                //        return Application.Current.Resources["Cover"];
                //    }
                //}
            }
        }

       

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
