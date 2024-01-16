using Inventory_System.Command;
using Inventory_System.Data.Model.Device.SIM_card;
using Inventory_System.Data.Repositories.SIM;
using Inventory_System.UI.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Inventory_System.UI.Views.SIM.SIMCard.List
{
    public class SIMCardViewModel : ViewModelBase
    {

        // Constructor
        public SIMCardViewModel()
        {
            LoadSimCardsCommand = new RelayCommand(_ => LoadSimCards());
            LoadSimCards();
        }

        private ObservableCollection<simcard> _simcards;
        public ObservableCollection<simcard> SIMCards
        {
            get { return _simcards; }
            set
            {
                _simcards = value;
                RaisePropertyChanged(nameof(SIMCards));
            }
        }

        public ICommand LoadSimCardsCommand { get; }
        // Add other commands as needed

        private async void LoadSimCards()
        {
            try
            {
                SIMCardRepository simCardRepository = new SIMCardRepository();
                var simCards = await simCardRepository.GetAllInstancesAsync();

                SIMCards = new ObservableCollection<simcard>(simCards);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
