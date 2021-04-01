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
    public class EditOrderPageViewModel : ViewModelBase
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
        private bool _isFromProductsPage;
        public bool IsFromProductsPage
        {
            get => _isFromProductsPage;
            set => SetProperty(ref _isFromProductsPage, value);
        }
        public SalesOrderModel salesOrderData { get; set; }
        public SalesOrder newSalesOrderData { get; set; }
        public DelegateCommand SaveAndEditLaterBtnCommand { get; set; }
        public DelegateCommand DiscardChangesBtnCommand { get; set; }
        public DelegateCommand ReviewAndSubmitBtnCommand { get; set; }
        public EditOrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            SaveAndEditLaterBtnCommand = new DelegateCommand(SaveAndEditLater);
            DiscardChangesBtnCommand = new DelegateCommand(DiscardChanges);
            ReviewAndSubmitBtnCommand = new DelegateCommand(ReviewAndSubmitOrder);
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("IsFromProductsPage"))
            {
                IsFromProductsPage = (bool)parameters["IsFromProductsPage"];
                var soID = parameters["NewSOId"] as string;
                GetNewSalesOrderData(soID);
            }
            else
            {
                salesOrderData = new SalesOrderModel();
                salesOrderData = parameters["SalesOrderData"] as SalesOrderModel;
                GetData(salesOrderData);
            }
        }
        public void GetData(SalesOrderModel salesOrder)
        {
            IsBusy = true;
            WellName = salesOrder.WellName;
            DeliveryTime = salesOrder.DeliveryDateAndTime;
            Customer = salesOrder.Customer;
            Phone = salesOrder.Phone;
            GlCode = salesOrder.GlCode;
            Contact = salesOrder.Consultant;
            AFE = salesOrder.AFE;
            Note = salesOrder.Note;
            SuckerList = new ObservableCollection<SalesOrderItemModel>();
            PonyList = new ObservableCollection<SalesOrderItemModel>();
            Couplings = new ObservableCollection<SalesOrderItemModel>();
            SinkerBar = new ObservableCollection<SalesOrderItemModel>();
            StablizerBar = new ObservableCollection<SalesOrderItemModel>();
            PolishedRod = new ObservableCollection<SalesOrderItemModel>();
            OtherItems = new ObservableCollection<SalesOrderItemModel>();
            // var soItemsResponse = await new ApiData().GetData<List<SalesOrderItemModel>>("api/salesorder/GetSoItemsById?soid=" + salesOrder.SalesOrderId, true);
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
        public async void GetNewSalesOrderData(string SoId)
        {
            try
            {
                IsBusy = true;
                newSalesOrderData = new SalesOrder();
                newSalesOrderData = await App.Database.GetSalesOrderByIdAsync(SoId);
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
                    Contact = newSalesOrderData.CustomerContact;
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
        public async void SaveAndEditLater()
        {
            SalesOrder localSO = new SalesOrder();
            if (IsFromProductsPage)
            {
                localSO = await App.Database.GetSalesOrderByIdAsync(newSalesOrderData.Num);
            }
            else
            {
                localSO = await App.Database.GetSalesOrderByIdAsync(salesOrderData.SalesOrderId);
            }
            if (localSO != null)
            {
                localSO.Username = Customer;
                localSO.CustomerContact = Contact;
                localSO.Phone = Phone;
                localSO.Note = Note;
                if (localSO.CustomFields != null && localSO.CustomFields.Count > 0)
                {
                    foreach (var cf in localSO.CustomFields)
                    {
                        if (!string.IsNullOrEmpty(cf.Name))
                        {
                            if (cf.Name == "Well Name")
                            {
                                var localWellName = localSO.CustomFields.Where(p => p.Name == "WellName").FirstOrDefault();
                                if (localWellName.Info != WellName)
                                    localWellName.Info = WellName;
                            }
                            else if (cf.Name == "Delivery Time")
                            {
                                var localDeliveryTime = localSO.CustomFields.Where(p => p.Name == "Delivery Time").FirstOrDefault();
                                if (localDeliveryTime.Info != DeliveryTime)
                                    localDeliveryTime.Info = DeliveryTime;
                            }
                            else if (cf.Name == "Engineer/Rig Supervisor")
                            {
                                var localEngineerRigSupervisor = localSO.CustomFields.Where(p => p.Name == "Engineer/Rig Supervisor").FirstOrDefault();
                                if (localEngineerRigSupervisor.Info != Engineer)
                                    localEngineerRigSupervisor.Info = Engineer;
                            }
                            else if (cf.Name == "WBS#/AFE#")
                            {
                                var localAFE = localSO.CustomFields.Where(p => p.Name == "WBS#/AFE#").FirstOrDefault();
                                if (localAFE.Info != AFE)
                                    localAFE.Info = AFE;
                            }
                            else if (cf.Name == "Cost/GL Code")
                            {
                                var localGLCode = localSO.CustomFields.Where(p => p.Name == "Cost/GL Code").FirstOrDefault();
                                if (localGLCode.Info != GlCode)
                                    localGLCode.Info = GlCode;
                            }
                        }
                    }
                    
                   
                }
                if (IsFromProductsPage)
                {
                    localSO.SOItems.Clear();
                    if (newSalesOrderData.SOItems != null && newSalesOrderData.SOItems.Count > 0)
                    {
                        var modified_SOItems = newSalesOrderData.SOItems;
                        localSO.SOItems.AddRange(modified_SOItems);
                    }
                    await App.Database.SaveSalesOrderAsync(localSO);
                    await NavigationService.NavigateAsync("HomePage");
                }
                else
                {
                    localSO.SOItems.Clear();
                    if (salesOrderData.SOItems != null && salesOrderData.SOItems.Count > 0)
                    {
                        var modified_SOItems = salesOrderData.SOItems;
                        localSO.SOItems.AddRange(modified_SOItems);
                    }
                    await App.Database.SaveSalesOrderAsync(localSO);
                    await NavigationService.GoBackAsync();
                }
                //await App.Database.SaveSalesOrderAsync(localSO);
            }
            else
            {

            }

        }
        public void DiscardChanges()
        {
            NavigationService.GoBackAsync();
        }
        public async void ReviewAndSubmitOrder()
        {
            var Toast = DependencyService.Get<IMessage>();
            var result = await App.Database.SaveSalesOrderAsync(newSalesOrderData);
            if (result == 1)
            {
                var navParams = new NavigationParameters();
                navParams.Add("IsFromEditOrderPage", true);
                navParams.Add("NewSOId", newSalesOrderData.Num);
                await NavigationService.NavigateAsync("ReviewOrderPage", navParams);
            }
            else
            {
                Toast.LongAlert("Something went wrong.");
            }
        }
    }
}
