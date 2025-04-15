using NUnit.Framework;
using NUnit.Framework.Legacy;
using Program;

namespace Program.Tests
{
    public class CalculatorTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Sum()
        {
            // Arrange
            double num1 = 5;
            double num2 = 3;

            // Act
            double result = _calculator.Add(num1, num2);

            // Assert
#pragma warning disable NUnit2005 // Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)
            ClassicAssert.AreEqual(8, result);
#pragma warning restore NUnit2005 // Consider using Assert.That(actual, Is.EqualTo(expected)) instead of ClassicAssert.AreEqual(expected, actual)
        }
    }
}
