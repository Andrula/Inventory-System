using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Common.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel {  get; }

        public MainViewModel()
        {
            CurrentViewModel = new HomeViewModel(); 
        }
    }
}
