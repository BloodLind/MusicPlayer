using MaterialDesignThemes.Wpf;
using MusicPlayer.Core;
using MusicPlayer.Core.Services;
using MusicPlayer.Core.ViewModels;
using MusicPlayer.PulseAudio.Tracks.Services;
using MusicPlayer.WPF.Infrastructure;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    /// 

    [MvxContentPresentation(WindowIdentifier = nameof(RootView))]
    public partial class HomeView : MvxWpfView
    {
        public HomeView()
        {
            InitializeComponent();
        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.images.ReleaseData();
        }
    }
}
