﻿using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure.ViewModels;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using MusicPlayer.PulseAudio.Tracks.Services;
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
    public class HomeViewModel : MusicViewModel
    {
        #region Fields
        private Artist selectedArtist;
        private Album selectedAlbum;
        private Playlist selecetedPlaylist;
        #endregion

        public HomeViewModel(IMvxNavigationService service, ILoggerFactory mvxLog)
            : base(mvxLog, service)
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

        #region Methods
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
            SelectedTrack = (Track)CoreApp.Player.CurrentTrack;
            CoreApp.Player.CurrentTrackChanged += Player_CurrentTrackChanged;
        }

        private void InitCommands()
        {
            PlaySelectedCommand = new MvxCommand(() =>
            {
                CoreApp.Player.Stop();
                CoreApp.Player.ChangeCurrentTrack(SelectedTrack);
                CoreApp.Player.Play();
                ResetTimer();
            });

        }
        #endregion

        private void AddToCollection<T>(MvxObservableCollection<T> listToAdd, IEnumerable<T> addFrom)
        {
            foreach (var a in addFrom)
            {
                listToAdd.Add(a);
            }
        }

        #region Properties
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
