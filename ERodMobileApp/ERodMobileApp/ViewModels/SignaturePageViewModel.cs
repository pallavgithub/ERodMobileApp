using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using Prism.Navigation;
using SignaturePad.Forms;
using System;
using System.IO;
using Xamarin.Forms;

namespace ERodMobileApp.ViewModels
{
    public class SignaturePageViewModel : ViewModelBase
    {
        public INavigationService _navigation;
        public UserSignature _userSignature;
        public Stream _stream { get; set; }
        public string _filePath { get; set; }

        public SignaturePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigation = navigationService;
            _userSignature = new UserSignature();
        }

        public async void SaveSignature()
        {
            var Toast = DependencyService.Get<IMessage>();
            Stream stream = _stream;
            byte[] byteArray = ConvertToByteArrayFromStream();
            string base64Img = Convert.ToBase64String(byteArray);
            string filePath = _filePath;

            UserSignature usersignature = new UserSignature()
            {
                ImageString = base64Img,
                Name = filePath,
            };
            var response = await new ApiData().PostData<string>("api/salesorder/PostSignatureImage", usersignature, true);
            if (response != null && response.status=="Success")
            {
                Toast.LongAlert("Signature Uploaded.");
                NavigationService.GoBackAsync();
            }
            else
            {
                Toast.LongAlert("Error occured");
            }
            // Save user signature in local storage
            // api will be called when submit sales order will be initiated
        }

        private byte[] ConvertToByteArrayFromStream()
        {
            byte[] byteArray = null;
            using (MemoryStream ms = new MemoryStream())
            {
                _stream.CopyTo(ms);
                byteArray = ms.ToArray();
            }
            return byteArray;
        }
    }
}
