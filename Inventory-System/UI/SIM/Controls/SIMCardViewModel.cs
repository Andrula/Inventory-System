using Inventory_System.Command;
using Inventory_System.Data.Model.Device.SIM_card;
using Inventory_System.Data.Repositories.SIM;
using Inventory_System.DataAccess.Services.SIMcard;
using Inventory_System.Interfaces.SIMcard.IRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Inventory_System.UI.SIM
{
    public class SIMCardViewModel
    {
        #region Properties
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
        #endregion

        public ICommand CreateNewSIMTypeCommand { get; }

        // Declare _SIMCardTypeService at class level
        private SIMCardTypeService _SIMCardTypeService;
        public SIMCardViewModel()
        {
            // Create an instance of the repository
            ISIMCardTypeRepository simTypeRepository = new SIMTypeRepository();

            // Pass the repository to the service
            _SIMCardTypeService = new SIMCardTypeService(simTypeRepository);


        }
        private Func<Task<IEnumerable<simtype>>> simTypeModelRepositoryFunc { get; set; }
        protected void InitFunctions()
        {
            simTypeModelRepositoryFunc = () => _SIMCardTypeService.GetAllInstancesAsync();
        }
    }
}

