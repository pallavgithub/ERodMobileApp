using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class SelectedLabelColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color lblColor = Color.White;
            var data = value as string;
            if(parameter as string==data)
            {
                lblColor= Color.FromHex("#FF6600");
            }
            return lblColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
