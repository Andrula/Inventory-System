using Inventory_System.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Inventory_System.Stores
{
    public class NavigationStore
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set 
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public ViewModelBase _dynamicContent;
        public ViewModelBase DynamicContent
        {
            get => _dynamicContent;
            private set
            {
                _dynamicContent = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
