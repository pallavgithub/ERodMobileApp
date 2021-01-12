using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewOrderPage : ContentPage
    {
        public ReviewOrderPage(NavigationParameters salesOrder)
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed() => true;
    }
}