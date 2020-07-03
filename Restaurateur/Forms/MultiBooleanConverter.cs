using System;
using System.Windows.Data;

namespace Restaurateur.Forms
{
    class MultiBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.LongLength > 0)
            {
                foreach (var value in values)
                {
                    if (value is bool boolean && boolean)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
