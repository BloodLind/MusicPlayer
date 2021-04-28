using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Xamarin.Infrastructure
{
    public interface IConfigurationEditor
    {
        string GetConfigurationData();
        void SetConfigurationData(string data);
    }
}
