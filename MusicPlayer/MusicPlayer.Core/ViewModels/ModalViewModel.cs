using Microsoft.Extensions.Logging;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Core.ViewModels
{
    public class ModalViewModel : MvxNavigationViewModel<Action<IMvxNavigationService>>
    {
        public ModalViewModel(ILoggerFactory logFactory, IMvxNavigationService navigationService) : base(logFactory, navigationService)
        {
            CloseCommand = new MvxCommand(() => this.NavigationService.Close(this));
           
        }

        #region Commands
        public IMvxCommand CloseCommand { get; private set; }
        public Action<IMvxNavigationService> ShowView { get; private set; }

        public override void ViewAppeared()
        {
            this.ShowView(NavigationService);
            base.ViewAppeared();
        }
        public override void Prepare(Action<IMvxNavigationService> parameter)
        {
            ShowView = parameter;
        }
        
        #endregion
    }
}
