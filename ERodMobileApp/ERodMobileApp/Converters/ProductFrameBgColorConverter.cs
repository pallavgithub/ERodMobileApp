using ERodMobileApp.Models;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace ERodMobileApp.Converters
{
    public class ProductFrameBgColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color BgColor = Color.FromHex("#50555C");
            var _tabData = value as GroupData;
            if (_tabData.SelectedGroupType == "Group")
            {
                if (parameter as string == _tabData.SelectedGroup)
                    BgColor = Color.FromHex("#F0FBFF");
                if (parameter as string == _tabData.SelectedGroup)
                    BgColor = Color.FromHex("#F0FBFF");
                if (parameter as string == _tabData.SelectedGroup)
                    BgColor = Color.FromHex("#F0FBFF");
                if (parameter as string == _tabData.SelectedGroup)
                    BgColor = Color.FromHex("#F0FBFF");
                if (parameter as string == _tabData.SelectedGroup)
                    BgColor = Color.FromHex("#F0FBFF");
                if (parameter as string == _tabData.SelectedGroup)
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
