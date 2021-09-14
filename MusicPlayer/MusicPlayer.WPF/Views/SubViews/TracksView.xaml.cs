using MusicPlayer.Core.Models;
using MusicPlayer.Core.ViewModels;
using MusicPlayer.WPF.Services;
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

namespace MusicPlayer.WPF.Views.SubViews
{
    /// <summary>
    /// Interaction logic for TracksListView.xaml
    /// </summary>
    public partial class TracksView : UserControl
    {
        
        public TracksView()
        {
            InitializeComponent();
            //App.CacheCollectorTimer.Elapsed += CacheCollectorTimer_Elapsed;
        }

        private void CacheCollectorTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.InvokeAsync(() =>
            {
                if(ViewportHelper.IsItemInViewport(this))
                foreach(Track track in TracksListView.ItemsSource)
                {
                    ListViewItem item = TracksListView.ItemContainerGenerator.ContainerFromItem(track) as ListViewItem;
                    if (!ViewportHelper.IsContainerItemInViewport(item))
                    {
                        string key = String.Join("_", track.Artist, track.Album);
                            if (!App.images.IsKeyAvaible(key))
                            {
                                App.images.RemoveData(key);
                                Console.WriteLine(key);
                            }
                    }
                 }
                
                
            });
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1 && e.GetPosition(this).X <= this.ActualWidth - 10)
            {
                e.Handled = true;
                return;
            }
        }

        private void TracksListView_CleanUpVirtualizedItem(object sender, CleanUpVirtualizedItemEventArgs e)
        {
            Console.WriteLine(e.Value.ToString() + "\t");
            Track track = e.Value as Track;
            string key = String.Join("_", track.Artist, track.Album);
            if(App.images.IsKeyAvaible(key) == false)
                App.images.RemoveData(key);
        }
    }
}
