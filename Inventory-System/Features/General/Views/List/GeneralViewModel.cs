using Inventory_System.Command;
using Inventory_System.Commands;
using Inventory_System.Common.ViewModel;
using Inventory_System.Controls;
using Inventory_System.Data.Repositories.SIM;
using Inventory_System.Features.General.Model;
using Inventory_System.Features.General.Repository;
using Inventory_System.Features.SIMCard.Model;
using Inventory_System.Features.SIMCard.Views.List;
using Inventory_System.Services.Navigation;
using Inventory_System.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Inventory_System.Features.General.Views.List
{
    public class GeneralViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        private NavigationStore _navigationStore;
        public ICommand LoadEquipmentCommand { get; }
        public ICommand NavigateSIMCommand { get; }
        public GeneralViewModel(NavigationBarViewModel navigationBarViewModel,NavigationStore navigationStore, NavigationService<SIMCardViewModel> simCardNavigationService )
        {
            NavigationBarViewModel = navigationBarViewModel;
            _navigationStore = navigationStore;

            NavigateSIMCommand = new NavigateCommand<SIMCardViewModel>(simCardNavigationService);

            LoadEquipmentCommand = new RelayCommand(_ => LoadAllInstancesAsync());
            LoadAllInstancesAsync();
        }

        private ObservableCollection<GeneralEquipmentItem> _generalList;
        public ObservableCollection<GeneralEquipmentItem> GeneralList
        {
            get { return _generalList; }
            set
            {
                _generalList = value;
                RaisePropertyChanged(nameof(GeneralList));
            }
        }

        private async void LoadAllInstancesAsync()
        {
            try
            {
                GeneralRepository generalRepository = new GeneralRepository();
                var items = await generalRepository.GetAllEquipmentAsync();

                GeneralList = new ObservableCollection<GeneralEquipmentItem>(items);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
