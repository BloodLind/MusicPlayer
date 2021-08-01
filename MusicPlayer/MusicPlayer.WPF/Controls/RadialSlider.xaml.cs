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
    /// Логика взаимодействия для RadialSlider.xaml
    /// </summary>
    public partial class RadialSlider : UserControl
    {
        private int pixelsPerStep = 2;
        private Point startPoint;
        private bool isMouseDown = false;

        public RadialSlider()
        {
            Value = 0;
            Maximum = 100;
            Minimum = 0;
            Step = 1;
            InitializeComponent();

            this.GotKeyboardFocus += RadialSlider_GotKeyboardFocus;
            this.LostKeyboardFocus += RadialSlider_LostKeyboardFocus;
        }




        #region Events
        public event RoutedPropertyChangedEventHandler<double> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }
        #endregion


        #region Properties
        public Brush SliderColor
        {
            get => (Brush)GetValue(SliderColorProperty);
            set => SetValue(SliderColorProperty, value);
        }

        public Brush FocusColor
        {
            get => (Brush)GetValue(FocusColorProperty);
            set => SetValue(FocusColorProperty, value);
        }

        public Brush ThumbColor
        {
            get => (Brush)GetValue(ThumbColorProperty);
            set => SetValue(ThumbColorProperty, value);
        }

        public Brush IndicatorColor
        {
            get => (Brush)GetValue(IndicatorColorProperty);
            set => SetValue(IndicatorColorProperty, value);
        }

        public bool IndicatorVisibility
        {
            get => (bool)GetValue(IndicatorVisibilityProperty);
            set => SetValue(IndicatorVisibilityProperty, value);
        }

        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public double Maximum
        {
            get => (double)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public double Minimum
        {
            get => (double)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public double Step
        {
            get => (double)GetValue(StepValueProperty);
            set => SetValue(StepValueProperty, value);
        }

        public int ThumbRadius
        {
            get => (int)GetValue(ThumbRadiusProperty);
            set => SetValue(ThumbRadiusProperty, value);
        }

        public Brush BorderColor
        {
            get => (Brush)GetValue(BroderColorProperty);
            set => SetValue(BorderBrushProperty, value);
        }

        public double Border
        {
            get => (double)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }
        #endregion

        #region Dependency Properties
        public static DependencyProperty FocusColorProperty;
        public static DependencyProperty SliderColorProperty;
        public static DependencyProperty ThumbColorProperty;
        public static DependencyProperty IndicatorVisibilityProperty;
        public static DependencyProperty IndicatorColorProperty;
        public static DependencyProperty ValueProperty;
        public static DependencyProperty MaxValueProperty;
        public static DependencyProperty MinValueProperty;
        public static DependencyProperty StepValueProperty;
        public static DependencyProperty ThumbRadiusProperty;
        public static DependencyProperty BroderColorProperty;
        public static DependencyProperty BroderThicknessProperty;
        #endregion

        #region Dependency Events
        public static RoutedEvent ValueChangedEvent;
        #endregion

        static RadialSlider()
        {
            ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged",
                RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventArgs<double>), typeof(RadialSlider));

            BroderThicknessProperty = DependencyProperty.Register("Border", typeof(double), typeof(RadialSlider));
            BroderColorProperty = DependencyProperty.Register("BorderColor", typeof(Brush), typeof(RadialSlider));
            ThumbRadiusProperty = DependencyProperty.Register("ThumbRadius", typeof(int), typeof(RadialSlider));
            SliderColorProperty = DependencyProperty.Register("SliderColor", typeof(Brush), typeof(RadialSlider));
            ThumbColorProperty = DependencyProperty.Register("ThumbColor", typeof(Brush), typeof(RadialSlider));
            IndicatorColorProperty = DependencyProperty.Register("IndicatorColor", typeof(Brush), typeof(RadialSlider));
            IndicatorVisibilityProperty = DependencyProperty.Register("IndicatorVisibility", typeof(bool), typeof(RadialSlider));
            ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(RadialSlider));
            MaxValueProperty = DependencyProperty.Register("Maximum", typeof(double), typeof(RadialSlider));
            MinValueProperty = DependencyProperty.Register("Minimum", typeof(double), typeof(RadialSlider));
            StepValueProperty = DependencyProperty.Register("Step", typeof(double), typeof(RadialSlider));
        }


        #region Event Handlers
        private void RadialSlider_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.elipse.Stroke = null;
        }

        private void RadialSlider_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            this.elipse.Stroke = FocusColor;
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                double y = startPoint.Y - e.GetPosition(App.Current.MainWindow).Y;

                if (y == pixelsPerStep || y == -1 * pixelsPerStep)
                    startPoint = e.GetPosition(App.Current.MainWindow);
                else
                    return;

                Value += y > 0 ? 1 : -1;
                if (Value > Maximum - 1)
                    Value = Maximum;
                else if (Value < Minimum - 1)
                    Value = Minimum;
            }
        }

        private void AddMouseHandler()
        {
            App.Current.MainWindow.AddHandler(Mouse.MouseUpEvent, new MouseButtonEventHandler(HandleUpOutsideOfControl), true);
            App.Current.MainWindow.AddHandler(Mouse.MouseMoveEvent, new MouseEventHandler(MouseMoveHandler), false);
            App.Current.MainWindow.AddHandler(Mouse.MouseLeaveEvent, new MouseEventHandler(MouseLeaveHandler), false);
        }

        private void MouseLeaveHandler(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            App.Current.MainWindow.ReleaseMouseCapture();
        }

        private void HandleUpOutsideOfControl(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
            App.Current.MainWindow.ReleaseMouseCapture();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddMouseHandler();
            isMouseDown = e.ChangedButton == MouseButton.Right || e.ChangedButton == MouseButton.Left ? true : false;
            if (isMouseDown)
                startPoint = e.GetPosition(App.Current.MainWindow);
        }



        #endregion

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Value += e.Delta > 0 ? 1 : -1;
            if (Value > Maximum - 1)
                Value = Maximum;
            else if (Value < Minimum - 1)
                Value = Minimum;
        }
    }
}
