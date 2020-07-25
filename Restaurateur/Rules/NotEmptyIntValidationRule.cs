using System.Globalization;
using System.Windows.Controls;

namespace Restaurateur.Rules
{
    /// <summary>
    /// Klasa dodająca regułę walidacji
    /// </summary>
    public class NotEmptyIntValidationRule : ValidationRule
    {
        /// <summary>
        /// Metoda sprawdzająca czy pole liczbowe wprowadzone przez użytkownika nie jest puste
        /// </summary>
        /// <param name="value">Wartość z elementu docelowego powiązania do sprawdzenia</param>
        /// <param name="cultureInfo">Kultura, która ma być używana w tej regule</param>
        /// <returns>Obiekt rezultatu walidacji</returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return (string.IsNullOrWhiteSpace((value ?? "").ToString()))
                ? new ValidationResult(false, "Pole jest wymagane")
                : ValidationResult.ValidResult;
        }
    }
}
