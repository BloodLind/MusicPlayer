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
        
        public ArtistsView()
        {
            InitializeComponent();
        }
       
        private void WrapPanel_CleanUpVirtualizedItem(object sender, CleanUpVirtualizedItemEventArgs e)
        {
            Console.WriteLine(e.Value.ToString() + "\t");
            Artist track = e.Value as Artist;
            string key = String.Join("_", track.Tracks.ElementAt(0).Artist, track.Tracks.ElementAt(0).Album);
            if (App.images.IsKeyAvaible(key) == false)
                App.images.RemoveData(key);
        }

        
    }
}
