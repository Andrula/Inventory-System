using Inventory_System.Commands;
using Inventory_System.Controls;
using Inventory_System.Features.SIMCard.Views.List;
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
        private readonly NavigationStore _navigationStore;

        public NavigationBarViewModel NavigationBarViewModel { get; }
        public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationStore navigationStore)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;

            // Set the initial view model to SIMCardViewModel
            _navigationStore.CurrentViewModel = new SIMCardViewModel(navigationBarViewModel, navigationStore);
        }

        private void OnCurrentViewModelChanged()
        {
            RaisePropertyChanged(nameof(DynamicContent));
        }

        public ViewModelBase DynamicContent => _navigationStore.CurrentViewModel;
    }
}
