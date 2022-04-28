using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
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

namespace MusicPlayer.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для QueueView.xaml
    /// </summary>

    [MvxContentPresentation(WindowIdentifier = nameof(RootView))]
    public partial class QueueView : MvxWpfView
    {
        private long lastDelta = 0;
        public QueueView()
        {
            InitializeComponent();
        }


        private void DockPanel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(e.Delta > 0)
            {
                BigTopBar.Visibility = Visibility.Visible;
                SmallTopBar.Visibility = Visibility.Collapsed;
            }
            else 
            { 
                BigTopBar.Visibility = Visibility.Collapsed;
                SmallTopBar.Visibility = Visibility.Visible;
            }
        }

        private void TracksTable_ContentScrolled(double value)
        {
            if (value == 0)
            {
                BigTopBar.Visibility = Visibility.Visible;
                SmallTopBar.Visibility = Visibility.Collapsed;
                lastDelta = 0;
            }
        }
    }
}
