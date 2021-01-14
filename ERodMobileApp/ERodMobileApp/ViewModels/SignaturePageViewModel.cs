using Prism.Navigation;
using SignaturePad.Forms;
using System.IO;

namespace ERodMobileApp.ViewModels
{
    public class SignaturePageViewModel:ViewModelBase
    {
        public INavigationService _navigation;

        public SignaturePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigation = navigationService;
        }
    }
}
