using MusicPlayer.Core.ViewModels;
using MusicPlayer.WPF.Infrastructure;
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
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : TrackManageView
    {
        private MainViewModel viewModel;

        public MainView()
        {
            InitializeComponent();
            this.Loaded += MainView_Loaded;
            
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (MainViewModel)base.ViewModel;
            viewModel.ShowHome.Execute();
        }
    }
}
