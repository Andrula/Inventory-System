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

        private UserControl _selectedEquipmentView;
        public UserControl SelectedEquipmentView
        {
            get => _selectedEquipmentView;
            set
            {
                _selectedEquipmentView = value;
                OnSelectedEquipmentViewChanged();
            }
        }

        public event Action CurrentViewModelChanged;
        public event Action SelectedEquipmentViewChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        private void OnSelectedEquipmentViewChanged()
        {
            SelectedEquipmentViewChanged?.Invoke();
        }
    }
}
