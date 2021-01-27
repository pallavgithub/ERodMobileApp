using Prism.Navigation;

namespace ERodMobileApp.ViewModels
{
    public class NewOrderPageViewModel : ViewModelBase
    {
        public INavigationService _navigation;
        public NewOrderPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigation = navigationService;
        }
    }
}
