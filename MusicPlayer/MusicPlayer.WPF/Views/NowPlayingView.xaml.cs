using MusicPlayer.Core;
using MusicPlayer.Core.ViewModels;
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
        private bool resized = false;
        NowPlayingViewModel viewModel;
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
            (Application.Current.MainWindow as RootView).ChangeMenuVisibility(Visibility.Visible);
        }

        private void NowPlayingView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (NowPlayingViewModel)DataContext;
            (Parent as RootView).ChangeMenuVisibility(Visibility.Collapsed);
        }

    }
}
