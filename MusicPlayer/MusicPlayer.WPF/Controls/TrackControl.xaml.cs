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
        public void Slider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => viewModel.IsPositionChanging = true;

        public void Slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            viewModel.IsPositionChanging = false;
            viewModel.CurrentPosition = ((Slider)sender).Value;
            CoreApp.Player.CurrentPosition = viewModel.CurrentPosition;
        }

        public void Slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
            => viewModel.IsPositionChanging = true;

        public void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            viewModel.IsPositionChanging = false;
            CoreApp.Player.CurrentPosition = viewModel.CurrentPosition;
        }

    }
}
