﻿using Inventory_System.Commands;
using Inventory_System.Controls;
using Inventory_System.Features.General.Views.List;
using Inventory_System.Features.SIMCard.Views.List;
using Inventory_System.Interfaces.SIMcard.IRepository;
using Inventory_System.Stores;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Inventory_System.Common.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        public HomeViewModel(NavigationBarViewModel navigationBarViewModel, NavigationStore navigationStore)
        {
            NavigationBarViewModel = navigationBarViewModel;
            _navigationStore = navigationStore;
            // Set the initial view model to SIMCardViewModel
            _navigationStore.CurrentViewModel = new GeneralViewModel(navigationBarViewModel, navigationStore);
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }
        private void OnCurrentViewModelChanged()
        {
            RaisePropertyChanged(nameof(CurrentViewModel));
        }

    }
}
