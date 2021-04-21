using ERodMobileApp.Models;
using ERodMobileApp.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationUserControl : ContentView
    {

        public NotificationUserControl()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<string>(this, "NotifactionsAdded", async (message) =>
            {
                (BindingContext as NotificationUserControlViewModel).NotificationList = new ObservableCollection<NotificationModel>(App.AllNotifications);
                Notification_Listview.ItemsSource = (BindingContext as NotificationUserControlViewModel).NotificationList;
            });
        }
        public void SetNotificationData()
        {
            try
            {
                Notification_Listview.ItemsSource = App.AllNotifications;
               
            }
            catch (Exception e)
            {
            }
        }
    }
}