using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System.Linq;
using Xamarin.Forms;

namespace ERodMobileApp.ViewModels
{
    public class ProfileUserControlViewModel : ViewModelBase
    {
        private string _mobileNumber;
        public string MobileNumber
        {
            get => _mobileNumber;
            set => SetProperty(ref _mobileNumber, value);
        }
        private string _company;
        public string Company
        {
            get => _company;
            set => SetProperty(ref _company, value);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _userName;
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public bool _emailNotification;
        public bool EmailNotification
        {
            get => _emailNotification;
            set => SetProperty(ref _emailNotification, value);
        }
        public bool _smsNotification;
        public bool SmsNotification
        {
            get => _smsNotification;
            set => SetProperty(ref _smsNotification, value);
        }
        public bool _orderStatusChange;
        public bool OrderStatusChange
        {
            get => _orderStatusChange;
            set => SetProperty(ref _orderStatusChange, value);
        }
        public bool _shippingNotification;
        public bool ShippingNotification
        {
            get => _shippingNotification;
            set => SetProperty(ref _shippingNotification, value);
        }
        public bool _signReminder;
        public bool SignReminder
        {
            get => _signReminder;
            set => SetProperty(ref _signReminder, value);
        }
        public UserModel UserData { get; set; }
        public UserNotificationModel UserNotifications { get; set; }
        public DelegateCommand LogoutBtnCommand { get; set; }
        public ProfileUserControlViewModel(INavigationService navigationService) : base(navigationService)
        {
            LogoutBtnCommand = new DelegateCommand(Logout);
            UserData = new UserModel();
            GetUserProfile();
        }
        public void GetUserProfile()
        {
            UserData = (UserModel)Application.Current.Properties.Where(x => x.Key == "User").FirstOrDefault().Value;
            UserNotifications = (UserNotificationModel)Application.Current.Properties.Where(x => x.Key == "UserNotifications").FirstOrDefault().Value;
            MobileNumber = UserData.PhoneNumber;
            UserName = UserData.Name;
            Company = UserData.Company;
            Email = UserData.Email;
            EmailNotification = UserNotifications.EmailNotification;
            SmsNotification = UserNotifications.SMSNotification;
            OrderStatusChange = UserNotifications.StatusChangeNotification;
            ShippingNotification = UserNotifications.ShippingNotification;
            SignReminder = UserNotifications.SignatureReminder;
        }
        public void Logout()
        {
            Application.Current.Properties.Remove("User");
            Application.Current.Properties.Remove("UserNotifications");
            Application.Current.Properties["IsFromProfilePage"] = true;
            Application.Current.SavePropertiesAsync();
            var navigationParams = new NavigationParameters();
            navigationParams.Add("IsFromProfile", true);
            NavigationService.NavigateAsync("LoginPage", navigationParams);
        }
    }
}
