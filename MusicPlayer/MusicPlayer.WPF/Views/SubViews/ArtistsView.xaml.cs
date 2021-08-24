using MusicPlayer.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MusicPlayer.Core.Models;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer.WPF.Views.SubViews
{
    /// <summary>
    /// Interaction logic for ArtistsView.xaml
    /// </summary>
    public partial class ArtistsView : UserControl
    {
        public bool IsSelectedArtist { get; set; } = false;
        public bool IsSelecredAlbum { get; set; } = false;
        public ArtistsView()
        {
            InitializeComponent();
            //App.CacheCollectorTimer.Elapsed += CacheCollectorTimer_Elapsed;
        }
       
        private void CacheCollectorTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {

            if(ViewportHelper.IsItemInViewport(this))
                foreach (Artist artist in TracksListView.ItemsSource)
                {
                    ListViewItem item = TracksListView.ItemContainerGenerator.ContainerFromItem(artist) as ListViewItem;
                        if (!ViewportHelper.IsContainerItemInViewport(item))
                        {
                            string key = String.Join("_", artist.Name, artist.Tracks[0].Album);
                            if (!App.images.IsKeyAvaible(key))
                            {
                                App.images.RemoveData(key);
                                Console.WriteLine(key);
                            }
                        }
                }
            });
        }
    }
}
