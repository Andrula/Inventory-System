using Inventory_System.Common.ViewModel;
using Inventory_System.Controls;
using Inventory_System.Features.General.Views.List;
using Inventory_System.Features.SIMCard.Views.List;
using Inventory_System.Services.Navigation;
using Inventory_System.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Inventory_System.Common.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        //private readonly NavigationService<SIMCardViewModel> simNavigationService;
        //private readonly NavigationService<GeneralViewModel> generalNavigationService;
        public HomeView()
        {
            InitializeComponent();

            //var navigationStore = new NavigationStore();
            //this.DataContext = new HomeViewModel(navigationBarViewModel, navigationStore);
        }
    }
}
