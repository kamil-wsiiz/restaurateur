using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using Restaurateur.Rules;
using System.Windows.Controls;

namespace RestaurateurTest
{
    [TestClass]
    public class NotEmptyIntValidationRule_Test
    {
        [TestMethod]
        public void TestNonEmpty()
        {
            string testString = "0";
            NotEmptyIntValidationRule validator = new NotEmptyIntValidationRule();
            ValidationResult test = validator.Validate(testString, new CultureInfo("pl-PL", false));
            Assert.IsTrue(test.IsValid);
        }

        [TestMethod]
        public void TestEmpty()
        {
            string testString = "";
            NotEmptyIntValidationRule validator = new NotEmptyIntValidationRule();
            ValidationResult test = validator.Validate(testString, new CultureInfo("pl-PL", false));
            Assert.IsFalse(test.IsValid);
        }
    }
}
