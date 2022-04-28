using Microsoft.Extensions.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels.ModalViewModels
{
    public class EditTagsViewModel : MvxNavigationViewModel<string>
    {
        public EditTagsViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
        }

        public override void Prepare(string parameter)
        {
            throw new NotImplementedException();
        }
    }
}
