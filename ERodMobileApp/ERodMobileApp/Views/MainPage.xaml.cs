using System.Threading.Tasks;
using Xamarin.Forms;

namespace ERodMobileApp.Views
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            order.IsVisible = false;
            track.IsVisible = false;
            receive.IsVisible = false;
            LogoBg.IsVisible = false;
            exceed.IsVisible = false;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(2000);
            exceed.IsVisible = true;
            await exceed.ScaleTo(1, 600);
            await Task.WhenAll(exceed.TranslateTo(0, -170, 600), exceed.ScaleTo(0.5, 600));
            await Task.Delay(400);
            order.IsVisible = true;
            await order.ScaleTo(2, 400);
            await Task.WhenAll(order.TranslateTo(0, -170, 600), order.ScaleTo(0, 600));
            await Task.Delay(400);
            track.IsVisible = true;
            await track.ScaleTo(2, 400);
            await Task.WhenAll(track.TranslateTo(0, -170, 600), track.ScaleTo(0, 600));
            await Task.Delay(400);
            receive.IsVisible = true;
            await receive.ScaleTo(2, 400);
            await Task.WhenAll(receive.TranslateTo(0, -170, 600), receive.ScaleTo(0, 600));
            LogoBg.IsVisible = true;
            //await LogoBg.ScaleTo(1, 400);
            await Task.WhenAll(LogoBg.TranslateTo(0, -10, 600), LogoBg.ScaleTo(1.8, 600));
            await Navigation.PushAsync(new LoginPage());
        }
    }
}
