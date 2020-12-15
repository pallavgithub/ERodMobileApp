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
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }
        public OrdersUserControlViewModel(INavigationService navigationService) : base(navigationService)
        {
            GetAllSalesOrders();
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
    }
}
