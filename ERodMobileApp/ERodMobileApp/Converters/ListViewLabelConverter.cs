using ERodMobileApp.Models;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class ListViewLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool IsVisible = false;
            string data = value as string;
            if (data != "0")
            {
                IsVisible = true;
            }
            return IsVisible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
