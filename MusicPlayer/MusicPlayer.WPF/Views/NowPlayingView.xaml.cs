﻿using MusicPlayer.Core;
using MusicPlayer.Core.ViewModels;
using MusicPlayer.WPF.Infrastructure;
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
    /// Логика взаимодействия для NowPlayingView.xaml
    /// </summary>
    ///
    [MvxContentPresentation(StackNavigation = true, WindowIdentifier =  nameof(RootView))]
    public partial class NowPlayingView : MvxWpfView
    {
        NowPlayingViewModel viewModel;
        public NowPlayingView()
        {
            InitializeComponent();
            this.Loaded += NowPlayingView_Loaded;
        }

        private void NowPlayingView_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (NowPlayingViewModel)DataContext;
        }

        



        void Slider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) { //viewModel.IsPositionChanging = true;
                                                                                        }

        void Slider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //viewModel.IsPositionChanging = false;
            //viewModel.CurrentPosition = ((Slider)sender).Value;
            //CoreApp.Player.CurrentPosition = viewModel.CurrentPosition;
        }

        //private void Slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
          //  => viewModel.IsPositionChanging = true;

        private void Slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            //viewModel.IsPositionChanging = false;
            //CoreApp.Player.CurrentPosition = viewModel.CurrentPosition;
        }

    }
}
