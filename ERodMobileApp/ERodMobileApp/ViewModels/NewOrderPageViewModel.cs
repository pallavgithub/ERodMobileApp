using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ERodMobileApp.ViewModels
{
    public class NewOrderPageViewModel : ViewModelBase
    {
        public INavigationService _navigation;
        private string _orderId;
        public string OrderId
        {
            get => _orderId;
            set => SetProperty(ref _orderId, value);
        }
        private string _locationName;
        public string LocationName
        {
            get => _locationName;
            set => SetProperty(ref _locationName, value);
        }
        private string _companyName;
        public string CompanyName
        {
            get => _companyName;
            set => SetProperty(ref _companyName, value);
        }
        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set => SetProperty(ref _customerName, value);
        }
        private string _customerPhone;
        public string CustomerPhone
        {
            get => _customerPhone;
            set => SetProperty(ref _customerPhone, value);
        }
        private string _wellName;
        public string WellName
        {
            get => _wellName;
            set => SetProperty(ref _wellName, value);
        }
        private string _engineer;
        public string Engineer
        {
            get => _engineer;
            set => SetProperty(ref _engineer, value);
        }
        private string _office;
        public string Office
        {
            get => _office;
            set => SetProperty(ref _office, value);
        }
        private string _aFE;
        public string AFE
        {
            get => _aFE;
            set => SetProperty(ref _aFE, value);
        }
        private string _glCode;
        public string GlCode
        {
            get => _glCode;
            set => SetProperty(ref _glCode, value);
        }
        private string _note;
        public string Note
        {
            get => _note;
            set => SetProperty(ref _note, value);
        }

        public NewOrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigation = navigationService;
        }
        public async void CreateNewOrder()
        {
            var Toast = DependencyService.Get<IMessage>();
            var newSalesOrder = new SalesOrder();
            newSalesOrder.Num = RadomNumGenerator.RadomNumber();
            newSalesOrder.LocationGroupId = LocationName;
            newSalesOrder.CustomerContact = CompanyName;
            newSalesOrder.Username = CustomerName;
            newSalesOrder.Phone = CustomerPhone;
            newSalesOrder.Note = Note;
            newSalesOrder.StatusId = "15";//provisional
            newSalesOrder.CustomFields = new List<CustomDataField>()
            {
                new CustomDataField{ RecordId=newSalesOrder.Num ,Name="Engineer/Rig Supervisor", Info=Engineer},
                new CustomDataField{ RecordId=newSalesOrder.Num ,Name="Well Name", Info=WellName},
                new CustomDataField{ RecordId=newSalesOrder.Num ,Name="Billing Office", Info=Office},
                new CustomDataField{ RecordId=newSalesOrder.Num ,Name="Cost/GL Code", Info=GlCode},
                new CustomDataField{ RecordId=newSalesOrder.Num ,Name="WBS#/AFE#", Info=AFE},
                new CustomDataField{ RecordId=newSalesOrder.Num ,Name="Delivery Time", Info=DateTime.Now.ToString()},
            };
            var result = await App.Database.SaveSalesOrderAsync(newSalesOrder);
            if (result == 1)
            {
                var navParams = new NavigationParameters();
                navParams.Add("NewSOId", newSalesOrder.Num);
                await NavigationService.NavigateAsync("ProductsPage", navParams);
            }
            else
            {
                Toast.LongAlert("Something went wrong");
            }
            //var cfResult = await App.Database.SaveCustomFieldsAsync(newSalesOrder.CustomFields);
            //var so = await App.Database.GetSalesOrderByIdAsync(newSalesOrder.Num);
        }
    }
}
