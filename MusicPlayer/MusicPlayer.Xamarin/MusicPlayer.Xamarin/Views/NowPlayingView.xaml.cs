using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FFImageLoading.Transformations;
using System.Drawing;
using System.Reflection;
using System.IO;
using System.Net.Http;
using System.Net;
using MvvmCross.Forms.Presenters.Attributes;

namespace MusicPlayer.Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentationAttribute(WrapInNavigationPage = false, NoHistory = false)]
    public partial class NowPlayingView : MvxContentPage
    {
       
        public NowPlayingView()
        {
            InitializeComponent();
           
        }

        
    }
}