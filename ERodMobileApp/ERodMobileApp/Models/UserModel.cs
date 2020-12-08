namespace ERodMobileApp.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserGroup { get; set; }
        public string Region { get; set; }
        public string SalesPersonCode { get; set; }
        public string SalesPersonName { get; set; }
        public string SalesPersonEmail { get; set; }
        public string SalesPersonPhone { get; set; }
        public decimal OrderAmount { get; set; }
        public int HistoryWindow { get; set; }
        public int EditWindow { get; set; }
        public bool AppNotification { get; set; }
        public bool EmailNotification { get; set; }
        public bool SMSNotification { get; set; }
        public bool StatusChangeNotification { get; set; }
        public bool ShippingNotification { get; set; }
        public bool SignatureReminder { get; set; }
        public string Signature { get; set; }
        public string CloudStorageDirectoryLink { get; set; }
        public string CF_BillingInfo1 { get; set; }
        public string CF_BillingInfo2 { get; set; }
        public string CF_BillingCode1 { get; set; }
        public string CF_BillingCode2 { get; set; }
    }
}
