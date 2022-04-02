using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure;
using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.Core.Infrastructure.ViewModels;
using MusicPlayer.Core.Services;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using MusicPlayer.PulseAudio.Tracks.Services;
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
    public class RootViewModel : MusicViewModel, IMenuViewModel
    {
        #region Fields
        private MvxViewModel currentViewModel;
        private NowPlayingViewModel nowPlayingView;
        private bool isNavigated = false;
        private bool isFirstScanned = false;
        private AppSettings settings;
        #endregion

        public RootViewModel(ILoggerFactory mvxLog, IMvxNavigationService mvxNavigationService)
            : base(mvxLog, mvxNavigationService)
        {
            InitializeCommands();
            CoreApp.FileWatcher.FolderFileRemoved += FileWatcher_FolderFileRemoved;
            settings = Mvx.IoCProvider.Resolve<AppSettings>();
            CoreApp.FileWatcher.AddFolderToWatch(settings.DefaultScanningFolder);
            
        }

        private void FileWatcher_FolderFileRemoved(string filePath)
        {
            Track track = Tracks.FirstOrDefault(x => x.FilePath == filePath);
            if (track == null)
                return;
            if (SelectedTrack == track)
            {
                int index = CoreApp.Player.CurrentTrackIndex + 1;
                SelectedTrack = CoreApp.Player.Queue.ElementAtOrDefault(index >= Tracks.Count ?
                    CoreApp.Player.PlayingQueue[0] : CoreApp.Player.PlayingQueue[index]);
                CoreApp.Player.ChangeCurrentTrack(SelectedTrack);
            }
            CoreApp.Player.RemoveTrackFromQueue(track);

            Playlists.Where(x => x.Tracks.Contains(track)).ToList().
                ForEach(x => x.Tracks.ToList().Remove(track));
        }


        private void InitializeCommands()
        {
            ShowHome = new MvxCommand(() => 
            {
                if (!(currentViewModel is HomeViewModel))
                    NavigationService.Close(currentViewModel);

                CoreApp.Navigation.HomeView.Prepare(Tracks);
                NavigationService.Navigate(CoreApp.Navigation.HomeView);
                currentViewModel = CoreApp.Navigation.HomeView;
            });
            ShowPlaylists = new MvxCommand(() => NavigationService.Navigate(CoreApp.Navigation.PlaylistsViewModel));

            ShowQueue = new MvxCommand(() =>
            {
                currentViewModel = CoreApp.Navigation.QueueViewModel;
                NavigationService.Navigate(currentViewModel);
            });

            TrackNavigationCommand = new MvxCommand(() => 
            {
                nowPlayingView ??= new NowPlayingViewModel(this.LoggerFactory, this.NavigationService);
                if (isNavigated)
                { 
                    this.NavigationService.Close(nowPlayingView);
                    isNavigated = !isNavigated;
                }
                else
                {
                    isNavigated = !isNavigated;
                    nowPlayingView.SelectedTrack = this.SelectedTrack;
                    NavigationService.Navigate(nowPlayingView);
                }
            });
        }

        #region Properties

        #endregion


        #region Methods
        public void UpdateCollections(IEnumerable<string> files)
        {
            TracksManager tracksManager = new TracksManager();
            CollectionsManager.AddToCollection(Tracks, tracksManager.GetTracksList(files));

            CoreApp.InitializatePlayer(Tracks);
            SelectedTrack = (Track)CoreApp.Player.CurrentTrack;
        }

        public override void ViewAppearing()
        {
            base.ViewAppearing();

            if (isFirstScanned)
                return;
            var scanner = Mvx.IoCProvider.Resolve<IFolderScanner>();
            UpdateCollections(scanner.ScanFolder(settings.DefaultScanningFolder));
            isFirstScanned = true;
        }
        #endregion

        #region Commands
        public IMvxCommand TrackNavigationCommand { get; private set; }
        public IMvxCommand ShowMenu { get; private set; }
        public IMvxCommand ShowHome { get; private set; }
        public IMvxCommand ShowPlaylists { get; private set; }
        public IMvxCommand ShowQueue { get; private set; }
        #endregion

        #region Collections
        public MvxObservableCollection<Track> Tracks { get; set; } = new MvxObservableCollection<Track>();
        public MvxObservableCollection<Playlist> Playlists { get; set; } = new MvxObservableCollection<Playlist>();
        #endregion
    }
}
