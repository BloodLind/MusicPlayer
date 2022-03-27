using Microsoft.Extensions.Logging;
using MusicPlayer.Core.Infrastructure.Interfaces;
using MusicPlayer.PulseAudio.Base;
using MusicPlayer.WPF.PulseAudio;
using MusicPlayer.WPF.Services.OSServices;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Plugin;
using Serilog;
using Serilog.Extensions.Logging;

namespace MusicPlayer.WPF
{
    public class WpfSetup : MvxWpfSetup<Core.CoreApp>
    {
        protected override IMvxIoCProvider InitializeIoC()
        {
            var ioc = base.InitializeIoC();
            ioc.RegisterType<IPulseAudioBase, WindowsPulseAudio>();
            ioc.RegisterType<IUserInteractionService, WindowsUserInteractionService>();
            return ioc;
        }
        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }

        protected override ILoggerProvider CreateLogProvider()
        {
            return new SerilogLoggerProvider();
        }
        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);

        }
    }
}