using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class ButtonColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value as string;
            string _Color = "#f0fbff";
            return _Color;
            //if (parameter as string == status)
            //    IsVisible = true;
            //if (parameter as string == status)
            //    IsVisible = true;
            //if (parameter as string == status)
            //    IsVisible = true;
            //if (parameter as string == status)
            //    IsVisible = true;
            //if (parameter as string == status)
            //    IsVisible = true;
            //return IsVisible; ;
            //if (parameter as string == status)
            //    IsVisible = true;
            //if (parameter as string == status)
            //    IsVisible = true;
            //if (parameter as string == status)
            //    IsVisible = true;
            //if (parameter as string == status)
            //    IsVisible = true;
            //if (parameter as string == status)
            //    IsVisible = true;
            //return IsVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
