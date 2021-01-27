using ERodMobileApp.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class ProductDataVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsVisible = false;
            string data = value as string;
            if (parameter as string == data)
                IsVisible = true;
            if (parameter as string == data)
                IsVisible = true;
            if (parameter as string == data)
                IsVisible = true;
            if (parameter as string == data)
                IsVisible = true;
            if (parameter as string == data)
                IsVisible = true;
            if (parameter as string == data)
                IsVisible = true;
            return IsVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
