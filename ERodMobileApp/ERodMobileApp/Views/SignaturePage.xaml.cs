using ERodMobileApp.ViewModels;
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
        //public async void Save(object sender, EventArgs eventArgs)
        //{
        //    Stream stream = await signature.GetImageStreamAsync(SignatureImageFormat.Jpeg);
        //}
    }
}