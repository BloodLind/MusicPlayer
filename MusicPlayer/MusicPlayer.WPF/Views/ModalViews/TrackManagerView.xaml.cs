using MusicPlayer.Core.ViewModels.ModalViewModels;
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

namespace MusicPlayer.WPF.Views.ModalViews
{
    /// <summary>
    /// Логика взаимодействия для TrackManagerView.xaml
    /// </summary>
    /// 
    [MvxContentPresentation (WindowIdentifier = nameof(ModalView))]
    public partial class TrackManagerView : MvxWpfView
    {
        public TrackManagerView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows.OfType<ModalView>().FirstOrDefault()?.Close();
        }
    }
}
