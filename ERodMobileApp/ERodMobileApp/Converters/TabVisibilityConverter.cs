using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    class TabVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var data = value as string;
            bool isVisible = false;
            if (data == parameter as string)
            {
                isVisible = true;
            }
            return isVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
