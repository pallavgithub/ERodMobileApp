using ERodMobileApp.Helpers;
using ERodMobileApp.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private List<Entry> _entries;
        private List<long> _time;
        long lastPress;
        public LoginPage()
        {
            InitializeComponent();
            (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
            _entries = new List<Entry>();
            _entries.Add(Entry_one);
            _entries.Add(Entry_two);
            _entries.Add(Entry_three);
            _entries.Add(Entry_four);
            _entries.Add(Entry_five);
            _entries.Add(Entry_six);
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
                var previousEntry = GetPreviousEntry(sender as Entry);
                if (previousEntry != null)
                {
                    previousEntry.Focus();
                }
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
                var previousEntry = GetPreviousEntry(sender as Entry);
                if (previousEntry != null)
                {
                    previousEntry.Focus();
                }
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
                var previousEntry = GetPreviousEntry(sender as Entry);
                if (previousEntry != null)
                {
                    previousEntry.Focus();
                }
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
                var previousEntry = GetPreviousEntry(sender as Entry);
                if (previousEntry != null)
                {
                    previousEntry.Focus();
                }
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
                var previousEntry = GetPreviousEntry(sender as Entry);
                if (previousEntry != null)
                {
                    previousEntry.Focus();
                }
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
                var previousEntry = GetPreviousEntry(sender as Entry);
                if (previousEntry != null)
                {
                    previousEntry.Focus();
                }
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = true;
            }
            else
            {
                (BindingContext as LoginPageViewModel).ExitBtnIsVisible = false;
            }
        }
        private void Exit_btn_Clicked(object sender, EventArgs e)
        {
            var Toast = DependencyService.Get<IMessage>();
            long currentTime = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
            //_time.Add(currentTime);
            //int length = _time.Count;            
            //if (_time[length - 1] - _time[length - 2] > 2000)
            //{
            //    Toast.ShortAlert("Press again to exit.");
            //}
            if (currentTime - lastPress > 3000)
            {
                Toast.ShortAlert("Press again to exit.");
                lastPress = currentTime;
            }
            else
            {
                (BindingContext as LoginPageViewModel).ExitApp();
            }
        }
        private void Notification_Toggled(object sender, ToggledEventArgs e)
        {
            //(BindingContext as LoginPageViewModel).UpdateUserNotification();
        }
        protected override bool OnBackButtonPressed() => true;
        public Entry GetPreviousEntry(Entry currentEntry)
        {
            var indexOfCurrentEntry = _entries.IndexOf(currentEntry);
            if (indexOfCurrentEntry == 0)
            {
                return null;
            }
            var previousEntry = _entries[indexOfCurrentEntry - 1];
            return previousEntry;
        }

        protected override async void OnAppearing()
        {
            await App.CheckAndRequestPhonePermission();
            (BindingContext as LoginPageViewModel).CheckPlatform();
        }
    }
}