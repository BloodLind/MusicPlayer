using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.Platforms.Wpf.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MvvmCross.Core;
using System.IO;
using MusicPlayer.Core.Services.Factories;
using System.Windows.Media.Imaging;
using MusicPlayer.WPF.Services.Factories;
using System.Timers;
using System.Windows.Media;

namespace MusicPlayer.WPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : MvxApplication
    {


        public static FlyWeightFactory<string, BitmapImage> images = new ImagesFlyWeightFactory();

        protected override void RegisterSetup()
        {
            this.RegisterSetupType<WpfSetup>();
        }
    }
}
