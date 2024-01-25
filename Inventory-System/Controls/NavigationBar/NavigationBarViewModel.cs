using Inventory_System.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Inventory_System.Controls
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private int _selectedEquipmentIndex = 0;

        public int SelectedEquipmentIndex
        {
            get { return _selectedEquipmentIndex; }
            set
            {
                if (_selectedEquipmentIndex != value)
                {
                    _selectedEquipmentIndex = value;
                    RaisePropertyChanged(nameof(SelectedEquipmentIndex));
                }
            }
        }

        // Add a property to get the selected equipment type based on the index
        public string SelectedEquipmentType
        {
            get
            {
                string[] equipmentTypes = { "General", "PC", "Tablet", "Phone", "SIM-Card" };

                if (SelectedEquipmentIndex >= 0 && SelectedEquipmentIndex < equipmentTypes.Length)
                {
                    return equipmentTypes[SelectedEquipmentIndex];
                }

                return "General"; // Default to General if index is out of bounds
            }
        }
    }
}
