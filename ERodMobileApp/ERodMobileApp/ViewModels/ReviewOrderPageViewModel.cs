using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
namespace ERodMobileApp.ViewModels
{
    public class ReviewOrderPageViewModel : ViewModelBase, INavigatedAware
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
        private ObservableCollection<OrderItem> _couplings;
        public ObservableCollection<OrderItem> Couplings
        {
            get => _couplings;
            set => SetProperty(ref _couplings, value);
        }
        private ObservableCollection<OrderItem> _sinkerBar;
        public ObservableCollection<OrderItem> SinkerBar
        {
            get => _sinkerBar;
            set => SetProperty(ref _sinkerBar, value);
        }
        private ObservableCollection<OrderItem> _polishedRod;
        public ObservableCollection<OrderItem> PolishedRod
        {
            get => _polishedRod;
            set => SetProperty(ref _polishedRod, value);
        }
        private ObservableCollection<OrderItem> _stablizerBar;
        public ObservableCollection<OrderItem> StablizerBar
        {
            get => _stablizerBar;
            set => SetProperty(ref _stablizerBar, value);
        }
        private ObservableCollection<OrderItem> _otherItems;
        public ObservableCollection<OrderItem> OtherItems
        {
            get => _otherItems;
            set => SetProperty(ref _otherItems, value);
        }
        private string _deliveryTime;
        public string DeliveryTime
        {
            get => _deliveryTime;
            set => SetProperty(ref _deliveryTime, value);
        }
        private string _wellName;
        public string WellName
        {
            get => _wellName;
            set => SetProperty(ref _wellName, value);
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
        public bool _isAgree;
        public bool IsAgree
        {
            get => _isAgree;
            set => SetProperty(ref _isAgree, value);
        }
        public DelegateCommand CheckBoxCommand { get; set; }
        public DelegateCommand SubmitBtnCommand { get; set; }
        public ReviewOrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            CheckBoxCommand = new DelegateCommand(CheckBoxCheckUncheck);
            SubmitBtnCommand = new DelegateCommand(SubmitBtnClicked);
        }
        public void CheckBoxCheckUncheck()
        {
            IsAgree = !IsAgree;
        }
         public void SubmitBtnClicked()
        {
            NavigationService.GoBackAsync();
        }
        public void GetData(SalesOrderDataModel salesOrder)
        {
            IsBusy = true;
            SuckerList = new ObservableCollection<OrderItem>();
            PonyList = new ObservableCollection<OrderItem>();
            Couplings = new ObservableCollection<OrderItem>();
            SinkerBar = new ObservableCollection<OrderItem>();
            PolishedRod = new ObservableCollection<OrderItem>();
            StablizerBar = new ObservableCollection<OrderItem>();
            OtherItems = new ObservableCollection<OrderItem>();
            foreach (var item in salesOrder.OrderItems)
            {
                if (item.ProductType == "Sucker Rod")
                    SuckerList.Add(item);
                if (item.ProductType == "Pony Rod")
                    PonyList.Add(item);               
            }
            Couplings.Add(new OrderItem { Name = "Crossover 1" + '"' + "X 7/8" + '"' + "SM Slimhole", Quantity = "1pcs", ProductType = "Couplings" });
            Couplings.Add(new OrderItem { Name = "Crossover 3/4" + '"' + "X 7/8" + '"' + "SM Slimhole", Quantity = "1pcs", ProductType = "Couplings" });
            SinkerBar.Add(new OrderItem { Name = "C 1-1/2" + '"' + " 25ft w/ 3/4 pin", Quantity = "15pcs", ProductType = "Sinker" });
            PolishedRod.Add(new OrderItem { Name = "Alloy Metal 1-1/2" + '"' + " 26ft 1" + '"' + "pin", Quantity = "1pcs", ProductType = "Polished" });
            StablizerBar.Add(new OrderItem { Name = "EHK 1" + '"' + " 4ft 3/4" + '"' + "pin", Quantity = "3pcs", ProductType = "Stablizer" });
            OtherItems.Add(new OrderItem { Name = "Pin Glue", Quantity = "3pcs", ProductType = "Other" });
            OtherItems.Add(new OrderItem { Name = "Break cleaner", Quantity = "3pcs", ProductType = "Other" });
            OtherItems.Add(new OrderItem { Name = "Rags", Quantity = "3pcs", ProductType = "Other" });
            WellName = salesOrder.WellName;
            DeliveryTime = salesOrder.DeliveryTime;
            Customer = salesOrder.Customer;
            Phone = salesOrder.Phone;
            GlCode = salesOrder.GlCode;
            IsBusy = false;
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var data = parameters["SalesOrder"] as SalesOrderDataModel;
            GetData(data);
        }
    }
}
