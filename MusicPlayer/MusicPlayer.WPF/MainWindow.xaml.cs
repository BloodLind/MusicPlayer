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

namespace MusicPlayer.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MvxWindow
    {
        public MainWindow()
        {
            AppIssueScan();
            FileInfo[] themes = new DirectoryInfo(System.IO.Path.Combine(Environment.CurrentDirectory, "themes")).GetFiles();
            Uri uri = new Uri(themes[0].FullName, UriKind.Absolute);

           //ResourceDictionary dictionary = Application.LoadComponent(uri) as ResourceDictionary;
           // Application.Current.Resources.MergedDictionaries.Add(dictionary);
            InitializeComponent();

            
        }
        private void AppIssueScan()
        {
            bool isGood = Directory.Exists("themes");
            isGood = isGood | Directory.Exists("themes\\drawable");
            if (!isGood)
            {
                MessageBox.Show("Some directories doesn't exist T_T. Please reinstall app!");
                this.Close();
            }
        }
    }
}
