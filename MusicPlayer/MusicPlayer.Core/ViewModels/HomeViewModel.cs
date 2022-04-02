using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure;
using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Infrastructure.ViewModels;
using MusicPlayer.Core.Services;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using MusicPlayer.PulseAudio.Tracks.Services;
using MusicPlayer.PulseAudio.Tracks.Services.Interfaces;
using MvvmCross;
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
    public class HomeViewModel : MvxNavigationViewModel<MvxObservableCollection<Track>>
    {
        #region Fields
        private Artist selectedArtist;
        private Album selectedAlbum;
        private Playlist selecetedPlaylist;
        private Track selectedTrack;
        private bool isFirstScanned = false;
        #endregion

        public HomeViewModel(IMvxNavigationService service, ILoggerFactory mvxLog)
            : base(mvxLog, service)
        {
            InitCommands();
            CoreApp.FileWatcher.FolderFileCreated += FileWatcher_FolderFileCreated;
            CoreApp.FileWatcher.FolderFileRemoved += FileWatcher_FolderFileRemoved;
        }

        private void FileWatcher_FolderFileRemoved(string filePath)
        {
            Track track = Tracks.FirstOrDefault(x => x.FilePath == filePath);
            if (track == null)
                return;

            Tracks.Remove(track);

            var album = Albums.FirstOrDefault(x => x.Name == track.Album);
            album?.Tracks.ToList().Remove(track);

            if (album?.TracksCount == 0)
                Albums.Remove(album);

            var artist = Artists.FirstOrDefault(x => x.Name == track.Artist);
            artist?.Tracks.ToList().Remove(track);

            if (artist?.TracksCount == 0)
                Artists.Remove(artist);
        }

        private void FileWatcher_FolderFileCreated(string filePath)
        {
            var grabber = Mvx.IoCProvider.Resolve<ITrackInfoGrabber>();
            Track track = null;
            
            try
            {
                track = grabber.TrackByPath(filePath);
            } catch(Exception ex)
            {
                this.Log.LogError(ex.Message);
            }

            if (track == null)
                return;
            
            Tracks.Add(track);
            CoreApp.Player.AddTrackToQueue(track);

            var album = Albums.FirstOrDefault(x => x.Name == track.Album) ?? new Album
            {
                Name = track.Album,
                Tracks = new List<Track>(),
            };
            album.Tracks.ToList().Add(track);

            var artist = Artists.FirstOrDefault(x => x.Name == track.Artist) ?? new Artist
            {
                Name = track.Artist,
                Tracks = new List<Track>()
            };
            artist.Tracks.ToList().Add(track);
        }


        #region Collections
        public MvxObservableCollection<Track> Tracks { get; set; }
        public MvxObservableCollection<Artist> Artists { get; set; } = new MvxObservableCollection<Artist>();
        public MvxObservableCollection<Album> Albums { get; set; } = new MvxObservableCollection<Album>();
        public MvxObservableCollection<Track> Queue { get; set; } = new MvxObservableCollection<Track>();
        #endregion

        #region Methods
        public override void ViewAppearing()
        {
            base.ViewAppearing();
            if (isFirstScanned)
                return;
            UpdateCollections();
            isFirstScanned = true;
        }

        public Task UpdateCollectionsAsync()
        {
            return Task.Run(() =>
            {
                UpdateCollections();
            });
        }

        public void UpdateFolders(IEnumerable<string> folders)
        {
            foreach (var folder in folders)
                CoreApp.FileWatcher.AddFolderToWatch(folder);
        }

        public void UpdateCollections()
        {
            TracksManager tracksManager = new TracksManager();
            CollectionsManager.AddToCollection(Artists, tracksManager.GetArtists(Tracks));
            CollectionsManager.AddToCollection(Albums, tracksManager.GetAlbums(Tracks));
            SelectedTrack = (Track)CoreApp.Player.CurrentTrack;
        }

        private void Player_CurrentTrackChanged(Track obj)
        {
            this.SelectedTrack = obj;
        }

        private void InitCommands()
        {
            PlaySelectedCommand = new MvxCommand(() =>
            {
                CoreApp.Player.Stop();
                CoreApp.Player.ChangeCurrentTrack(SelectedTrack);
                CoreApp.Player.Play();
            });

        }
        #endregion

        public override void Prepare(MvxObservableCollection<Track> parameter)
        {
            if (this.Tracks != null)
                return;
            this.Tracks = parameter;
            UpdateCollections();
            CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
        }

        #region Properties
        public Track SelectedTrack { get => selectedTrack; set { selectedTrack = value; RaisePropertyChanged(() => SelectedTrack); } }
        public Artist SelectedArtist { get => selectedArtist; set { selectedArtist = value; RaisePropertyChanged(() => SelectedArtist); } }
        public Album SelectedAlbum { get => selectedAlbum; set { SelectedAlbum = value; RaisePropertyChanged(() => SelectedAlbum); } }
        public Playlist SelecetedPlaylist { get => selecetedPlaylist; set { SelecetedPlaylist = value; RaisePropertyChanged(() => SelecetedPlaylist); } }
        #endregion

        #region Commands
        public IMvxCommand PlaySelectedCommand { get; private set; }
        public IMvxCommand ShowSelectedPlaylist { get; private set; }
        public IMvxCommand ShowSelectedAlbum { get; private set; }
        public IMvxCommand ShowSelectedArtist { get; private set; }
        #endregion


    }
}
