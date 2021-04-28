using MusicPlayer.Core.Services;
using MusicPlayer.Core.ViewModels;
using MusicPlayer.Xamarin.Infrastructure;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicPlayer.Xamarin.Views
{
    enum LabelsSize
    {
        Selected = 24,
        Unselected = 18
    }
    [MvxNavigationPagePresentationAttribute()]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : MvxContentPage
    {
        private Label selectedTab;
        private List<Label> labelTabs;

        private void SetUnselectedLabel()
        {
            int unselected = (int)LabelsSize.Unselected;
            queueLabel.FontSize = unselected;
            playlistsLabel.FontSize = unselected;
            albumsLabel.FontSize = unselected;
            artistsLabel.FontSize = unselected;
            tracksLabel.FontSize = unselected;
        }
        public HomeView()
        {
            InitializeComponent();
            selectedTab = tracksLabel;
            selectedTab.FontSize = (int)LabelsSize.Selected;
            labelTabs = new List<Label> { queueLabel, playlistsLabel, tracksLabel, albumsLabel, artistsLabel };
            this.SizeChanged += HomeView_SizeChanged;
            this.Appearing += HomeView_Appearing;
        }

        private async void HomeView_Appearing(object sender, EventArgs e)
        {
           
            IFolderBrowser folderBrowser = DependencyService.Get<IFolderBrowser>();
            CatalogScaner scaner = new CatalogScaner();
            scaner.ScanFolder(folderBrowser.FolderPath);
            ((HomeViewModel)this.DataContext).UpdateCollections(scaner.ScannedFiles);
        }

        private void HomeView_SizeChanged(object sender, EventArgs e)
        {
            labelTabs.Clear();
            labelTabs.Add(queueLabel);
            labelTabs.Add(playlistsLabel);
            labelTabs.Add(tracksLabel);
            labelTabs.Add(albumsLabel);
            labelTabs.Add(artistsLabel);
            SetUnselectedLabel();
            selectedTab = tracksLabel;
            selectedTab.FontSize = (int)LabelsSize.Selected;
           
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var tappedObject = (Label)sender;
            selectedTab = tappedObject;
            SetUnselectedLabel();
            selectedTab.FontSize = (int)LabelsSize.Selected;
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
           int currentIndex = labelTabs.IndexOf(selectedTab);
           if(e.Direction == SwipeDirection.Right)
            {
                selectedTab = currentIndex > 0 ? labelTabs[currentIndex - 1] : selectedTab;
                SetUnselectedLabel();
                selectedTab.FontSize = (int)LabelsSize.Selected;

            }
           else if (e.Direction == SwipeDirection.Left)
            {
                SetUnselectedLabel();
                selectedTab = currentIndex < labelTabs.Count - 1 ? labelTabs[currentIndex + 1] : selectedTab;
                selectedTab.FontSize = (int)LabelsSize.Selected;
            }
        }
         
    }
}