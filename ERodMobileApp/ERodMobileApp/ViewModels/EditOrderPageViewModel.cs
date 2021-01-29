using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;

namespace ERodMobileApp.ViewModels
{
    public class EditOrderPageViewModel : ViewModelBase
    {
        private ObservableCollection<OrderItem> _suckerList;
        public ObservableCollection<OrderItem> SuckerList
        {
            get => _suckerList;
            set => SetProperty(ref _suckerList, value);
        }
        private ObservableCollection<OrderItem> _ponyList;
        public ObservableCollection<OrderItem> PonyList
        {
            get => _ponyList;
            set => SetProperty(ref _ponyList, value);
        }
        private string _suckerListHeight;
        public string SuckerListHeight
        {
            get => _suckerListHeight;
            set => SetProperty(ref _suckerListHeight, value);
        }
        private string _ponyListHeight;
        public string PonyListHeight
        {
            get => _ponyListHeight;
            set => SetProperty(ref _ponyListHeight, value);
        }
        private string _deliveryTime;
        public string DeliveryTime
        {
            get => _deliveryTime;
            set => SetProperty(ref _deliveryTime, value);
        }
        private string _orderId;
        public string OrderId
        {
            get => _orderId;
            set => SetProperty(ref _orderId, value);
        }
        private string _customer;
        public string Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        private string _phone;
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
        private string _glCode;
        public string GlCode
        {
            get => _glCode;
            set => SetProperty(ref _glCode, value);
        }
        public DelegateCommand SaveAndEditLaterBtnCommand { get; set; }
        public DelegateCommand DiscardChangesBtnCommand { get; set; }
        public EditOrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            SaveAndEditLaterBtnCommand = new DelegateCommand(SaveAndEditLater);
            DiscardChangesBtnCommand = new DelegateCommand(DiscardChanges);
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var data = parameters["SalesOrderData"] as SalesOrderDataModel;
            GetData(data);
        }
        public void GetData(SalesOrderDataModel salesOrder)
        {
            OrderId = salesOrder.OrderID;
            DeliveryTime = salesOrder.DeliveryTime;
            Customer = salesOrder.Customer;
            Phone = salesOrder.Phone;
            GlCode = salesOrder.GlCode;
            SuckerList = new ObservableCollection<OrderItem>();
            PonyList = new ObservableCollection<OrderItem>();
            foreach (var item in salesOrder.OrderItems)
            {
                if (item.ProductType == "Sucker Rod")
                    SuckerList.Add(item);
                if (item.ProductType == "Pony Rod")
                    PonyList.Add(item);
            }
            SuckerListHeight = (SuckerList.Count() * 70).ToString();
            PonyListHeight = (PonyList.Count() * 70).ToString();
        }
        public void SaveAndEditLater()
        {
            NavigationService.GoBackAsync();
        }
        public void DiscardChanges()
        {
            NavigationService.GoBackAsync();
        }
    }
}
