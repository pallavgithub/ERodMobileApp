using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace ERodMobileApp.ViewModels
{
    public class NewOrderUserControlViewModel:ViewModelBase
    {
        private ObservableCollection<string> _pastOrders;
        public ObservableCollection<string> PastOrders
        {
            get => _pastOrders;
            set => SetProperty(ref _pastOrders, value);
        }
        public DelegateCommand StartFromScratchCommand { get; set; }
        public NewOrderUserControlViewModel(INavigationService navigationService):base(navigationService)
        {
            StartFromScratchCommand = new DelegateCommand(GoToNewOrderPage);
            GetPastOrders();
        }
        public void GetPastOrders()
        {
            PastOrders = new ObservableCollection<string>();
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
            PastOrders.Add("GLS-567X");
        }
        public void GoToNewOrderPage()
        {
            NavigationService.NavigateAsync("NewOrderPage");
        }
    }
}
