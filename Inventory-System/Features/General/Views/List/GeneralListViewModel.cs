using Inventory_System.Common.ViewModel;
using Inventory_System.Controls;
using Inventory_System.Data.Repositories.SIM;
using Inventory_System.Features.SIMCard.Model;
using Inventory_System.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_System.Features.General.Views.List
{
    public class GeneralListViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public GeneralListViewModel(NavigationBarViewModel navigationBarViewModel, NavigationStore navigationStore)
        {
            NavigationBarViewModel = navigationBarViewModel;

        }

        private ObservableCollection<simcard> _generalList;
        public ObservableCollection<simcard> GeneralList
        {
            get { return _generalList; }
            set
            {
                _generalList = value;
                RaisePropertyChanged(nameof(GeneralList));
            }
        }
        private async void LoadGeneralList()
        {
            try
            {
                SIMCardRepository simCardRepository = new SIMCardRepository();
                var generalList = await simCardRepository.GetAllInstancesAsync();

                GeneralList = new ObservableCollection<simcard>(simCards);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
