﻿using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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
        public SalesOrderModel salesOrderData { get; set; }
        public DelegateCommand SaveAndEditLaterBtnCommand { get; set; }
        public DelegateCommand DiscardChangesBtnCommand { get; set; }
        public EditOrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            SaveAndEditLaterBtnCommand = new DelegateCommand(SaveAndEditLater);
            DiscardChangesBtnCommand = new DelegateCommand(DiscardChanges);
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            salesOrderData = new SalesOrderModel();
            salesOrderData = parameters["SalesOrderData"] as SalesOrderModel;
            GetData(salesOrderData);
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
        public async void SaveAndEditLater()
        {
            SalesOrder so = new SalesOrder();
            so = await App.Database.GetSalesOrderByIdAsync(salesOrderData.SalesOrderId);
            if (so != null)
            {
                so.Username = Customer;
                so.CustomerContact = Contact;
                so.Phone = Phone;
                so.Note = Note;
                if (so.CustomFields != null && so.CustomFields.Count > 0)
                {
                    var existing_cf = so.CustomFields;
                    foreach (var cf in salesOrderData.CustomFields)
                    {
                        if (cf.Name == "WellName")
                        {
                            var data = existing_cf.Where(c => c.Name == "WellName").FirstOrDefault();
                            if (cf.Info != data.Info)
                            {
                               CustomDataField cdf = so.CustomFields.Where(x => x.Name == "WellName").FirstOrDefault();
                                
                            }

                        }
                       
                        
                       
                        if (!existing_cf.Contains(cf))
                        {
                            so.CustomFields.Add(new CustomDataField { Name = "WellName", Info = WellName });
                        }
                    }
                }
                else
                {

                }
                if (so.SOItems != null && so.SOItems.Count > 0)
                {
                    var existing_SOItems = so.SOItems;
                    foreach (var item in existing_SOItems)
                    {
                        if (!salesOrderData.SOItems.Contains(item))
                        {
                            so.SOItems.Add(item);
                        }
                    }
                }
                await App.Database.SaveSalesOrderAsync(so);
            }
            else
            {

            }
            NavigationService.GoBackAsync();
        }
        public void DiscardChanges()
        {
            NavigationService.GoBackAsync();
        }
    }
}
