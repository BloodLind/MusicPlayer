using MvvmCross.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.Infrastructure.ViewModels
{
    public interface IMenuViewModel
    {
        bool IsMenuExpanded { get; set; }
        IMvxCommand ChangeMenuStatement { get;}
    }
}
