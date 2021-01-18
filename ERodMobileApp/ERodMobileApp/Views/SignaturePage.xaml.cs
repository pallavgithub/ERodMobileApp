using ERodMobileApp.Helpers;
using ERodMobileApp.ViewModels;
using Plugin.Media;
using System;
using System.Collections.Generic;
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
                      return stream;
                  });
                signature.IsVisible = false;
                stampImg.IsVisible = true;
            }
            //pic.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
            //var st = file.GetStream();
            //FileStream fs = st as FileStream;
            //await _vm.UploadImageAsync(st, fs.Name);
        }
    }
    //public async void Save(object sender, EventArgs eventArgs)
    //{
    //    Stream stream = await signature.GetImageStreamAsync(SignatureImageFormat.Jpeg);
    //}
}
