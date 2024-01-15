using Inventory_System.Data.Model.Device.SIM_card;
using Inventory_System.Data.Repositories.SIM;
using Inventory_System.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.UI.Views.SIM.SIMCard.List
{
    public class SIMCardViewModel : ViewModelBase
    {
        // Initiaze repositories
        SIMTypeRepository simTypeRepository = new SIMTypeRepository();

        // Constructor
        public SIMCardViewModel()
        {

        }
        


        // Properties
        private simcard _simCard;
        public simcard SIMCard 
        { 
            get 
            { 
                return _simCard;
            } 
            set { 
                if (_simCard != value)
                {
                    _simCard = value;
                    RaisePropertyChanged("SIMCard");
                }
            }
        }

        private List<simtype> _simTypes; 
        public List<simtype> SIMTypes 
        {
            get 
            {
                return _simTypes;

            }
            set
            {
                if (_simTypes != value) 
                {
                    _simTypes = value;
                    RaisePropertyChanged("SIMTypes");
                }
            }
        }
    }
}
