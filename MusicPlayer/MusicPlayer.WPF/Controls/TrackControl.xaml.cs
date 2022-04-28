using MusicPlayer.Core;
using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Infrastructure.ViewModels;
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

namespace MusicPlayer.WPF.Controls
{
    /// <summary>
    /// Логика взаимодействия для TrackControl.xaml
    /// </summary>
    public partial class TrackControl : UserControl
    {

        private MusicViewModel viewModel;

        public TrackControl()
        {
            Loaded += TrackManageView_Loaded;
            InitializeComponent();
            this.AddHandler
            (
                Slider.PreviewMouseDownEvent,
                new MouseButtonEventHandler(Slider_PreviewMouseLeftButtonDown),
                true
            );
            this.AddHandler
            (
                Slider.PreviewMouseUpEvent,
                new MouseButtonEventHandler(Slider_PreviewMouseLeftButtonUp),
                true
            );
        }

        private void TrackManageView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (MusicViewModel)this.DataContext;

        }

        public void PlayPauseClick(object sender, RoutedEventArgs e)
        {
            if (viewModel.IsPlaying)
                viewModel.PauseCommand.Execute();
            else
                viewModel.PlayCommand.Execute();
        }
        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.TrackCover.Visibility = this.TrackCover.Visibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }

        public void Slider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
        {
            if (CheckIsNotTrackSlider(e.GetPosition(this.TrackSlider)))
                return;
            viewModel.IsPositionChanging = true;
        }

        public void Slider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (CheckIsNotTrackSlider(e.GetPosition(this.TrackSlider)) || !viewModel.IsPositionChanging)
                return;
            SetTimeFromSlider();
        }


        private void TrackSlider_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CheckIsNotTrackSlider(e.GetPosition(this.TrackSlider)) || !viewModel.IsPositionChanging)
                return;
            SetTimeFromSlider();
        }
        private void SetTimeFromSlider()
        {
            viewModel.IsPositionChanging = false;
            viewModel.CurrentPosition = this.TrackSlider.Value;
            if (viewModel.CurrentPosition >= viewModel.SelectedTrack.PlayTime)
                viewModel.CurrentPosition = viewModel.SelectedTrack.PlayTime - 1;
            CoreApp.Player.CurrentPosition = viewModel.CurrentPosition;
        }
        private bool CheckIsNotTrackSlider(Point mousePosition)
        {
            return
                mousePosition.X <= 0 ||
                mousePosition.X >= this.TrackSlider.ActualWidth ||
                mousePosition.Y <= 0 ||
                mousePosition.Y >= this.ActualHeight;
        }
    }
}
