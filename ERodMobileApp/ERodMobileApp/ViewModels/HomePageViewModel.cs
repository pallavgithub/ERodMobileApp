﻿using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace ERodMobileApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public string _tabData;
        public string TabData
        {
            get => _tabData;
            set => SetProperty(ref _tabData, value);
        }
        public DelegateCommand GoToProfileCommand { get; set; }
        public DelegateCommand GoToOrdersCommand { get; set; }
        public DelegateCommand GoToNewOrderCommand { get; set; }
        public DelegateCommand GoToNotificationCommand { get; set; }
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            TabData = "Profile";
            GoToProfileCommand = new DelegateCommand(ProfileTabSelected);
            GoToOrdersCommand = new DelegateCommand(OrdersTabSelected);
            GoToNewOrderCommand = new DelegateCommand(NewOrderTabSelected);
            GoToNotificationCommand = new DelegateCommand(NotificationTabSelected);
            MessagingCenter.Subscribe<string>(this, "FromNotification", async (message) =>
            {
                TabData = "Notification";
            });
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public void ProfileTabSelected()
        {
            TabData = "Profile";
        }
        public void OrdersTabSelected()
        {
            TabData = "Orders";
        }
        public void NewOrderTabSelected()
        {
            TabData = "NewOrder";
        }
        public void NotificationTabSelected()
        {
            TabData = "Notification";
        }
    }
}
