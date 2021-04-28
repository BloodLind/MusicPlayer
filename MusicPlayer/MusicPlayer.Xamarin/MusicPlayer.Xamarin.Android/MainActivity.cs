using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Forms.Platforms.Android.Core;
using FFImageLoading.Transformations;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using Android;

namespace MusicPlayer.Xamarin.Droid
{
    [Activity(Label = "MusicPlayer", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<Core.CoreApp, App>, Core.CoreApp, App>
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#1C1C1C"));
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);
            BlurredTransformation.LegacyMode = false;
            AppCompatDelegate.DefaultNightMode = AppCompatDelegate.ModeNightNo;

            if (!ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.ReadExternalStorage) &&
                !ActivityCompat.ShouldShowRequestPermissionRationale(this, Manifest.Permission.WriteExternalStorage))
            {
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.ReadExternalStorage }, 1);
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.WriteExternalStorage }, 2);
            }


            base.OnCreate(bundle);
        }
       
    }
}