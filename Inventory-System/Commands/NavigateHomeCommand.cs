using Inventory_System.Common.ViewModel;
using Inventory_System.Features.SIMCard.Views.List;
using Inventory_System.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Commands
{
    public class NavigateHomeCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateHomeCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new HomeViewModel();
        }
    }
}
