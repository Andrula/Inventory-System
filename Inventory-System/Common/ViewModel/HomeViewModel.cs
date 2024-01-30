using Inventory_System.Commands;
using Inventory_System.Controls;
using Inventory_System.Interfaces.SIMcard.IRepository;
using Inventory_System.Stores;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Inventory_System.Common.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationStore navigationStore)
        {
            NavigationBarViewModel = navigationBarViewModel;
        }


   
       
    }
}
