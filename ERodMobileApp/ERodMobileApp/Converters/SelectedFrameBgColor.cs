using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class SelectedFrameBgColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color BgColor = Color.FromHex("#50555C");
            var data = value as string;
            if (parameter as string == data)
            {
                BgColor = Color.FromHex("#F0FBFF");
            }
            return BgColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
