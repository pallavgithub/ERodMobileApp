using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ERodMobileApp.ViewModels
{
    public class OrdersUserControlViewModel : ViewModelBase
    {

        private bool _activeOrderPageIsVisible;
        public bool ActiveOrderPageIsVisible
        {
            get => _activeOrderPageIsVisible;
            set => SetProperty(ref _activeOrderPageIsVisible, value);
        }
        private bool _closedOrderPageIsVisible;
        public bool ClosedOrderPageIsVisible
        {
            get => _closedOrderPageIsVisible;
            set => SetProperty(ref _closedOrderPageIsVisible, value);
        }
        private bool _soListPageIsVisible;
        public bool SoListPageIsVisible
        {
            get => _soListPageIsVisible;
            set => SetProperty(ref _soListPageIsVisible, value);
        }
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }
        private ObservableCollection<SalesOrderDataModel> _activeSalesOrders;
        public ObservableCollection<SalesOrderDataModel> ActiveSalesOrders
        {
            get => _activeSalesOrders;
            set => SetProperty(ref _activeSalesOrders, value);
        }
        private ObservableCollection<SalesOrderDataModel> _closedSalesOrders;
        public ObservableCollection<SalesOrderDataModel> ClosedSalesOrders
        {
            get => _closedSalesOrders;
            set => SetProperty(ref _closedSalesOrders, value);
        }
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
        private string _orderId;
        public string OrderId
        {
            get => _orderId;
            set => SetProperty(ref _orderId, value);
        }
        private string _orderDate;
        public string OrderDate
        {
            get => _orderDate;
            set => SetProperty(ref _orderDate, value);
        }
        private string _deliveryTime;
        public string DeliveryTime
        {
            get => _deliveryTime;
            set => SetProperty(ref _deliveryTime, value);
        }
        private string _truckingCo;
        public string TruckingCo
        {
            get => _truckingCo;
            set => SetProperty(ref _truckingCo, value);
        }
        private string _driverPhn;
        public string DriverPhn
        {
            get => _driverPhn;
            set => SetProperty(ref _driverPhn, value);
        }
        private string _driverName;
        public string DriverName
        {
            get => _driverName;
            set => SetProperty(ref _driverName, value);
        }
        private string _soId;
        public string SoId
        {
            get => _soId;
            set => SetProperty(ref _soId, value);
        }
        private string _wellName;
        public string WellName
        {
            get => _wellName;
            set => SetProperty(ref _wellName, value);
        }
        private string _orderTime;
        public string OrderTime
        {
            get => _orderTime;
            set => SetProperty(ref _orderTime, value);
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
        private string _orderStatus;
        public string OrderStatus
        {
            get => _orderStatus;
            set => SetProperty(ref _orderStatus, value);
        }
        public OrdersUserControlViewModel(INavigationService navigationService) : base(navigationService)
        {
            //SoListPageIsVisible = true;
            GetSalesOrderList();
            //GetAllSalesOrders();
        }
        public async void GetAllSalesOrders()
        {
            IsBusy = true;
            try
            {
                ResponseModel<SalesOrder> response = await new ApiData().GetData<SalesOrder>("api/SalesOrder/GetOrders", true);
                if (response != null)
                {
                    var data = response.data.Orders;
                    Orders = new ObservableCollection<Order>(data);
                }
                IsBusy = false;
            }
            catch (Exception e)
            {

            }
        }
        public void GetSalesOrderList()
        {
            try
            {
                IsBusy = true;
                ActiveSalesOrders = new ObservableCollection<SalesOrderDataModel>();
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-14", OrderTime = "10/18/20", SOId = "SO201084", Status = "Provisional", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-12", OrderTime = "16/18/20", SOId = "SO201084", Status = "Provisional", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-11", OrderTime = "11/18/20", SOId = "SO201084", Status = "Confirmed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-10", OrderTime = "13/18/20", SOId = "SO201084", Status = "Delivered", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-13", OrderTime = "11/18/20", SOId = "SO201084", Status = "Confirmed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-15", OrderTime = "12/18/20", SOId = "SO201084", Status = "Processing", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-16", OrderTime = "12/18/20", SOId = "SO201084", Status = "Processing", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-17", OrderTime = "13/18/20", SOId = "SO201084", Status = "EnRoute", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ActiveSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-18", OrderTime = "14/18/20", SOId = "SO201084", Status = "Delivered", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
             
                foreach (var activeSO in ActiveSalesOrders)
                {
                    activeSO.OrderItems = new List<OrderItem>();
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "66pcs", ProductType = "Sucker Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "69pcs", ProductType = "Sucker Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1/7" + '"' + "SM Fullsize Coupling", Quantity = "40pcs", ProductType = "Sucker Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+6/7" + '"' + "SM Simhole Coupling", Quantity = "23pcs", ProductType = "Sucker Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+7/8" + '"' + "SM Fullsize Coupling", Quantity = "65pcs", ProductType = "Sucker Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "45pcs", ProductType = "Sucker Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "65pcs", ProductType = "Sucker Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "2ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "1pcs", ProductType = "Pony Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "4ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "1pcs", ProductType = "Pony Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "6ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "1pcs", ProductType = "Pony Rod" });
                    activeSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "8ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "1pcs", ProductType = "Pony Rod" });
                }

                ClosedSalesOrders = new ObservableCollection<SalesOrderDataModel>();
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-1", OrderTime = "10/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-2", OrderTime = "16/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-31", OrderTime = "11/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-20", OrderTime = "13/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-4", OrderTime = "11/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-5", OrderTime = "12/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-6", OrderTime = "12/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-7", OrderTime = "13/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                ClosedSalesOrders.Add(new SalesOrderDataModel { OrderID = "Hobbs-WHX-8", OrderTime = "14/18/20", SOId = "SO201084", Status = "Closed", WellName = "Packineau USA 21-3H - Grover 11-3TFH", Customer = "QEP", Phone = "John Doe", Engineer = "534675-6", GlCode = "534675-6", ShippingName = "ND Express Trucking", DeliveryTime = "10/18/20 10AM", DriverName = "Adam Smith", DriverPhone = "406-123-4567" });
                foreach (var closedSO in ClosedSalesOrders)
                {
                    closedSO.OrderItems = new List<OrderItem>();
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "66pcs", ProductType = "Sucker Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "69pcs", ProductType = "Sucker Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1/7" + '"' + "SM Fullsize Coupling", Quantity = "40pcs", ProductType = "Sucker Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+6/7" + '"' + "SM Simhole Coupling", Quantity = "23pcs", ProductType = "Sucker Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+7/8" + '"' + "SM Fullsize Coupling", Quantity = "65pcs", ProductType = "Sucker Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "45pcs", ProductType = "Sucker Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "25ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "65pcs", ProductType = "Sucker Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "2ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "1pcs", ProductType = "Pony Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "4ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "1pcs", ProductType = "Pony Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "6ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "1pcs", ProductType = "Pony Rod" });
                    closedSO.OrderItems.Add(new OrderItem { Name = "EKD 1" + '"' + "8ft", Description = "+1" + '"' + "SM Simhole Coupling", Quantity = "1pcs", ProductType = "Pony Rod" });
                }
                IsBusy = false;
            }
            catch (Exception e)
            {

            }
        }
        public void GetClosedOrderDetails(SalesOrderDataModel so)
        {
            try
            {
                IsBusy = true;
                OrderId = so.OrderID;
                OrderDate = so.OrderTime;
                DeliveryTime = so.DeliveryTime;
                TruckingCo = so.ShippingName;
                DriverName = so.DriverName;
                DriverPhn = so.DriverPhone;
                SoId = so.SOId;
                WellName = so.WellName;
                DeliveryTime = so.DeliveryTime;
                Customer = so.Customer;
                Phone = so.Phone;
                GlCode = so.GlCode;
                SuckerList = new ObservableCollection<OrderItem>();
                PonyList = new ObservableCollection<OrderItem>();
                Couplings = new ObservableCollection<OrderItem>();
                SinkerBar = new ObservableCollection<OrderItem>();
                PolishedRod = new ObservableCollection<OrderItem>();
                StablizerBar = new ObservableCollection<OrderItem>();
                OtherItems = new ObservableCollection<OrderItem>();
                foreach (var item in so.OrderItems)
                {
                    if (item.ProductType == "Sucker Rod")
                        SuckerList.Add(item);
                    else
                        PonyList.Add(item);
                }
                Couplings.Add(new OrderItem {Name="Crossover 1"+'"'+"X 7/8"+'"'+ "SM Slimhole",Quantity="1pcs",ProductType="Couplings" });
                Couplings.Add(new OrderItem { Name = "Crossover 3/4" + '"' + "X 7/8" + '"' + "SM Slimhole", Quantity = "1pcs", ProductType = "Couplings" });
                SinkerBar.Add(new OrderItem {Name="C 1-1/2"+'"'+" 25ft w/ 3/4 pin" , Quantity="15pcs", ProductType = "Sinker" });
                PolishedRod.Add(new OrderItem {Name="Alloy Metal 1-1/2"+'"'+" 26ft 1"+'"'+"pin" , Quantity = "1pcs" , ProductType = "Polished" });
                StablizerBar.Add(new OrderItem { Name = "EHK 1" + '"' + " 4ft 3/4" + '"' + "pin", Quantity = "3pcs", ProductType = "Stablizer" });
                OtherItems.Add(new OrderItem { Name = "Pin Glue", Quantity = "3pcs" , ProductType = "Other" });
                OtherItems.Add(new OrderItem { Name = "Break cleaner", Quantity = "3pcs", ProductType = "Other" });
                OtherItems.Add(new OrderItem { Name = "Rags", Quantity = "3pcs" , ProductType = "Other" });
                IsBusy = false;
            }
            catch (Exception e)
            {
            }

        }
        public void GetActiveOrderDetails(SalesOrderDataModel so)
        {
            try
            {
                IsBusy = true;
                OrderId = so.OrderID;
                OrderDate = so.OrderTime;
                OrderStatus = so.Status;
                DeliveryTime = so.DeliveryTime;
                TruckingCo = so.ShippingName;
                DriverName = so.DriverName;
                DriverPhn = so.DriverPhone;
                SoId = so.SOId;
                WellName = so.WellName;
                DeliveryTime = so.DeliveryTime;
                Customer = so.Customer;
                Phone = so.Phone;
                GlCode = so.GlCode;
                SuckerList = new ObservableCollection<OrderItem>();
                PonyList = new ObservableCollection<OrderItem>();
                Couplings = new ObservableCollection<OrderItem>();
                SinkerBar = new ObservableCollection<OrderItem>();
                PolishedRod = new ObservableCollection<OrderItem>();
                StablizerBar = new ObservableCollection<OrderItem>();
                OtherItems = new ObservableCollection<OrderItem>();
                foreach (var item in so.OrderItems)
                {
                    if (item.ProductType == "Sucker Rod")
                        SuckerList.Add(item);
                    else
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
                IsBusy = false;
            }
            catch (Exception e)
            {

            }
        }
        public void GoToReviewOrderPage(SalesOrderDataModel salesOrder)
        {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("SalesOrder", salesOrder);
            NavigationService.NavigateAsync("ReviewOrderPage", navigationParameters);
        }
    }
}
