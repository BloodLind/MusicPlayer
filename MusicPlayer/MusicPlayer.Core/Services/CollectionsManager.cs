using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Services
{
    public class CollectionsManager
    {
        public static void AddToCollection<T>(MvxObservableCollection<T> listToAdd, IEnumerable<T> addFrom)
        {
            foreach (var a in addFrom)
            {
                listToAdd.Add(a);
            }
        }
    }
}
