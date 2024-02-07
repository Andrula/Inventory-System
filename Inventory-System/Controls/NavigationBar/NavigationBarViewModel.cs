using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

// USER DEFINED
using Inventory_System.Commands;
using Inventory_System.Common.ViewModel;
using Inventory_System.Features.General.Views.List;
using Inventory_System.Features.SIMCard.Views.List;
using Inventory_System.Services.Navigation;
using Inventory_System.Stores;

namespace Inventory_System.Controls
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateSIMCommand { get; }
        public ICommand NavigateGeneralCommand { get; }
        public ICommand NavigatePCCommand { get; }
        public ICommand NavigatePhoneCommand { get; }
        public ICommand NavigateTabletCommand { get; }
        public NavigationBarViewModel( NavigationService<SIMCardViewModel> simNavigationService,
            NavigationService<GeneralViewModel> generalNavigationService)
        {
            NavigateSIMCommand = new NavigateCommand<SIMCardViewModel>(simNavigationService);
            NavigateGeneralCommand = new NavigateCommand<GeneralViewModel>(generalNavigationService);

            // NEEDS IMPLEMENTATION 
            //NavigatePCCommand = new NavigatePCCommand<PCViewModel>(PCNavigationService);
            //NavigateTabletCommand = new NavigateTabletCommand<TabletViewModel>(TabletNavigationService);
            //NavigatePhoneCommand = new NavigatePhoneCommand<PhoneViewModel>(PhoneNavigationService);
        }
    }
}
