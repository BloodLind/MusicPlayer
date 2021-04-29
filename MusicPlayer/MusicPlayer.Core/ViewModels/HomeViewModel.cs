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
        private double currentPosition;
        private double volume = 0.5;

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

        public Task UpdateCollectionsAsync(IEnumerable<string> files)
        {

            return Task.Run(() =>
            {
                UpdateCollections(files);

            });



        }



        public void UpdateCollections(IEnumerable<string> files)
        {
            TracksManager tracksManager = new TracksManager();
            AddToCollection(Tracks, tracksManager.GetTracksList(files));
            AddToCollection(Artists, tracksManager.GetArtists(Tracks));
            AddToCollection(Albums, tracksManager.GetAlbums(Tracks));
            
            CoreApp.InitializatePlayer(Tracks);
            CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
            CoreApp.Player.PositionChanged += Player_PositionChanged;
        }

        private void Player_PositionChanged(double obj)
        {
            CurrentPosition = obj;
        }

        private void Player_CurrentTrackChanged(Track obj)
        {
            SelectedTrack = obj;
        }

        private void AddToCollection<T>(MvxObservableCollection<T> listToAdd, IEnumerable<T> addFrom)
        {
            foreach (var a in addFrom)
            {
                listToAdd.Add(a);
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

        public double CurrentPosition
        {
            get => currentPosition;
            set
            {
                currentPosition = value;
                RaisePropertyChanged(() => CurrentPosition);
            }
        }
        public double Volume
        {
            get => volume;
            set
            {
                volume = value;

                CoreApp.Player.Volume = value;

                RaisePropertyChanged(() => Volume);
            }
        }


        public void InitCommands()
        {
            TrackInfoCommand = new MvxCommand(() =>
            {
                CoreApp.Navigation.MvxNavigationService.Navigate(CoreApp.Navigation.NowPlayingView);
            });
            PlaySelectedCommand = new MvxCommand(() =>
            {
                CoreApp.Player.ChangeCurrentTrack(SelectedTrack);
            });
            ShuffleCommand = new MvxCommand(() =>
            {
                CoreApp.Player.ShuffleQueue();
                CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[0]);
            });
            RandomCommand = new MvxCommand(() =>
            {
                Random rnd = new Random();
                CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[rnd.Next(0, CoreApp.Player.Queue.Count())]);
            });
            PreviousCommand = new MvxCommand(() =>
            {
                if ((CoreApp.Player.Queue.IndexOf(CoreApp.Player.CurrentTrack) - 1) >= 0)
                {
                    CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[CoreApp.Player.Queue.IndexOf(CoreApp.Player.CurrentTrack) - 1]);
                }
                else
                {
                    CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[0]);
                }

            });
            NextCommand = new MvxCommand(() =>
            {
                if ((CoreApp.Player.Queue.IndexOf(CoreApp.Player.CurrentTrack) + 1) < CoreApp.Player.Queue.Count())
                {
                    CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[CoreApp.Player.Queue.IndexOf(CoreApp.Player.CurrentTrack) + 1]);
                }
                else
                {
                    CoreApp.Player.ChangeCurrentTrack(CoreApp.Player.Queue[CoreApp.Player.Queue.Count() - 1]);
                }
            });
        }

        public IMvxCommand TrackInfoCommand { get; private set; }
        public IMvxCommand PlaySelectedCommand { get; private set; }
        public IMvxCommand ShuffleCommand { get; private set; }
        public IMvxCommand RandomCommand { get; private set; }
        public IMvxCommand PreviousCommand { get; private set; }
        public IMvxCommand NextCommand { get; private set; }
    }
}
