using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using Restaurateur.Rules;
using System.Windows.Controls;

namespace RestaurateurTest
{
    [TestClass]
    public class NotEmptyValidationRule_Test
    {
        [TestMethod]
        public void TestNonEmpty()
        {
            string testString = "nonEmptyString";
            NotEmptyValidationRule validator = new NotEmptyValidationRule();
            ValidationResult test = validator.Validate(testString, new CultureInfo("pl-PL", false));
            Assert.IsTrue(test.IsValid);
        }

        [TestMethod]
        public void TestEmpty()
        {
            string testString = "0";
            NotEmptyValidationRule validator = new NotEmptyValidationRule();
            ValidationResult test = validator.Validate(testString, new CultureInfo("pl-PL", false));
            Assert.IsFalse(test.IsValid);
        }
    }
}
