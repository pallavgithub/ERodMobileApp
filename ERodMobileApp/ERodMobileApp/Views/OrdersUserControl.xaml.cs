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
        }
        private void ClosedOrderDetails_Tapped(object sender, EventArgs e)
        {
            (BindingContext as OrdersUserControlViewModel).SoListPageIsVisible = false;
            (BindingContext as OrdersUserControlViewModel).ClosedOrderPageIsVisible = true;
            SalesOrderDataModel salesOrder = (((TappedEventArgs)e).Parameter) as SalesOrderDataModel;
            (BindingContext as OrdersUserControlViewModel).GetClosedOrderDetails(salesOrder);
        }
        private void ActiveOrderDetails_Tapped(object sender, EventArgs e)
        {
            (BindingContext as OrdersUserControlViewModel).SoListPageIsVisible = false;
            (BindingContext as OrdersUserControlViewModel).ActiveOrderPageIsVisible = true;
            SalesOrderDataModel salesOrder = (((TappedEventArgs)e).Parameter) as SalesOrderDataModel;
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
    }
}