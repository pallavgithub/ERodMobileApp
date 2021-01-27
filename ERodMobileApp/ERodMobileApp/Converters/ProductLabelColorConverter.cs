using ERodMobileApp.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class ProductLabelColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color lblColor = Color.White;
            var _tabData = value as GroupData;
            if (_tabData.SelectedGroupType == "Group")
            {
                if (parameter as string == _tabData.SelectedGroup)
                    lblColor = Color.FromHex("#FF6600");
                if (parameter as string == _tabData.SelectedGroup)
                    lblColor = Color.FromHex("#FF6600");
                if (parameter as string == _tabData.SelectedGroup)
                    lblColor = Color.FromHex("#FF6600");
                if (parameter as string == _tabData.SelectedGroup)
                    lblColor = Color.FromHex("#FF6600");
                if (parameter as string == _tabData.SelectedGroup)
                    lblColor = Color.FromHex("#FF6600");
                if (parameter as string == _tabData.SelectedGroup)
                    lblColor = Color.FromHex("#FF6600");
            }
            return lblColor;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}