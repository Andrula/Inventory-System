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
        public ICommand NavigateSIMCommand { get; }
        public HomeViewModel() 
        {

        }

    }
}
