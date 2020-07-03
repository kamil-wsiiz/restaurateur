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
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return (string.IsNullOrWhiteSpace((value ?? "").ToString()))
                ? new ValidationResult(false, "Pole jest wymagane")
                : ValidationResult.ValidResult;
        }
    }
}
