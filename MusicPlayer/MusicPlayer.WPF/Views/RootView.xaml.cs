using MusicPlayer.Core.ViewModels;
using MusicPlayer.WPF.Infrastructure;
using MusicPlayer.WPF.Services;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
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
    /// 

    [MvxWindowPresentation(Identifier = nameof(RootView))]
    public partial class RootView : CustomWindow
    {
        private RootViewModel viewModel;

        public RootView()
        {
            Application.Current.MainWindow = this;
            InitializeComponent();
            this.Loaded += RootView_Loaded;
        }

        private void RootView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (RootViewModel)this.DataContext;
            viewModel.ShowHome.Execute();
        }

        public void ChangeMenuVisibility(Visibility visibility)
        {
            ContentPresenter contentPresenter = ApplicationVisualTreeHelper.GetVisualChild<ContentPresenter, RootView>(this);
            Controls.Menu menu = contentPresenter.ContentTemplate.FindName("Menu", contentPresenter) as Controls.Menu;
            menu.Visibility = visibility;
        }
    }
}
