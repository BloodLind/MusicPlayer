using MusicPlayer.Core;
using MusicPlayer.Core.Infrastructure.ViewModels;
using MusicPlayer.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MusicPlayer.WPF.Infrastructure
{
    public class TrackManageView : CustomView
    {
        private MusicViewModel viewModel;

        public TrackManageView()
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
