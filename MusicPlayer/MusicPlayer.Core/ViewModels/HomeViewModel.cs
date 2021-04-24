using MusicPlayer.Core.Models;
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
        private readonly IMvxNavigationService mvxNavigationService;

        public HomeViewModel(IMvxNavigationService mvxNavigationService)
        {
            this.mvxNavigationService = mvxNavigationService;
        }

        private MvxObservableCollection<Track> tracks = new MvxObservableCollection<Track>(CoreApp.Tracks);
        private MvxObservableCollection<Playlist> playlists = new MvxObservableCollection<Playlist>(CoreApp.Playlists);
        private MvxObservableCollection<Artist> artists = new MvxObservableCollection<Artist>(CoreApp.Artists);
        private MvxObservableCollection<Album> albums = new MvxObservableCollection<Album>(CoreApp.Albums);
        private MvxObservableCollection<Track> queue = new MvxObservableCollection<Track>();

        private Track selectedTrack = new Track();
        private TimeSpan currentPosition = new TimeSpan();

        public MvxObservableCollection<Track> Tracks
        {
            get => tracks;
            set
            {
                tracks = value;
            }
        }

        public MvxObservableCollection<Playlist> Playlists
        {
            get => playlists;
            set
            {
                playlists = value;
            }
        }

        public MvxObservableCollection<Artist> Artists
        {
            get => artists;
            set
            {
                artists = value;
            }
        }

        public MvxObservableCollection<Album> Albums
        {
            get => albums;
            set
            {
                albums = value;
            }
        }

        public MvxObservableCollection<Track> Queue
        {
            get => queue;
            set
            {
                queue = value;
            }
        }


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
    }
}
