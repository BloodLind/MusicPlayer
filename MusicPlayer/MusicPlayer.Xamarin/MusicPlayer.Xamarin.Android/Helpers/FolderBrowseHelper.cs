using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MusicPlayer.Xamarin.Droid.Helpers;
using MusicPlayer.Xamarin.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

    [assembly: Xamarin.Forms.Dependency(typeof(MusicPlayer.Xamarin.Droid.Helpers.FolderBrowseHelper))]
namespace MusicPlayer.Xamarin.Droid.Helpers
{
    public class FolderBrowseHelper : IFolderBrowser
    {
        private string documentBasePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public void FolderBrowseDialog()
        {
            
        }
        public string FolderPath
        {
            get; private set;
        } = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryMusic).Path;

        public string RenameDirectory(string oldDirectoryName, string newDirectoryName)
        {
            var olddirectoryPath = Path.Combine(documentBasePath, oldDirectoryName);
            var newdirectoryPath = Path.Combine(documentBasePath, newDirectoryName);
            if (!Directory.Exists(olddirectoryPath))
            {
                Directory.Move(olddirectoryPath, newdirectoryPath);
            }
            return newdirectoryPath;
        }
}
    }