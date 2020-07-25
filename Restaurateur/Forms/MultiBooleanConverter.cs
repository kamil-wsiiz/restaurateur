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
        /// <param name="values">Tablica wartości, które tworzy powiązania źródłowe w MultiBinding. Wartość UnsetValue wskazuje, że powiązanie źródłowe nie ma wartości do zapewnienia konwersji</param>
        /// <param name="targetType">Typ właściwości docelowej powiązania</param>
        /// <param name="parameter">Parametr konwertera do użycia</param>
        /// <param name="culture">Kultura, która ma być używana w konwerterze</param>
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

        /// <summary>
        /// Obsługa niezaimplementowanej konwersji zwrotnej (metoda wyrzuca wyjątek)
        /// </summary>
        /// <param name="value">Wartość dostarczana przez obiekt docelowy powiązania</param>
        /// <param name="targetTypes">Tablica typów do przekonwertowania na. Długość tablicy wskazuje liczbę i typy wartości, które są sugerowane dla metody do zwrócenia</param>
        /// <param name="parameter">Parametr konwertera do użycia</param>
        /// <param name="culture">Kultura, która ma być używana w konwerterze</param>
        /// <returns>Wymagane dla nadpisania</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
