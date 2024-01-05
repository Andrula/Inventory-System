using Inventory_System.Command;
using Inventory_System.Data.Model.Device.SIM_card;
using Inventory_System.Data.Repositories.SIM;
using Inventory_System.DataAccess.Services.SIMcard;
using Inventory_System.Interfaces.SIMcard.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inventory_System.UI.SIM
{
    public class SIMTypeViewModel
    {
        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _activeFrom;
        public DateTime ActiveFrom
        {
            get { return _activeFrom; }
            set
            {
                if (_activeFrom != value)
                {
                    _activeFrom = value;
                    OnPropertyChanged();
                }
            }
        }

        private DateTime _activeTo;
        public DateTime ActiveTo
        {
            get { return _activeTo; }
            set
            {
                if (_activeTo != value)
                {
                    _activeTo = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand CreateNewSIMTypeCommand { get; }

        // Declare _SIMCardTypeService at class level
        private SIMCardTypeService _SIMCardTypeService;
        public SIMTypeViewModel()
        {
            // Create an instance of the repository
            ISIMCardTypeRepository simTypeRepository = new SIMTypeRepository();

            // Pass the repository to the service
            _SIMCardTypeService = new SIMCardTypeService(simTypeRepository);

            CreateNewSIMTypeCommand = new RelayCommand(CreateNewSIMType, _ => true);
        }

        private async void CreateNewSIMType(object parameter)
        {
            try
            {
                if (parameter is TextBox textBox)
                {
                    // Creates a simtype object based on the values in the TextBox and DatePickers
                    var simTypeParameter = new simtype
                    {
                        type = textBox.Text,
                        active_from = ActiveFrom,
                        active_to = ActiveTo
                    };

                    await _SIMCardTypeService.AddSIMTypeAsync(simTypeParameter);
                }
            }
            catch (InvalidCastException)
            {
                System.Diagnostics.Debug.WriteLine($"Parameter is not of type simtype. Actual type: {parameter?.GetType()}");
                throw new ArgumentException("Parameter is not of type simtype");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An unexpected error occurred: {ex.Message}");
                throw;
            }

        }

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

