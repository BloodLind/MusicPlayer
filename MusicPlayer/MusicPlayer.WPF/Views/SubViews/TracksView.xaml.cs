using MusicPlayer.Core.Models;
using MusicPlayer.Core.ViewModels;
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
    /// Interaction logic for TracksListView.xaml
    /// </summary>
    public partial class TracksView : UserControl
    {
        
        public TracksView()
        {
            InitializeComponent();
        }
        protected void CurrentTrackListDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                var trackItem = ((FrameworkElement)e.OriginalSource).DataContext as Track;
                HomeViewModel viewModel = (HomeViewModel)DataContext;
                viewModel.SelectedTrack = trackItem;
                viewModel.PlaySelectedCommand.Execute(this);
            }
            
        }

        private void Grid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
