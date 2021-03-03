using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

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
        private ObservableCollection<SalesOrder> _orders;
        public ObservableCollection<SalesOrder> Orders
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


        private ObservableCollection<SalesOrderModel> _activeSalesOrdersList;
        public ObservableCollection<SalesOrderModel> ActiveSalesOrdersList
        {
            get => _activeSalesOrdersList;
            set => SetProperty(ref _activeSalesOrdersList, value);
        }
        private ObservableCollection<SalesOrderModel> _closedSalesOrdersList;
        public ObservableCollection<SalesOrderModel> ClosedSalesOrdersList
        {
            get => _closedSalesOrdersList;
            set => SetProperty(ref _closedSalesOrdersList, value);
        }

        private ObservableCollection<SalesOrderItemModel> _suckerList;
        public ObservableCollection<SalesOrderItemModel> SuckerList
        {
            get => _suckerList;
            set => SetProperty(ref _suckerList, value);
        }
        private ObservableCollection<SalesOrderItemModel> _ponyList;
        public ObservableCollection<SalesOrderItemModel> PonyList
        {
            get => _ponyList;
            set => SetProperty(ref _ponyList, value);
        }
        private ObservableCollection<SalesOrderItemModel> _couplings;
        public ObservableCollection<SalesOrderItemModel> Couplings
        {
            get => _couplings;
            set => SetProperty(ref _couplings, value);
        }
        private ObservableCollection<SalesOrderItemModel> _sinkerBar;
        public ObservableCollection<SalesOrderItemModel> SinkerBar
        {
            get => _sinkerBar;
            set => SetProperty(ref _sinkerBar, value);
        }
        private ObservableCollection<SalesOrderItemModel> _polishedRod;
        public ObservableCollection<SalesOrderItemModel> PolishedRod
        {
            get => _polishedRod;
            set => SetProperty(ref _polishedRod, value);
        }
        private ObservableCollection<SalesOrderItemModel> _stablizerBar;
        public ObservableCollection<SalesOrderItemModel> StablizerBar
        {
            get => _stablizerBar;
            set => SetProperty(ref _stablizerBar, value);
        }
        private ObservableCollection<SalesOrderItemModel> _otherItems;
        public ObservableCollection<SalesOrderItemModel> OtherItems
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
        private string _contact;
        public string Contact
        {
            get => _contact;
            set => SetProperty(ref _contact, value);
        }
        private string _engineer;
        public string Engineer
        {
            get => _engineer;
            set => SetProperty(ref _engineer, value);
        }
        private string _aFE;
        public string AFE
        {
            get => _aFE;
            set => SetProperty(ref _aFE, value);
        }
        private string _note;
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }
        private string _consultant;
        public string Consultant
        {
            get => _consultant;
            set => SetProperty(ref _consultant, value);
        }
        private string _exceedName;
        public string ExceedName
        {
            get => _exceedName;
            set => SetProperty(ref _exceedName, value);
        }
        private string _exceedPhone;
        public string ExceedPhone
        {
            get => _exceedPhone;
            set => SetProperty(ref _exceedPhone, value);
        }
        private string _exceedEmail;
        public string ExceedEmail
        {
            get => _exceedEmail;
            set => SetProperty(ref _exceedEmail, value);
        }
        public string ActiveOrderListHeight { get; set; }
        public string ClosedOrderListHeight { get; set; }
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
        private string _polishedListHeight;
        public string PolishedListHeight
        {
            get => _polishedListHeight;
            set => SetProperty(ref _polishedListHeight, value);
        }
        private string _couplingListHeight;
        public string CouplingListHeight
        {
            get => _couplingListHeight;
            set => SetProperty(ref _couplingListHeight, value);
        }
        private string _sinkerListHeight;
        public string SinkerListHeight
        {
            get => _sinkerListHeight;
            set => SetProperty(ref _sinkerListHeight, value);
        }
        private string _stablizerListHeight;
        public string StablizerListHeight
        {
            get => _stablizerListHeight;
            set => SetProperty(ref _stablizerListHeight, value);
        }
        private string _othersListHeight;
        public string OthersListHeight
        {
            get => _othersListHeight;
            set => SetProperty(ref _othersListHeight, value);
        }
        public DelegateCommand<SalesOrderModel> EditOrderCommand { get; set; }
        public OrdersUserControlViewModel(INavigationService navigationService) : base(navigationService)
        {
            GetExceedDetails();
            GetCustomerSalesOrders();
            EditOrderCommand = new DelegateCommand<SalesOrderModel>(GoToEditOrderPage);
        }
        public async void GetCustomerSalesOrders()
        {
            IsBusy = true;
            var user_data = (UserModel)Application.Current.Properties["User"];
            UserDataModel user = new UserDataModel();
            //user.CompanyName = user_data.Company;
            //user.CustomerName = user_data.Name;
            //user.PhoneNumber = user_data.PhoneNumber;
            //user.UserGroup = user_data.UserGroup;
            //user.DateCreated = string.Empty;
            var names = user_data.Name.Split(' ');
            user.CustomerName = names[0];
            user.UserGroup = user_data.UserGroup;
            ActiveSalesOrdersList = new ObservableCollection<SalesOrderModel>();
            ClosedSalesOrdersList = new ObservableCollection<SalesOrderModel>();
            try
            {
                var response = await new ApiData().PostData<List<SalesOrder>>("api/SalesOrder/GetCustomerOrders", user, true);
                if (response != null && response.data != null)
                {
                    var all_Sales_Orders = response.data;
                    foreach (var item in all_Sales_Orders)
                    {
                        SalesOrderModel salesOrder = new SalesOrderModel();
                        salesOrder.SalesOrderId = item.Num;
                        salesOrder.OrderId = "SO" + item.Num;
                        salesOrder.Status = item.StatusId.ToString();
                        var date = item.DateCreated.ToString().Split(' ');
                        salesOrder.CreatedDateAndTime = date[0];
                        salesOrder.DriverPhone = item.CarrierServiceId;
                        salesOrder.DriverName = item.CarrierServiceId;
                        salesOrder.Phone = item.Phone;
                        salesOrder.Consultant = item.Username;
                        salesOrder.Note = item.Note;
                        salesOrder.Customer = item.Username;
                        salesOrder.Contact = item.CustomerContact;
                        salesOrder.TruckingCo = item.CarrierId;

                        foreach (var cf in item.CustomFields)
                        {
                            if (!string.IsNullOrEmpty(cf.Name))
                            {
                                if (cf.Name == "Well Name")
                                {
                                    salesOrder.WellName = cf.Info;
                                }
                                else if (cf.Name == "Delivery Time")
                                {
                                    salesOrder.DeliveryDateAndTime = cf.Info;
                                }
                                else if (cf.Name == "Engineer/Rig Supervisor")
                                {
                                    salesOrder.Engineer = cf.Info;
                                }
                                else if (cf.Name == "WBS#/AFE#")
                                {
                                    salesOrder.AFE = cf.Info;
                                }
                                else if (cf.Name == "Cost/GL Code")
                                {
                                    salesOrder.GlCode = cf.Info;
                                }
                            }
                        }
                        if (item.CustomFields.Count == 0)
                        {
                            salesOrder.WellName = "No Data";
                            salesOrder.DeliveryDateAndTime = "No Data";
                            salesOrder.Engineer = "No Data";
                            salesOrder.AFE = "No Data";
                        }
                        if (item.StatusId == "10")
                            salesOrder.StatusInDetail = "Provisional";
                        if (item.StatusId == "20")
                            salesOrder.StatusInDetail = "Confirmed";
                        if (item.StatusId == "25")
                            salesOrder.StatusInDetail = "Processing";

                        if (item.StatusId == "25")
                        {
                            foreach (var cf in item.CustomFields)
                            {
                                if (!string.IsNullOrEmpty(cf.Name) && (cf.Name == "CF-Shipped" || cf.Name == "CF-Delivered"))
                                {
                                    if (cf.Name == "CF-Shipped")
                                    {
                                        if (cf.Info == "1")
                                            salesOrder.StatusInDetail = "Shipped";
                                    }
                                    else if (cf.Name == "CF-Delivered")
                                    {
                                        if (cf.Info == "1")
                                            salesOrder.StatusInDetail = "Delivered";
                                    }
                                    else
                                    {
                                        salesOrder.StatusInDetail = "Processing";
                                    }
                                }
                            }

                        }

                        if (item.StatusId == "60")
                        {
                            salesOrder.StatusInDetail = "Closed";
                            ClosedSalesOrdersList.Add(salesOrder);
                        }
                        else
                            ActiveSalesOrdersList.Add(salesOrder);
                    }
                    ActiveOrderListHeight = (ActiveSalesOrdersList.Count * 120).ToString();
                    ClosedOrderListHeight = (ClosedSalesOrdersList.Count * 60).ToString();
                }
            }
            catch (Exception e)
            {

            }
            IsBusy = false;
        }
        public void GoToSignaturePage()
        {
            NavigationService.NavigateAsync("SignaturePage");
        }
        public void GoToEditOrderPage(SalesOrderModel model)
        {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("SalesOrderData", model);
            NavigationService.NavigateAsync("EditOrderPage", navigationParameters);
        }
        public void GetExceedDetails()
        {
            var UserDetails = (UserModel)Application.Current.Properties["User"];
            ExceedName = UserDetails.SalesPersonName;
            ExceedPhone = UserDetails.SalesPersonPhone;
            ExceedEmail = UserDetails.SalesPersonEmail;

        }
        public async void GetClosedOrderDetails(SalesOrderModel so)
        {
            try
            {
                IsBusy = true;
                WellName = so.WellName;
                OrderDate = so.CreatedDateAndTime;
                DeliveryTime = so.DeliveryDateAndTime;
                TruckingCo = so.TruckingCo;
                DriverName = so.DriverName;
                DriverPhn = so.DriverPhone;
                SoId = so.OrderId;
                Customer = so.Customer;
                Phone = so.Phone;
                GlCode = so.GlCode;
                AFE = so.AFE;
                Note = so.Note;
                Contact = so.Contact; ;
                Consultant = so.Consultant;
                Engineer = so.Engineer;
                SuckerList = new ObservableCollection<SalesOrderItemModel>();
                PonyList = new ObservableCollection<SalesOrderItemModel>();
                Couplings = new ObservableCollection<SalesOrderItemModel>();
                SinkerBar = new ObservableCollection<SalesOrderItemModel>();
                PolishedRod = new ObservableCollection<SalesOrderItemModel>();
                StablizerBar = new ObservableCollection<SalesOrderItemModel>();
                OtherItems = new ObservableCollection<SalesOrderItemModel>();
                var soItemsResponse = await new ApiData().GetData<List<SalesOrderItemModel>>("api/salesorder/GetSoItemsById?soid=" + so.SalesOrderId, true);
                if (soItemsResponse != null && soItemsResponse.data != null)
                {
                    foreach (var item in soItemsResponse.data)
                    {
                        if (item.Description.Contains("Sucker"))
                        {
                            SuckerList.Add(item);
                        }
                        else if (item.Description.Contains("Pony"))
                        {
                            PonyList.Add(item);
                        }
                        else if (item.Description.Contains("Coupling"))
                        {
                            Couplings.Add(item);
                        }
                        else if (item.Description.Contains("Polished"))
                        {
                            PolishedRod.Add(item);
                        }
                        else if (item.Description.Contains("Sinker"))
                        {
                            SinkerBar.Add(item);
                        }
                        else if (item.Description.Contains("Stablizer"))
                        {
                            StablizerBar.Add(item);
                        }
                        else
                        {
                            OtherItems.Add(item);
                        }
                    }
                    SuckerListHeight = (SuckerList.Count * 90).ToString();
                    PonyListHeight = (PonyList.Count * 90).ToString();
                    CouplingListHeight = (Couplings.Count * 90).ToString();
                    PolishedListHeight = (PolishedRod.Count * 90).ToString();
                    SinkerListHeight = (SinkerBar.Count * 90).ToString();
                    StablizerListHeight = (StablizerBar.Count * 90).ToString();
                    OthersListHeight = (OtherItems.Count * 90).ToString();
                }
                IsBusy = false;
            }
            catch (Exception e)
            {
            }

        }
        public async void GetActiveOrderDetails(SalesOrderModel so)
        {
            try
            {
                IsBusy = true;
                OrderDate = so.CreatedDateAndTime;
                OrderStatus = so.StatusInDetail;
                DeliveryTime = so.DeliveryDateAndTime;
                TruckingCo = so.TruckingCo;
                DriverName = so.DriverName;
                DriverPhn = so.DriverPhone;
                SoId = so.OrderId;
                WellName = so.WellName;
                Customer = so.Customer;
                Phone = so.Phone;
                GlCode = so.GlCode;
                AFE = so.AFE;
                Note = so.Note;
                Contact = so.Contact;
                Consultant = so.Consultant;
                Engineer = so.Engineer;
                SuckerList = new ObservableCollection<SalesOrderItemModel>();
                PonyList = new ObservableCollection<SalesOrderItemModel>();
                Couplings = new ObservableCollection<SalesOrderItemModel>();
                SinkerBar = new ObservableCollection<SalesOrderItemModel>();
                PolishedRod = new ObservableCollection<SalesOrderItemModel>();
                StablizerBar = new ObservableCollection<SalesOrderItemModel>();
                OtherItems = new ObservableCollection<SalesOrderItemModel>();
                var soItemsResponse = await new ApiData().GetData<List<SalesOrderItemModel>>("api/salesorder/GetSoItemsById?soid=" + so.SalesOrderId, true);
                if (soItemsResponse != null && soItemsResponse.data != null)
                {
                    foreach (var item in soItemsResponse.data)
                    {
                        if (item.Description.Contains("Sucker"))
                        {
                            SuckerList.Add(item);
                        }
                        else if (item.Description.Contains("Pony"))
                        {
                            PonyList.Add(item);
                        }
                        else if (item.Description.Contains("Coupling"))
                        {
                            Couplings.Add(item);
                        }
                        else if (item.Description.Contains("Polished"))
                        {
                            PolishedRod.Add(item);
                        }
                        else if (item.Description.Contains("Sinker"))
                        {
                            SinkerBar.Add(item);
                        }
                        else if (item.Description.Contains("Stablizer"))
                        {
                            StablizerBar.Add(item);
                        }
                        else
                        {
                            OtherItems.Add(item);
                        }
                    }
                    SuckerListHeight = (SuckerList.Count * 90).ToString();
                    PonyListHeight = (PonyList.Count * 90).ToString();
                    CouplingListHeight = (Couplings.Count * 90).ToString();
                    PolishedListHeight = (PolishedRod.Count * 90).ToString();
                    SinkerListHeight = (SinkerBar.Count * 90).ToString();
                    StablizerListHeight = (StablizerBar.Count * 90).ToString();
                    OthersListHeight = (OtherItems.Count * 90).ToString();
                }
                IsBusy = false;
            }
            catch (Exception e)
            {

            }
        }
        public void GoToReviewOrderPage(SalesOrderModel salesOrder)
        {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("SalesOrder", salesOrder);
            NavigationService.NavigateAsync("ReviewOrderPage", navigationParameters);
        }
    }
}
