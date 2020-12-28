using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class OrderStatusVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = value as string;
            bool IsVisible = false;
            if (parameter as string == status)
                IsVisible = true;
            if (parameter as string == status)
                IsVisible = true;
            if (parameter as string == status)
                IsVisible = true;
            if (parameter as string == status)
                IsVisible = true;
            if (parameter as string == status)
                IsVisible = true;
            return IsVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
