using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditOrderPage : ContentPage
    {
        public EditOrderPage()
        {
            InitializeComponent();
            dateTime_picker._timePicker.Unfocused += dateTime_picker_Unfocused;
        }
        protected override bool OnBackButtonPressed() => true;
        private void dateTime_picker_Unfocused(object sender, FocusEventArgs e)
        {
            _deliveryDate.Text = dateTime_picker._entry.Text;
        }
    }
}