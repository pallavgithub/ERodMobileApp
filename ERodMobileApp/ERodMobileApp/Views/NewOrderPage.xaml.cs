using ERodMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderPage : ContentPage
    {
        public NewOrderPage()
        {
            InitializeComponent();
        }

        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            (BindingContext as NewOrderPageViewModel)._navigation.GoBackAsync();
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            (BindingContext as NewOrderPageViewModel)._navigation.NavigateAsync("ProductsPage");
        }
    }
}