using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using ERodMobileApp.Views;
using Prism.Commands;
using Prism.Navigation;
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
        public DelegateCommand DoneButtonCommand { get; set; }
        public UserModel User { get; set; }
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            User = new UserModel();
            DoneButtonCommand = new DelegateCommand(DoneButtonClicked);
            LoginWithMobileNumber();
        }
        public async Task LoginWithMobileNumber()
        {
            string Mobile = "281-781-6334";
           
            ResponseModel<UserModel> response = await new ApiData().PostData<UserModel>("api/account/Login?MobileNumber=" + Mobile, true);
            if (response != null && response.data != null)
            {
                ExitBtnIsVisible = true;
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
            }
            else
            {
                ActivationCodePageIsVisible = true;
            }
        }
        public async Task LoginWithActivationCode()
        {
            var Toast = DependencyService.Get<IMessage>();
            if (!string.IsNullOrEmpty(Text1) && !string.IsNullOrEmpty(Text2) && !string.IsNullOrEmpty(Text3) && !string.IsNullOrEmpty(Text4) && !string.IsNullOrEmpty(Text5) && !string.IsNullOrEmpty(Text6))
            {
                ActivationCode = Text1 + Text2 + Text3 + Text4 + Text5 + Text6;
                string _activationCode = "411226";
                ResponseModel<UserModel> response = await new ApiData().PostData<UserModel>("api/account/Login?ActivationCode=" + _activationCode, true);
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
                }
                else
                {
                    Toast.LongAlert("User not found.");
                }
            }
            else
            {
                Toast.LongAlert("Please fill activation code.");
            }
        }
        public void DoneButtonClicked()
        {
            var Toast = DependencyService.Get<IMessage>();
            if (IsAgree)
            {
                NavigationService.NavigateAsync("HomePage");
            }
            else
            {
                Toast.LongAlert("Please check Terms and Conditions");
            }
        }
    }
}
