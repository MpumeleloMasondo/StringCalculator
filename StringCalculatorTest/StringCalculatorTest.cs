using AddCalculator;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class StringCalculatorTest
    {
        public StringCalculator addCalculator;

        [SetUp]
        public void Setup()
        {
            addCalculator = new StringCalculator();
        }

        public int CalculateNumbers(string numbers)
        {

            int result = addCalculator.Add(numbers);

            return result;
        }

        [Test]
        [TestCase("", ExpectedResult = 0)]
        [TestCase(null, ExpectedResult = 0)]
        public int Return0WhenNullOrEmptyString(string numbers)
        {
            return CalculateNumbers(numbers);
        }

        [Test]
        [TestCase("1", ExpectedResult = 1)]
        [TestCase("20", ExpectedResult = 20)]
        public int ReturnExactNumberString(string numbers)
        {
            return CalculateNumbers(numbers);
        }

        [Test]
        [TestCase("3,2", ExpectedResult = 5)]
        [TestCase("23,22", ExpectedResult = 45)]
        public int ReturnSumOfTwoNumbers(string numbers)
        {
            return CalculateNumbers(numbers);
        }

        [Test]
        [TestCase("1,2,3,4", ExpectedResult = 10)]
        [TestCase("21,22,23,24,25", ExpectedResult = 115)]
        public int ReturnSumOfMultipleNumbers(string numbers)
        {
            return CalculateNumbers(numbers);
        }

        [Test]
        [TestCase("1\n3", ExpectedResult = 4)]
        [TestCase("1\n10", ExpectedResult = 11)]
        [TestCase("1\n1,3", ExpectedResult = 5)]
        [TestCase("1\n5,4", ExpectedResult = 10)]
        public int ReturnsSumOfNumbersWhenNewLineDelimiter(string numbers)
        {
            return CalculateNumbers(numbers);
        }

        [Test]
        [TestCase("//$\n1", ExpectedResult = 1)]
        [TestCase("//$\n1$2", ExpectedResult = 3)]
        [TestCase("//$\n1$2,3", ExpectedResult = 6)]
        [TestCase("//$\n1$2,3\n4", ExpectedResult = 10)]
        [TestCase("//$\n1$2,3\n4$5", ExpectedResult = 15)]
        public int ReturnsSumOfNumbersWhenCustomDelimiter(string numbers)
        {
            return CalculateNumbers(numbers);
        }

        [Test]
        [TestCase("-1", "-1")]
        [TestCase("1,-3", "-3")]
        [TestCase("1\n-4", "-4")]
        [TestCase("//$\n-1", "-1")]
        [TestCase("//$\n1$-2", "-2")]
        [TestCase("//$\n1$-2,3", "-2")]
        [TestCase("//$\n1$-2,-3\n4", "-2,-3")]
        [TestCase("//$\n1$2,3\n4$-5", "-5")]
        public void ThrowsNegativeNumberException(string numbers, string negativeNumbers)
        {
            //Act
            // var exception = Assert.Throws<ArgumentException>(() => CalculateNumbers(numbers));

            //Assert
            //exception.Message.ShouldBe($"negatives not allowed '{negativeNumbers}'");

            // Assert.AreEqual("Cannot read temperature before initializing.", exception.Message);

            Assert.Throws<FormatException>(() => CalculateNumbers(numbers));

            //var negativeNumberException = CalculateNumbers(numbers);

            //Assert.AreEqual($"negatives not allowed '{negativeNumbers}'", negativeNumberException);
        }

        [Test]
        [TestCase("1001", ExpectedResult = 0)]
        [TestCase("1,1001", ExpectedResult = 1)]
        [TestCase("1\n1001", ExpectedResult = 1)]
        [TestCase("//$\n1,1001", ExpectedResult = 1)]
        [TestCase("//$\n2$1002", ExpectedResult = 2)]
        [TestCase("//$\n2$2,1001", ExpectedResult = 4)]
        public int ReturnCorrectSumWhenIgnoringNumbersGreaterThan1000(string numbers)
        {
            return CalculateNumbers(numbers);
        }

        [Test]
        [TestCase("//[>>]\n1>>2", ExpectedResult = 3)]
        [TestCase("//[-]\n1-2-3", ExpectedResult = 6)]
        [TestCase("//[-]\n1--2-3", ExpectedResult = 6)]
        [TestCase("//[@@][..]\n1@@2..3", ExpectedResult = 6)]
        [TestCase("//[$$][**]\n1$$2,3**4", ExpectedResult = 10)]
        [TestCase("//[***,&&&]\n1***2,3\n4&&&5", ExpectedResult = 15)]
        public int ReturnCorrectSumWithCustomDelimitersOfAnyLength(string numbers)
        {
            return CalculateNumbers(numbers);
        }

    }
}