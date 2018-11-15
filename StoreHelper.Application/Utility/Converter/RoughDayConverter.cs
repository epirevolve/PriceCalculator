using StoreHelper.Domain.Model.Product;
using System;
using System.Globalization;
using System.Windows.Data;

namespace StoreSupportTool.Application.Utility.Converter
{
    sealed class RoughDayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var roughDay = (RoughDay)value;
            return roughDay == RoughDay.beginning ? "上旬" :
                roughDay == RoughDay.middle ? "中旬" :
                "終旬";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
