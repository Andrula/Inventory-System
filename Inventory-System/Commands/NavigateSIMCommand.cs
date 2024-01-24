using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// User defined
using Inventory_System.Stores;
using Inventory_System.Features.SIMCard.Views.List;

namespace Inventory_System.Commands
{
    public class NavigateSIMCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigateSIMCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore.CurrentViewModel = new SIMCardViewModel();
        }
    }
}
