using MusicPlayer.Core.Services;
using MusicPlayer.PulseAudio.Base;
using MusicPlayer.PulseAudio.Base.Models;
using MusicPlayer.PulseAudio.Tracks.Models;
using MusicPlayer.PulseAudio.Tracks.Services;
using MusicPlayer.PulseAudio.Tracks.Services.Interfaces;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MusicPlayer.Core
{
    public class CoreApp : MvxApplication
    {
        private static bool isScanned = false;


        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            Mvx.IoCProvider.RegisterType<ITrackInfoGrabber, TrackInfoGrabber>();
            RegisterCustomAppStart<CoreAppInitializer>();

        }

        static CoreApp()
        {
            WorkTimer.Elapsed += WorkTimer_Elapsed;
            WorkTimer.Start();
        }

        #region Static Properties
        public static NavigationPresenter Navigation { get; set; }
        public static Timer WorkTimer { get; } = new Timer(1000);
        public static IPulseAudioBase Player { get; private set; }
        public static bool IsScaned { get => isScanned; }
        #endregion

        #region Static Methods
        private static void WorkTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            TimerElapsed?.Invoke();
        }

        public static void SetScanned()
        {
            isScanned = true;
        }

        public static void InitializatePlayer(IEnumerable<Track> tracks)
        {
            Player ??= Mvx.IoCProvider.Resolve<IPulseAudioBase>();
            if(Player.Queue == null)
            {
                Player.SetQueue(tracks);
                PlayerLoaded?.Invoke();
            } 
        }

        //Remove this after remake file proccessing
        public static bool IsFileLocked(string file)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file);
                using (FileStream stream = fileinfo.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        #endregion


        #region Static Events
        public static event Action PlayerLoaded;
        public static event Action TimerElapsed;
        #endregion
    }
}
