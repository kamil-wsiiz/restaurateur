using System;
using System.Windows.Data;

namespace Restaurateur.Forms
{
    /// <summary>
    /// Klasa konwertera wykorzystywanego do walidacji formularzy
    /// </summary>
    class MultiBooleanConverter : IMultiValueConverter
    {
        /// <summary>
        /// Konwertowanie informacji o błędach w formularzu do wartości logicznej
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns>
        /// Wartość logiczna - formularz ma/nie ma błędów
        /// </returns>
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
