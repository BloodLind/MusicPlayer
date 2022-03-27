using MusicPlayer.WPF.Services;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayer.WPF.Views
{
    /// <summary>
    /// Логика взаимодействия для ModalView.xaml
    /// </summary>
    /// 
    [MvxWindowPresentation(Identifier = nameof(ModalView), Modal = true)]
    
    public partial class ModalView : MvxWindow
    {
        [DllImport("user32.dll")]
        internal static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [StructLayout(LayoutKind.Sequential)]
        internal struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }
        internal enum WindowCompositionAttribute
        {
            // ...
            WCA_ACCENT_POLICY = 19
            // ...
        }
        internal enum AccentState
        {
            ACCENT_DISABLED = 0,
            ACCENT_ENABLE_GRADIENT = 1,
            ACCENT_ENABLE_TRANSPARENTGRADIENT = 2,
            ACCENT_ENABLE_BLURBEHIND = 3,
            ACCENT_INVALID_STATE = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct AccentPolicy
        {
            public AccentState AccentState;
            public int AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }
        public ModalView()
        {
            InitializeComponent();
            this.Loaded += ModalView_Loaded;
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = App.Current.MainWindow.Left;
            this.Top = App.Current.MainWindow.Top;
            this.Width = App.Current.MainWindow.ActualWidth;
            this.Height = App.Current.MainWindow.ActualHeight;
        }
        private double ContentWidth { get; set; }
        private double ContentHeight { get; set; }
        private void ModalView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentPresenter contentPresenter = ApplicationVisualTreeHelper.GetVisualChild<ContentPresenter, ModalView>(this);
            var content = contentPresenter.Content as MvxWpfView;
            ContentWidth = content.Width;
            ContentHeight = content.Height;
            EnableBlur();
        }

        internal void EnableBlur()
        {
            var windowHelper = new WindowInteropHelper(this);

            var accent = new AccentPolicy();
            var accentStructSize = Marshal.SizeOf(accent);
            accent.AccentState = AccentState.ACCENT_ENABLE_BLURBEHIND;

            var accentPtr = Marshal.AllocHGlobal(accentStructSize);
            Marshal.StructureToPtr(accent, accentPtr, false);

            var data = new WindowCompositionAttributeData();
            data.Attribute = WindowCompositionAttribute.WCA_ACCENT_POLICY;
            data.SizeOfData = accentStructSize;
            data.Data = accentPtr;

            SetWindowCompositionAttribute(windowHelper.Handle, ref data);

            Marshal.FreeHGlobal(accentPtr);
        }

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double xBounce = (this.ActualWidth - ContentWidth) / 2;
            double yBounce = (this.ActualHeight - ContentHeight) / 2;
            Point position = e.GetPosition(this);
            if (position.X < xBounce || position.X > this.ActualWidth - xBounce ||
                position.Y < yBounce || position.Y > this.ActualHeight - yBounce)
            {
                this.Close();
            }
        }
    }
}
