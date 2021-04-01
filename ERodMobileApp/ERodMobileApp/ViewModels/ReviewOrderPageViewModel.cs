using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace ERodMobileApp.ViewModels
{
    public class ReviewOrderPageViewModel : ViewModelBase, INavigatedAware
    {
        public SalesOrderModel SalesOrder { get; set; }
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
        private string _consultant;
        public string Consultant
        {
            get => _consultant;
            set => SetProperty(ref _consultant, value);
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
        private string _engineer;
        public string Engineer
        {
            get => _engineer;
            set => SetProperty(ref _engineer, value);
        }
        public bool _isAgree;
        public bool IsAgree
        {
            get => _isAgree;
            set => SetProperty(ref _isAgree, value);
        }
        public bool _isFromEditOrderPage;
        public bool IsFromEditOrderPage
        {
            get => _isFromEditOrderPage;
            set => SetProperty(ref _isFromEditOrderPage, value);
        }
        public DelegateCommand CheckBoxCommand { get; set; }
        public DelegateCommand SubmitBtnCommand { get; set; }
        public SalesOrderModel salesOrder { get; set; }
        public SalesOrder newSalesOrderData { get; set; }
        public ReviewOrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            CheckBoxCommand = new DelegateCommand(CheckBoxCheckUncheck);
            SubmitBtnCommand = new DelegateCommand(SubmitBtnClicked);
        }
        public void CheckBoxCheckUncheck()
        {
            IsAgree = !IsAgree;
        }
        public async void SubmitBtnClicked()
        {
            var Toast = DependencyService.Get<IMessage>();
            SalesOrder localSO = new SalesOrder();
            if (IsNotConnected)
            {
                Toast.LongAlert("You are offline.");
                await NavigationService.GoBackAsync();
            }
            else
            {
                var soId = string.Empty;
                if (IsFromEditOrderPage)
                {
                    soId = newSalesOrderData.Num;
                }
                else
                {
                    soId = salesOrder.SalesOrderId;
                }
                localSO = await App.Database.GetSalesOrderByIdAsync(soId);
                if (localSO != null)
                {
                    IsBusy = true;
                    var response = await new ApiData().PostData<string>("api/salesorder/ReviewSubmitOrder", localSO, true);
                    if (response != null && response.status == "Success")
                    {
                        Toast.LongAlert("Order submitted successfully.");
                    }
                    else
                    {
                        Toast.LongAlert(response.message);
                    }
                    IsBusy = false;
                }
                if (IsFromEditOrderPage)
                    await NavigationService.NavigateAsync("HomePage");
                else
                    await NavigationService.GoBackAsync();
            }
        }
        public void GetData(SalesOrderModel salesOrder)
        {
            IsBusy = true;
            SuckerList = new ObservableCollection<SalesOrderItemModel>();
            PonyList = new ObservableCollection<SalesOrderItemModel>();
            Couplings = new ObservableCollection<SalesOrderItemModel>();
            SinkerBar = new ObservableCollection<SalesOrderItemModel>();
            StablizerBar = new ObservableCollection<SalesOrderItemModel>();
            PolishedRod = new ObservableCollection<SalesOrderItemModel>();
            OtherItems = new ObservableCollection<SalesOrderItemModel>();
            WellName = salesOrder.WellName;
            DeliveryTime = salesOrder.DeliveryDateAndTime;
            Customer = salesOrder.Customer;
            Consultant = salesOrder.Consultant;
            Phone = salesOrder.Phone;
            GlCode = salesOrder.GlCode;
            Engineer = salesOrder.Engineer;
            AFE = salesOrder.AFE;
            Note = salesOrder.Note;
            //var soItemsResponse = await new ApiData().GetData<List<SalesOrderItemModel>>("api/salesorder/GetSoItemsById?soid=" + salesOrder.SalesOrderId, true);
            if (salesOrder.SOItems != null && salesOrder.SOItems.Count > 0)
            {
                var salesOrderItems = salesOrder.SOItems;
                foreach (var item in salesOrderItems)
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
            }
            SuckerListHeight = (SuckerList.Count * 90).ToString();
            PonyListHeight = (PonyList.Count * 90).ToString();
            CouplingListHeight = (Couplings.Count * 90).ToString();
            PolishedListHeight = (PolishedRod.Count * 90).ToString();
            SinkerListHeight = (SinkerBar.Count * 90).ToString();
            StablizerListHeight = (StablizerBar.Count * 90).ToString();
            OthersListHeight = (OtherItems.Count * 90).ToString();
            IsBusy = false;
        }
        public async void GetNewSalesOrderData(string SOID)
        {
            try
            {
                IsBusy = true;
                newSalesOrderData = await App.Database.GetSalesOrderByIdAsync(SOID);
                if (newSalesOrderData != null)
                {
                    if (newSalesOrderData.CustomFields != null && newSalesOrderData.CustomFields.Count > 0)
                    {
                        foreach (var cf in newSalesOrderData.CustomFields)
                        {
                            if (!string.IsNullOrEmpty(cf.Name))
                            {
                                if (cf.Name == "Well Name")
                                {
                                    WellName = cf.Info;
                                }
                                else if (cf.Name == "Delivery Time")
                                {
                                    DeliveryTime = cf.Info;
                                }
                                else if (cf.Name == "Engineer/Rig Supervisor")
                                {
                                    Engineer = cf.Info;
                                }
                                else if (cf.Name == "WBS#/AFE#")
                                {
                                    AFE = cf.Info;
                                }
                                else if (cf.Name == "Cost/GL Code")
                                {
                                    GlCode = cf.Info;
                                }
                            }
                        }
                    }
                    Customer = newSalesOrderData.Username;
                    Phone = newSalesOrderData.Phone;
                    Consultant = newSalesOrderData.CustomerContact;
                    Note = newSalesOrderData.Note;
                    SuckerList = new ObservableCollection<SalesOrderItemModel>();
                    PonyList = new ObservableCollection<SalesOrderItemModel>();
                    Couplings = new ObservableCollection<SalesOrderItemModel>();
                    SinkerBar = new ObservableCollection<SalesOrderItemModel>();
                    StablizerBar = new ObservableCollection<SalesOrderItemModel>();
                    PolishedRod = new ObservableCollection<SalesOrderItemModel>();
                    OtherItems = new ObservableCollection<SalesOrderItemModel>();
                    if (newSalesOrderData.SOItems != null && newSalesOrderData.SOItems.Count > 0)
                    {
                        var salesOrderItems = newSalesOrderData.SOItems;
                        foreach (var item in salesOrderItems)
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
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("IsFromEditOrderPage"))
            {
                IsFromEditOrderPage = (bool)parameters["IsFromEditOrderPage"];
                var soID = parameters["NewSOId"] as string;
                GetNewSalesOrderData(soID);
            }
            else
            {
                salesOrder = new SalesOrderModel();
                salesOrder = parameters["SalesOrder"] as SalesOrderModel;
                GetData(salesOrder);
            }
        }
    }
}
