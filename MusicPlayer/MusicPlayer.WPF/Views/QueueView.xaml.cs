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
        public QueueView()
        {
            InitializeComponent();
        }


    }
}
