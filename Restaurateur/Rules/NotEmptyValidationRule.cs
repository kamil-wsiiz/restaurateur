using System.Globalization;
using System.Windows.Controls;

namespace Restaurateur.Rules
{
    /// <summary>
    /// Klasa dodająca regułę walidacji
    /// </summary>
    public class NotEmptyValidationRule : ValidationRule
    {
        /// <summary>
        /// Metoda sprawdzająca czy pole wprowadzone przez użytkownika nie jest puste
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return (string.IsNullOrWhiteSpace((value ?? "").ToString()) || (value ?? "").ToString().Equals("0"))
                ? new ValidationResult(false, "Pole jest wymagane")
                : ValidationResult.ValidResult;
        }
    }
}
