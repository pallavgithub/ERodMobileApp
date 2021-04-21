using ERodMobileApp.Models;
using ERodMobileApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrdersUserControl : ContentView
    {
        public OrdersUserControl()
        {
            InitializeComponent();
            (BindingContext as OrdersUserControlViewModel).SoListPageIsVisible = true;
            (BindingContext as OrdersUserControlViewModel).GetCustomerSalesOrders();
        }
        private void ClosedOrderDetails_Tapped(object sender, EventArgs e)
        {
            (BindingContext as OrdersUserControlViewModel).SoListPageIsVisible = false;
            (BindingContext as OrdersUserControlViewModel).ClosedOrderPageIsVisible = true;
            SalesOrderModel salesOrder = (((TappedEventArgs)e).Parameter) as SalesOrderModel;
            (BindingContext as OrdersUserControlViewModel).GetClosedOrderDetails(salesOrder);
        }
        private void ActiveOrderDetails_Tapped(object sender, EventArgs e)
        {
            (BindingContext as OrdersUserControlViewModel).SoListPageIsVisible = false;
            (BindingContext as OrdersUserControlViewModel).ActiveOrderPageIsVisible = true;
            SalesOrderModel salesOrder = (((TappedEventArgs)e).Parameter) as SalesOrderModel;
            (BindingContext as OrdersUserControlViewModel).GetActiveOrderDetails(salesOrder);
        }
        private void ClosedOrderToList_Clicked(object sender, EventArgs e)
        {
            (BindingContext as OrdersUserControlViewModel).ClosedOrderPageIsVisible = false;
            (BindingContext as OrdersUserControlViewModel).SoListPageIsVisible = true;
        }
        private void ActiveOrderToList_Clicked(object sender, EventArgs e)
        {
            (BindingContext as OrdersUserControlViewModel).ActiveOrderPageIsVisible = false;
            (BindingContext as OrdersUserControlViewModel).SoListPageIsVisible = true;
        }

        private void ReviewButton_Clicked(object sender, EventArgs e)
        {
            var selectedItem = (SalesOrderModel)((Button)sender).CommandParameter;
            (BindingContext as OrdersUserControlViewModel).GoToReviewOrderPage(selectedItem);
        }

        private void SignButton_Clicked(object sender, EventArgs e)
        {
            (BindingContext as OrdersUserControlViewModel).GoToSignaturePage();
        }
    }
}