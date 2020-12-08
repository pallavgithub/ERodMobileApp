namespace ERodMobileApp.Models
{
    public class UserNotificationModel
    {
        public bool AppNotification { get; set; }
        public bool EmailNotification { get; set; }
        public bool SMSNotification { get; set; }
        public bool StatusChangeNotification { get; set; }
        public bool ShippingNotification { get; set; }
        public bool SignatureReminder { get; set; }
        public string PhoneNumber { get; set; }
    }
}
