using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class QuantityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string Quantity = string.Empty;
            Quantity = (value as string).Split('.')[0];
            return Quantity;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
