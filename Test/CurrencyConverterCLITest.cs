using CurrencyConverter;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System.Collections.Generic;

namespace Test
{
    public class CurrencyConverterCLITest
    {
        public class ProgramTests
    {
        [Test]
        public void ConvertCurrency_ConvertsCorrectly()
        {
            // Arrange
            decimal amount = 100m;
            string fromCurrency = "USD";
            string toCurrency = "EUR";
            var rates = new Dictionary<string, decimal>
            {
                {"USD", 1m},
                {"EUR", 0.93m},
                {"GBP", 0.76m},
                {"JPY", 130.53m},
                {"AUD", 1.31m}
            };

            // Act
           decimal convertedAmount = Program.ConvertCurrency(amount, fromCurrency, toCurrency, rates);

            // Assert
            ClassicAssert.AreEqual(93m, convertedAmount);
        }

        [Test]
        public void ConvertCurrency_ReturnsZero_WhenCurrencyNotSupported()
        {
            // Arrange
            decimal amount = 100m;
            string fromCurrency = "USD";
            
            // not supported currency
            string toCurrency = "CAD"; 
            var rates = new Dictionary<string, decimal>
            {
                {"USD", 1m},
                {"EUR", 0.93m},
                {"GBP", 0.76m},
                {"JPY", 130.53m},
                {"AUD", 1.31m}
            };

            Assert.Throws<KeyNotFoundException>(() =>
            {
                Program.ConvertCurrency(amount, fromCurrency, toCurrency, rates);
            });
                }
    }
    }
}