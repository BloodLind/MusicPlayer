using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.Xamarin.Infrastructure
{
    public interface IFolderBrowser
    {
        void FolderBrowseDialog();
        string FolderPath { get; }
        string RenameDirectory(string oldDirectoryName, string newDirectoryName);
    }
}
