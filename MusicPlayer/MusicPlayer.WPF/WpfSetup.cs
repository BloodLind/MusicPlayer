﻿using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Plugin;
using Serilog;
using Serilog.Extensions.Logging;

namespace MusicPlayer.WPF
{
    public class WpfSetup : MvxWpfSetup<Core.CoreApp>
    {
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