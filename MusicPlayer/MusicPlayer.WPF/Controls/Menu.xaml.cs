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

namespace MusicPlayer.WPF.Controls
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {

        #region DependencyProperties
        public static DependencyProperty MenuExpandedProperty = DependencyProperty.Register(
            nameof(MenuExpanded), typeof(Visibility), typeof(Menu));

        public static DependencyProperty InnerContentProperty = DependencyProperty.Register(
            nameof(InnerContent), typeof(FrameworkElement), typeof(Menu));

        public static DependencyProperty ExpandedWidthProperty = DependencyProperty.Register(
            nameof(ExpandedWidth), typeof(double), typeof(Menu));
        #endregion

        #region Properties
        public Visibility MenuExpanded
        {
            get => (Visibility)GetValue(MenuExpandedProperty);
            set => SetCurrentValue(MenuExpandedProperty, value);
        }

        public FrameworkElement InnerContent
        {
            get => (FrameworkElement)GetValue(InnerContentProperty);
            set => SetCurrentValue(InnerContentProperty, value);
        }

        public double ExpandedWidth
        {
            get => (double)GetValue(ExpandedWidthProperty);
            set => SetCurrentValue(ExpandedWidthProperty, value);
        }
        #endregion
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.MenuExpanded = this.MenuExpanded == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;

        }
    }
}
