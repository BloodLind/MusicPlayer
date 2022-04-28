using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.WPF.Services;
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

namespace MusicPlayer.WPF.Views.SubViews
{
    /// <summary>
    /// Логика взаимодействия для TracksTable.xaml
    /// </summary>
    public partial class TracksTable : UserControl
    {

        public TracksTable()
        {
            InitializeComponent();
        }

        public event Action<double> ContentScrolled;

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
            if (App.images.IsKeyAvaible(key) == false)
                App.images.RemoveData(key);
        }

        private void Grid_MouseEnter(object sender, MouseEventArgs e)
        {
            var parent = sender as Grid;
            (parent.FindName("More") as Button).Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeave(object sender, MouseEventArgs e)
        {
            var parent = sender as Grid;
            (parent.FindName("More") as Button).Visibility = Visibility.Hidden;
        }

        private void TracksListView_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            ContentScrolled?.Invoke(e.NewValue);
        }
    }
}
