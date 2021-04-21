using ERodMobileApp.Models;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace ERodMobileApp.ViewModels
{
    public class NotificationUserControlViewModel:ViewModelBase
    {
        public ObservableCollection<NotificationModel> _notificationList;
        public ObservableCollection<NotificationModel> NotificationList
        {
            get => _notificationList;
            set => SetProperty(ref _notificationList, value);
        }
        public NotificationUserControlViewModel(INavigationService navigationService):base(navigationService)
        {
            //GetAllNotifications();
        }
        public void GetAllNotifications()
        {
            //NotificationList = new ObservableCollection<Notification>();
            //NotificationList.Add(new Notification {Date="11/2/20",Name="New Order Received",Id= "EGSPUGE-234-K694G" });
            //NotificationList.Add(new Notification {Date="11/2/20",Name="Arriving Tomorrow",Id= "EGSPUGE-234-K694G" });
            //NotificationList.Add(new Notification {Date="11/2/20",Name="Order Confirmed",Id= "EGSPUGE-234-K694G" });
            //NotificationList.Add(new Notification {Date="11/2/20",Name="Order Processing",Id= "EGSPUGE-234-K694G" });
            //NotificationList.Add(new Notification {Date="11/2/20",Name="Order Shipped",Id= "EGSPUGE-234-K694G" });
            //NotificationList.Add(new Notification {Date="11/2/20",Name="Order Delivered",Id= "EGSPUGE-234-K694G" });
            //NotificationList.Add(new Notification {Date="11/2/20",Name="Signature Required",Id= "EGSPUGE-234-K694G" });
        }
    }
    public class Notification
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
