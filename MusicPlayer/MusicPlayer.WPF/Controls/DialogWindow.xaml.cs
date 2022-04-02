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
using System.Windows.Shapes;

namespace MusicPlayer.WPF.Controls
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    { 
        
        public DialogWindow(string message)
        {
            this.Message = message;
            InitializeComponent();
        }

        public string Message { get; set; }
        private void Card_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = (sender as Button).Content.ToString() == "Yes";
            this.Close();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
