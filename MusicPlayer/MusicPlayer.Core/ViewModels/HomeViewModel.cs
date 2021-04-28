using MusicPlayer.Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private Track selectedTrack = new Track();
        private TimeSpan currentPosition = new TimeSpan();

        public HomeViewModel()
        {
           
            InitCommands();
        }

        #region Collections
        public MvxObservableCollection<Track> Tracks { get; set; } = new MvxObservableCollection<Track>(CoreApp.Tracks);
        public MvxObservableCollection<Playlist> Playlists { get; set; } = new MvxObservableCollection<Playlist>(CoreApp.Playlists);
        public MvxObservableCollection<Artist> Artists { get; set; } = new MvxObservableCollection<Artist>(CoreApp.Artists);
        public MvxObservableCollection<Album> Albums { get; set; } = new MvxObservableCollection<Album>(CoreApp.Albums);
        public MvxObservableCollection<Track> Queue { get; set; } = new MvxObservableCollection<Track>();
        #endregion

        public Track SelectedTrack
        {
            get => selectedTrack;
            set
            {
                selectedTrack = value;
                RaisePropertyChanged(() => SelectedTrack);
            }
        }

        public TimeSpan CurrentPosition
        {
            get => currentPosition;
            set
            {
                currentPosition = value;
                RaisePropertyChanged(() => CurrentPosition);
            }
        }


        public void InitCommands()
        {
            TrackInfoCommand = new MvxCommand(() =>
            {
                CoreApp.Navigation.MvxNavigationService.Navigate(CoreApp.Navigation.NowPlayingView);
            });
        }

        public IMvxCommand TrackInfoCommand { get; private set; }
    }
}
