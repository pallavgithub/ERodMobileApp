using ERodMobileApp.Models;
using Prism.Navigation;
using SignaturePad.Forms;
using System.IO;

namespace ERodMobileApp.ViewModels
{
    public class SignaturePageViewModel:ViewModelBase
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

        public void SaveSignature()
        {
            Stream stream = _stream;
            byte[] byteArray = ConvertToByteArrayFromStream();
            string filePath = _filePath;
            UserSignature usersignature = new UserSignature()
            {
                SalesOrderID = "",
                SignatureByteArray = byteArray,
                SignaturePath = filePath,
                UserName = ""
            };
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
