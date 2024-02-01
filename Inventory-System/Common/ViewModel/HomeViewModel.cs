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
        private NavigationStore _navigationStore { get; } 
        public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationStore navigationStore)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private ViewModelBase _dynamicContent;
        public ViewModelBase DynamicContent
        {
            get => _dynamicContent;
            private set
            {
                _dynamicContent = value;
                RaisePropertyChanged(nameof(DynamicContent));
            }
        }
        private void OnCurrentViewModelChanged()
        {
            var newContent = _navigationStore.CurrentViewModel;
            if (newContent != this && DynamicContent != newContent)
            {
                DynamicContent = newContent;
            }
        }
    }
}
