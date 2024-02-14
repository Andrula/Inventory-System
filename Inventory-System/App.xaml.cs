using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Inventory_System.Common.ViewModel;
using Inventory_System.Controls;
using Inventory_System.Features.General.Views.List;
using Inventory_System.Features.SIMCard.Views.List;
using Inventory_System.Services.Navigation;
using Inventory_System.Stores;

namespace Inventory_System
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly NavigationBarViewModel _navigationBarViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _navigationBarViewModel = new NavigationBarViewModel(CreateSIMNavigationService(), CreateGeneralNavigationService());
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            NavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private NavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new NavigationService<HomeViewModel>(
                _navigationStore,
                () => new HomeViewModel(_navigationBarViewModel, _navigationStore,CreateSIMNavigationService()));
        }

        private NavigationService<GeneralViewModel> CreateGeneralNavigationService()
        {
            return new NavigationService<GeneralViewModel> (
                _navigationStore, 
                () => new GeneralViewModel(_navigationBarViewModel,_navigationStore,CreateSIMNavigationService()));
        }

        private NavigationService<SIMCardViewModel> CreateSIMNavigationService()
        {
            return new NavigationService<SIMCardViewModel>(
                _navigationStore,
                () => new SIMCardViewModel(_navigationBarViewModel, _navigationStore));
        }
    }
}
