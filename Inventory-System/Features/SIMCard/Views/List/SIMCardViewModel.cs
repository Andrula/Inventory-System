// System directives
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

// User directives
using Inventory_System.Command;
using Inventory_System.Commands;
using Inventory_System.Common.ViewModel;
using Inventory_System.Data.Repositories.SIM;
using Inventory_System.Features.SIMCard.Model;
using Inventory_System.Stores;

namespace Inventory_System.Features.SIMCard.Views.List
{
    public class SIMCardViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        // Constructor
        public SIMCardViewModel(NavigationStore navigationStore)
        {
            NavigateHomeCommand = new NavigateHomeCommand(navigationStore);
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
