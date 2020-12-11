using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using ERodMobileApp.Views;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ERodMobileApp.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        private string _mobileNumber;
        public string MobileNumber
        {
            get => _mobileNumber;
            set => SetProperty(ref _mobileNumber, value);
        }
        private string _phone;
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }
        private string _activationCode;
        public string ActivationCode
        {
            get => _activationCode;
            set => SetProperty(ref _activationCode, value);
        }
        public bool _loginIsVisible;
        public bool LoginIsVisible
        {
            get => _loginIsVisible;
            set => SetProperty(ref _loginIsVisible, value);
        }
        public bool _enterMobilePageIsVisible;
        public bool EnterMobilePageIsVisible
        {
            get => _enterMobilePageIsVisible;
            set => SetProperty(ref _enterMobilePageIsVisible, value);
        }
        public bool _activationCodePageIsVisible;
        public bool ActivationCodePageIsVisible
        {
            get => _activationCodePageIsVisible;
            set => SetProperty(ref _activationCodePageIsVisible, value);
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
        private string _text1;
        public string Text1
        {
            get => _text1;
            set => SetProperty(ref _text1, value);
        }
        private string _text2;
        public string Text2
        {
            get => _text2;
            set => SetProperty(ref _text2, value);
        }
        private string _text3;
        public string Text3
        {
            get => _text3;
            set => SetProperty(ref _text3, value);
        }
        private string _text4;
        public string Text4
        {
            get => _text4;
            set => SetProperty(ref _text4, value);
        }
        private string _text5;
        public string Text5
        {
            get => _text5;
            set => SetProperty(ref _text5, value);
        }
        private string _text6;
        public string Text6
        {
            get => _text6;
            set => SetProperty(ref _text6, value);
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
        public bool _isAgree;
        public bool IsAgree
        {
            get => _isAgree;
            set => SetProperty(ref _isAgree, value);
        }
        public bool _nextBtnIsVisible;
        public bool NextBtnIsVisible
        {
            get => _nextBtnIsVisible;
            set => SetProperty(ref _nextBtnIsVisible, value);
        }
        public bool _exitBtnIsVisible;
        public bool ExitBtnIsVisible
        {
            get => _exitBtnIsVisible;
            set => SetProperty(ref _exitBtnIsVisible, value);
        }
        public bool _popupIsVisible;
        public bool PopupIsVisible
        {
            get => _popupIsVisible;
            set => SetProperty(ref _popupIsVisible, value);
        }
        public DelegateCommand DoneButtonCommand { get; set; }
        public DelegateCommand OpenPopupCommand { get; set; }
        public DelegateCommand EmailToggleCommand { get; set; }
        public DelegateCommand SmsToggleCommand { get; set; }
        public DelegateCommand OrderStatusToggleCommand { get; set; }
        public DelegateCommand ShippingToggleCommand { get; set; }
        public DelegateCommand SignToggleCommand { get; set; }
        public DelegateCommand CheckBoxCommand { get; set; }
        public UserModel User { get; set; }
        public UserNotificationModel UserNotifications { get; set; }
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = new UserModel();
            DoneButtonCommand = new DelegateCommand(DoneButtonClicked);
            OpenPopupCommand = new DelegateCommand(OpenClosePopup);
            EmailToggleCommand = new DelegateCommand(async () => await UpdateUserNotification("Email"));
            SmsToggleCommand = new DelegateCommand(async () => await UpdateUserNotification("Sms"));
            OrderStatusToggleCommand = new DelegateCommand(async () => await UpdateUserNotification("OrderStatus"));
            ShippingToggleCommand = new DelegateCommand(async () => await UpdateUserNotification("Shipping"));
            SignToggleCommand = new DelegateCommand(async () => await UpdateUserNotification("Sign"));
            CheckBoxCommand = new DelegateCommand(CheckBoxCheckUncheck);
            CheckPlatform();
            //LoginWithMobileNumber();
        }
        public void CheckBoxCheckUncheck()
        {
            IsAgree = !IsAgree;
        }
        public void OpenClosePopup()
        {
            PopupIsVisible = !PopupIsVisible;
        }
        public void CheckPlatform()
        {
            switch (Device.RuntimePlatform)
            {
                case "Android":
                    try
                    {
                        var deviceInfo = Xamarin.Forms.DependencyService.Get<IDeviceInfo>();
                        Phone = deviceInfo.GetPhoneNumber();
                        LoginWithMobileNumber();
                    }
                    catch (Exception e)
                    {

                    }
                    break;
                case "iOS":
                    EnterMobilePageIsVisible = true;
                    break;
            }
        }
        public async Task LoginWithMobileNumber()
        {
            var Toast = DependencyService.Get<IMessage>();
            if (string.IsNullOrEmpty(Phone))
            {
                if (Device.RuntimePlatform == "iOS")
                {
                    Toast.LongAlert("Please fill Mobile Number");
                    return;
                }
                else
                {
                    Toast.LongAlert("Phone number not found");
                    return;
                }
            }
            if (IsBusy)
            {
                return;
            }
            else
            {
                IsBusy = true;
                //string Mobile = "281-781-6334";

                ResponseModel<UserModel> response = await new ApiData().PostData<UserModel>("api/account/Login?MobileNumber=" + Phone, true);
                if (response != null && response.data != null)
                {
                    ExitBtnIsVisible = true;
                    EnterMobilePageIsVisible = false;
                    LoginIsVisible = true;
                    User = response.data;
                    UserName = User.Name;
                    MobileNumber = User.PhoneNumber;
                    Company = User.Company;
                    Email = User.Email;
                    EmailNotification = User.EmailNotification;
                    SmsNotification = User.SMSNotification;
                    OrderStatusChange = User.StatusChangeNotification;
                    ShippingNotification = User.ShippingNotification;
                    SignReminder = User.SignatureReminder;
                    UserNotifications = new UserNotificationModel();
                    UserNotifications.AppNotification = User.AppNotification;
                    UserNotifications.EmailNotification = User.EmailNotification;
                    UserNotifications.SMSNotification = User.SMSNotification;
                    UserNotifications.StatusChangeNotification = User.StatusChangeNotification;
                    UserNotifications.ShippingNotification = User.ShippingNotification;
                    UserNotifications.SignatureReminder = User.SignatureReminder;
                    UserNotifications.PhoneNumber = User.PhoneNumber;
                }
                else
                {
                    LoginIsVisible = false;
                    EnterMobilePageIsVisible = false;
                    ActivationCodePageIsVisible = true;
                }
                IsBusy = false;
            }
        }
        public async Task LoginWithActivationCode()
        {
            var Toast = DependencyService.Get<IMessage>();
            if (!string.IsNullOrEmpty(Text1) && !string.IsNullOrEmpty(Text2) && !string.IsNullOrEmpty(Text3) && !string.IsNullOrEmpty(Text4) && !string.IsNullOrEmpty(Text5) && !string.IsNullOrEmpty(Text6))
            {
                ActivationCode = Text1 + Text2 + Text3 + Text4 + Text5 + Text6;
                // string _activationCode = "411226";
                ResponseModel<UserModel> response = await new ApiData().PostData<UserModel>("api/account/Login?ActivationCode=" + ActivationCode, true);
                if (response != null && response.data != null)
                {
                    LoginIsVisible = true;
                    User = response.data;
                    UserName = User.Name;
                    MobileNumber = User.PhoneNumber;
                    Company = User.Company;
                    Email = User.Email;
                    EmailNotification = User.EmailNotification;
                    SmsNotification = User.SMSNotification;
                    OrderStatusChange = User.StatusChangeNotification;
                    ShippingNotification = User.ShippingNotification;
                    SignReminder = User.SignatureReminder;
                    ActivationCodePageIsVisible = false;
                    LoginIsVisible = true;
                    UserNotifications = new UserNotificationModel();
                    UserNotifications.AppNotification = User.AppNotification;
                    UserNotifications.EmailNotification = User.EmailNotification;
                    UserNotifications.SMSNotification = User.SMSNotification;
                    UserNotifications.StatusChangeNotification = User.StatusChangeNotification;
                    UserNotifications.ShippingNotification = User.ShippingNotification;
                    UserNotifications.SignatureReminder = User.SignatureReminder;
                    UserNotifications.PhoneNumber = User.PhoneNumber;
                }
                else
                {
                    Toast.LongAlert("Incorrect activation code.");
                }
            }
            else
            {
                Toast.LongAlert("Please fill activation code.");
            }
        }
        public async Task UpdateUserNotification(string ToggledNotification)
        {
            if (ToggledNotification == "Email")
            {
                EmailNotification = !EmailNotification;
                UserNotifications.EmailNotification = EmailNotification;
            }
            if (ToggledNotification == "Sms")
            {
                SmsNotification = !SmsNotification;
                UserNotifications.SMSNotification = SmsNotification;
            }
            if (ToggledNotification == "OrderStatus")
            {
                OrderStatusChange = !OrderStatusChange;
                UserNotifications.StatusChangeNotification = OrderStatusChange;
            }
            if (ToggledNotification == "Shipping")
            {
                ShippingNotification = !ShippingNotification;
                UserNotifications.ShippingNotification = ShippingNotification;
            }
            if (ToggledNotification == "Sign")
            {
                SignReminder = !SignReminder;
                UserNotifications.SignatureReminder = SignReminder;
            }
            //var updatedNotifications = new UserNotificationModel()
            //{
            //    EmailNotification = EmailNotification,
            //    AppNotification = true,
            //    SMSNotification = SmsNotification,
            //    StatusChangeNotification = OrderStatusChange,
            //    ShippingNotification = ShippingNotification,
            //    SignatureReminder = SignReminder,
            //    PhoneNumber = MobileNumber
            //};
            var response = await new ApiData().PostData<string>("api/account/UpdateNotification", UserNotifications, true);
            if (response != null)
            {
               // UserNotifications = updatedNotifications;
            }
        }
        public void DoneButtonClicked()
        {
            var Toast = DependencyService.Get<IMessage>();
            if (IsAgree)
            {
                Application.Current.Properties["User"] = User;
                Application.Current.Properties["UserNotifications"] = UserNotifications;
                Application.Current.SavePropertiesAsync();
                NavigationService.NavigateAsync("HomePage");
            }
            else
            {
                Toast.LongAlert("Please check Terms and Conditions");
            }
        }
        public bool ExitApp()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var closer = DependencyService.Get<IExitApp>();
                closer?.closeApplication();
            });
            return true;
        }
    }
}
