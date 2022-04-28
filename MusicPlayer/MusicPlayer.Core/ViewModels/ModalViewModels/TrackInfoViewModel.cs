using Microsoft.Extensions.Logging;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
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

namespace MusicPlayer.Core.ViewModels.ModalViewModels
{
    public class TrackInfoViewModel : MvxNavigationViewModel<Track>
    {
        public TrackInfoViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            CloseCommand = new MvxCommand(() => NavigationService.Close(this));
            EditTagsCommand = new MvxCommand(() => NavigationService.Navigate<EditTagsViewModel, string>(FilePath));
        }

        public override void Prepare(Track parameter)
        {
            var trackInfoGraber = Mvx.IoCProvider.Resolve<ITrackInfoGrabber>();
            AditionalInfo = trackInfoGraber.GetTrackAditionalInfo(parameter.FilePath);
            Info = $"About Track: {AditionalInfo.Codec}, {AditionalInfo.Time} seconds, {AditionalInfo.Frequency}, {AditionalInfo.Bandwith}";
            FilePath = parameter.FilePath;
        }


        #region Properties
        public string FilePath { get; set; }
        public TrackAditionalInfo AditionalInfo { get; set; }
        public string Info { get; set; }
        #endregion

        #region Commands
        public IMvxCommand CloseCommand { get; private set; }
        public IMvxCommand EditTagsCommand { get; private set; }
        #endregion
    }
}
