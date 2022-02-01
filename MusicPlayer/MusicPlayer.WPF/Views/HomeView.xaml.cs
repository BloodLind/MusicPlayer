using MaterialDesignThemes.Wpf;
using MusicPlayer.Core;
using MusicPlayer.Core.Services;
using MusicPlayer.Core.ViewModels;
using MusicPlayer.WPF.Infrastructure;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
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

namespace MusicPlayer.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для HomeView.xaml
    /// </summary>
    /// 

    [MvxContentPresentation(WindowIdentifier = nameof(RootView))]
    public partial class HomeView : MvxWpfView
    {
        private HomeViewModel viewModel;
        public HomeView()
        {
            InitializeComponent();
            //this.DataContext = CoreApp.Navigation.HomeView;
            this.Loaded += HomeView_Loaded;
        }





        private void HomeView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (HomeViewModel)this.DataContext;
            if (Core.CoreApp.IsScaned)
                return;
            CoreApp.SetScanned();
            ScanMusic();
        }

        private void ScanMusic()
        {
            CatalogScaner catalogScaner = new CatalogScaner();
            List<string> files = new List<string>();
            if (File.Exists("catalogs.jar"))
            {

            }
            else
            {
                //catalogScaner.ScanFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));
                //Change when work on your computer!
                catalogScaner.ScanFolder(@"S:\Music\");
            }


            foreach (var a in catalogScaner.ScannedFiles)
            {
                files.Add(a);
            }

            viewModel.UpdateCollections(files);
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.images.ReleaseData();
        }
    }
}
