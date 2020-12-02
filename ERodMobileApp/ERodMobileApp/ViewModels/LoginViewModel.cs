using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERodMobileApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
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

        public DelegateCommand NavigateToMainPageCommand { get; }

        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateToMainPageCommand = new DelegateCommand(NavigateToMainPage);
        }

        private void NavigateToMainPage()
        {
            NavigationService.NavigateAsync("MainPage");
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {

        }
    }
}
