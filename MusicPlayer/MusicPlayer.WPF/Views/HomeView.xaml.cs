using MaterialDesignThemes.Wpf;
using MusicPlayer.Core;
using MusicPlayer.Core.Models;
using MusicPlayer.Core.Services;
using MusicPlayer.Core.ViewModels;
using MusicPlayer.WPF.Infrastructure;
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
    public partial class HomeView : CustomView
    {
        HomeViewModel viewModel;

        public HomeView()
        {
            
            InitializeComponent();
            this.Loaded += HomeView_Loaded; ;
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (HomeViewModel)this.DataContext;
            ScanMusic();
        }

        private void ScanMusic()
        {
            CatalogScaner catalogScaner = new CatalogScaner();
            List<string> files = new List<string>();
            if(File.Exists("catalogs.jar"))
            {
                
            }
            else
            {
                catalogScaner.ScanFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
            }


            foreach (var a in catalogScaner.ScannedFiles)
            {
                files.Add(a);
            }

            viewModel.UpdateCollections(files);
        }

        protected void ArtistItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var artistItem = ((FrameworkElement)e.OriginalSource).DataContext as Artist;
        }

        protected void CurrentTrackListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var trackItem = ((FrameworkElement)e.OriginalSource).DataContext as Track;

           viewModel.SelectedTrack = trackItem;

            viewModel.PlaySelectedCommand.Execute(this);
        }

        private void PlayPauseClick(object sender, RoutedEventArgs e)
        {
            if(CoreApp.Player.PlaybackState == ManagedBass.PlaybackState.Playing)
            {
                viewModel.PauseCommand.Execute();
            }
            else
            {
                viewModel.PlayCommand.Execute();
            }
        }

        

        void Slider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => viewModel.IsPositionChanging = true;

        void Slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) 
        {
            viewModel.IsPositionChanging = false;
            viewModel.CurrentPosition = ((Slider)sender).Value;
            CoreApp.Player.CurrentPosition = viewModel.CurrentPosition;
        }

        private void Slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e) 
            => viewModel.IsPositionChanging = true;

        private void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            viewModel.IsPositionChanging = false;
            CoreApp.Player.CurrentPosition = viewModel.CurrentPosition;
        }

        
    }
}
