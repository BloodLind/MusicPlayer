using MusicPlayer.Core.Models;
using MusicPlayer.Core.Services;
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
        public MvxObservableCollection<Track> Tracks { get; set; } = new MvxObservableCollection<Track>();
        public MvxObservableCollection<Playlist> Playlists { get; set; } = new MvxObservableCollection<Playlist>();
        public MvxObservableCollection<Artist> Artists { get; set; } = new MvxObservableCollection<Artist>();
        public MvxObservableCollection<Album> Albums { get; set; } = new MvxObservableCollection<Album>();
        public MvxObservableCollection<Track> Queue { get; set; } = new MvxObservableCollection<Track>();
        #endregion

        public Task UpdateCollectionsAsync(IEnumerable<string>files)
        {
            
            return Task.Run(() =>
            {
                UpdateCollections(files);
                
            });

            

        }
        
        public void UpdateCollections(IEnumerable<string> files)
        {
            TracksManager tracksManager = new TracksManager();

            Tracks.AddRange(tracksManager.GetTracksList(files));
            Artists.AddRange(tracksManager.GetArtists(Tracks));
            Albums.AddRange(tracksManager.GetAlbums(Tracks));


            CoreApp.InitializatePlayer(Tracks);
            CoreApp.Player.Play();
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
