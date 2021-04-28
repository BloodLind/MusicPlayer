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
        

        public HomeView()
        {
            
            InitializeComponent();
            this.Loaded += HomeView_Loaded; ;
        }

        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
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

            var vm = (HomeViewModel)this.DataContext;

            vm.UpdateCollections(files);
        }

        protected void ArtistItemDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var artistItem = ((FrameworkElement)e.OriginalSource).DataContext as Artist;
        }

        protected void CurrentTrackListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var trackItem = ((FrameworkElement)e.OriginalSource).DataContext as Track;

            ((HomeViewModel)DataContext).SelectedTrack = trackItem;

            ((HomeViewModel)DataContext).PlaySelectedCommand.Execute(this);
        }

        private void PlayPauseClick(object sender, RoutedEventArgs e)
        {
            if(CoreApp.Player.PlaybackState == ManagedBass.PlaybackState.Playing)
            {
                CoreApp.Player.Pause();
            }
            else
            {
                CoreApp.Player.Play();
            }
        }
    }
}
