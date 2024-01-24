using Inventory_System.Commands;
using Inventory_System.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inventory_System.Common.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ICommand NavigateSIMCommand { get; }
        public HomeViewModel(NavigationStore navigationStore) 
        {
            _navigationStore = navigationStore;
            NavigateSIMCommand = new NavigateSIMCommand(_navigationStore);
        }

    }
}
