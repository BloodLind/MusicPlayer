using MusicPlayer.Core.Models;
using MusicPlayer.Core.ViewModels.ModalViewModels;
using MusicPlayer.WPF.Controls;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;
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
        private IMvxInteraction<YesNoQuestion> interaction;

        public IMvxInteraction<YesNoQuestion> Interaction
        {
            get => interaction;
            set
            {
                if (interaction != null)
                    interaction.Requested -= OnInteractionRequested;

                interaction = value;
                interaction.Requested += OnInteractionRequested;
            }
        }

        private async void OnInteractionRequested(object sender, MvxValueEventArgs<YesNoQuestion> e)
        {
            var yesNoQuestion = e.Value;
            DialogWindow dialogWindow = new DialogWindow(yesNoQuestion.Question);
            bool status = dialogWindow.ShowDialog() ?? false;
            yesNoQuestion.YesNoCallback(status);
            if (status)
                Close();
        }

        public TrackManagerView()
        {
            InitializeComponent();
            this.Loaded += TrackManagerView_Loaded;
        }

        private void TrackManagerView_Loaded(object sender, RoutedEventArgs e)
        {
            var set = this.CreateBindingSet<TrackManagerView, TrackManagerViewModel>();
            set.Bind(this).For(view => view.Interaction).To(viewModel => viewModel.ConfiramationInteraction).OneWay();
            set.Apply();
        }

        private void Close()
        {
            Application.Current.Windows.OfType<ModalView>().FirstOrDefault()?.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e) => Close();
    }
}
