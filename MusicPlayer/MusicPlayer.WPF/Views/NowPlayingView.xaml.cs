using MusicPlayer.Core;
using MusicPlayer.Core.ViewModels;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.WPF.Infrastructure;
using MusicPlayer.WPF.Services;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для NowPlayingView.xaml
    /// </summary>
    ///
    [MvxContentPresentation(StackNavigation = true, WindowIdentifier = nameof(RootView))]
    public partial class NowPlayingView : MvxWpfView
    {
        private NowPlayingViewModel viewModel;
        private TrackImageConverter imageConverter = new TrackImageConverter();
        private RootView rootView = App.Current.MainWindow as RootView;
        public NowPlayingView()
        {
            InitializeComponent();
            this.Loaded += NowPlayingView_Loaded;
            this.Unloaded += NowPlayingView_Unloaded;
            this.SizeChanged += NowPlayingView_SizeChanged;
        }

        private void NowPlayingView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           if(this.ActualWidth <= 600)
            {
                this.RightSide.Visibility = Visibility.Collapsed;
                this.LeftSide.HorizontalAlignment = HorizontalAlignment.Center;
            }
           else
            {
                this.RightSide.Visibility = Visibility.Visible;
                this.LeftSide.HorizontalAlignment = HorizontalAlignment.Stretch;
            }
        }

        private void NowPlayingView_Unloaded(object sender, RoutedEventArgs e)
        { 
            rootView.ChangeMenuVisibility(Visibility.Visible);
            rootView.ChangeBackground(App.Current.Resources["Background"] as Brush);
            viewModel.PropertyChanged -= ViewModel_PropertyChanged;
        }

        private void NowPlayingView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (NowPlayingViewModel)DataContext;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            rootView.ChangeMenuVisibility(Visibility.Collapsed);
            ChangeBackground();
            rootView.ChangeBackgroundEffect(new BlurEffect()
            {
                Radius = 75
            });
        }

        private void ChangeBackground()
        {
            var brush = new ImageBrush(
               imageConverter.Convert(new object[] { viewModel.SelectedTrack },
               typeof(ImageSource), null, System.Globalization.CultureInfo.CurrentCulture)
            as ImageSource)
            {
                Stretch = Stretch.UniformToFill
            };
            rootView.ChangeBackground(brush);
        }
        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(viewModel.SelectedTrack))
                ChangeBackground();
        }
    }
}
