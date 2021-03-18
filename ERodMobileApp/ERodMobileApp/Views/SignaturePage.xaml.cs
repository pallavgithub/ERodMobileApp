using ERodMobileApp.Helpers;
using ERodMobileApp.ViewModels;
using Plugin.Media;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignaturePage : ContentPage
    {
        public Stream _stream;
        private string _filePath;
        public SignaturePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "allowLandScapePortrait");
        }
        //during page close setting back to portrait
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Send(this, "preventLandScape");
        }
        protected override bool OnBackButtonPressed() => true;
        private void CancelBtn_Clicked(object sender, EventArgs e)
        {
            (BindingContext as SignaturePageViewModel)._navigation.GoBackAsync();
        }
        private async void UploadBtn_Clicked(object sender, EventArgs e)
        {
            var viewModel = (BindingContext as SignaturePageViewModel);
            var Toast = DependencyService.Get<IMessage>();
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                Toast.LongAlert("No Camera available");
                return;
            }
            var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
            });
            if (file == null)
                return;
            else
            {
                stampImg.Source = ImageSource.FromStream(() =>
                  {
                      var stream = file.GetStream();
                      _stream = stream;
                      _filePath = file.Path;
                      return stream;
                  });
                signature.IsVisible = false;
                stampImg.IsVisible = true;

                viewModel.SaveSignature();
                //App.Database.SaveSignatureAsync()
            }
        }

        private async void ConfirmBtn_Clicked(object sender, EventArgs e)
        {
            var viewModel = (BindingContext as SignaturePageViewModel);
            if (signature.IsVisible)
            {
                viewModel._stream = await signature.GetImageStreamAsync(SignatureImageFormat.Jpeg);
                // code for saving the file in galley and find the path
                //viewModel._filePath = _filePath;
            }
            else
            {
                viewModel._stream = _stream;
                viewModel._filePath = _filePath;
            }
            viewModel.SaveSignature();
        }
        //public async void Save(object sender, EventArgs eventArgs)
        //{
        //    Stream stream = await signature.GetImageStreamAsync(SignatureImageFormat.Jpeg);
        //}
    }
    
}
