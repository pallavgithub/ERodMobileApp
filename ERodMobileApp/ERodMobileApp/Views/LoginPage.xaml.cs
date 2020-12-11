using ERodMobileApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
        }
        private async void LoginWithActivationCode_Clicked(object sender, EventArgs e)
        {
            await (BindingContext as LoginPageViewModel).LoginWithActivationCode();
        }
        private async void LoginWithMobileNumber_Clicked(object sender, EventArgs e)
        {
            await (BindingContext as LoginPageViewModel).LoginWithMobileNumber();
        }
        private void Entry_one_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Entry_one.Text))
            {
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
            }
            else
            {
                Entry_two.Focus();
                if (!string.IsNullOrEmpty(Entry_one.Text) && !string.IsNullOrEmpty(Entry_two.Text) && !string.IsNullOrEmpty(Entry_three.Text) && !string.IsNullOrEmpty(Entry_four.Text) && !string.IsNullOrEmpty(Entry_five.Text) && !string.IsNullOrEmpty(Entry_six.Text))
                {
                    (BindingContext as LoginPageViewModel).ExitBtnIsVisible = false;
                }
            }
        }
        private void Entry_two_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Entry_two.Text))
            {
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
            }
            else
            {
                Entry_three.Focus();
                if (!string.IsNullOrEmpty(Entry_one.Text) && !string.IsNullOrEmpty(Entry_two.Text) && !string.IsNullOrEmpty(Entry_three.Text) && !string.IsNullOrEmpty(Entry_four.Text) && !string.IsNullOrEmpty(Entry_five.Text) && !string.IsNullOrEmpty(Entry_six.Text))
                {
                    (BindingContext as LoginPageViewModel).ExitBtnIsVisible = false;
                }
            }
        }
        private void Entry_three_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Entry_three.Text))
            {
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
            }
            else
            {
                Entry_four.Focus();
                if (!string.IsNullOrEmpty(Entry_one.Text) && !string.IsNullOrEmpty(Entry_two.Text) && !string.IsNullOrEmpty(Entry_three.Text) && !string.IsNullOrEmpty(Entry_four.Text) && !string.IsNullOrEmpty(Entry_five.Text) && !string.IsNullOrEmpty(Entry_six.Text))
                {
                    (BindingContext as LoginPageViewModel).ExitBtnIsVisible = false;
                }
            }
        }
        private void Entry_four_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Entry_four.Text))
            {
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
            }
            else
            {
                Entry_five.Focus();
                if (!string.IsNullOrEmpty(Entry_one.Text) && !string.IsNullOrEmpty(Entry_two.Text) && !string.IsNullOrEmpty(Entry_three.Text) && !string.IsNullOrEmpty(Entry_four.Text) && !string.IsNullOrEmpty(Entry_five.Text) && !string.IsNullOrEmpty(Entry_six.Text))
                {
                    (BindingContext as LoginPageViewModel).ExitBtnIsVisible = false;
                }
            }
        }
        private void Entry_five_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Entry_five.Text))
            {
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
            }
            else
            {
                Entry_six.Focus();
                if (!string.IsNullOrEmpty(Entry_one.Text) && !string.IsNullOrEmpty(Entry_two.Text) && !string.IsNullOrEmpty(Entry_three.Text) && !string.IsNullOrEmpty(Entry_four.Text) && !string.IsNullOrEmpty(Entry_five.Text) && !string.IsNullOrEmpty(Entry_six.Text))
                {
                    (BindingContext as LoginPageViewModel).ExitBtnIsVisible = false;
                }
            }
        }
        private void Entry_six_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Entry_six.Text))
            {
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
            }
            else
            {
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = false;
            }
        }
        private void Exit_btn_Clicked(object sender, EventArgs e)
        {
            (BindingContext as LoginPageViewModel).ExitApp();
        }
        private void Notification_Toggled(object sender, ToggledEventArgs e)
        {
            //(BindingContext as LoginPageViewModel).UpdateUserNotification();
        }
        protected override bool OnBackButtonPressed() => true;
    }
}