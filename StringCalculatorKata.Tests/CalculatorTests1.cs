using System;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class CalculatorTests1
    {
        [Fact]
        public void Add_InputEmptyString_ReturnsZero()
        {
            var calculator = new Calculator1();

            var result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Add_InputNumberString_ReturnsTheNumber(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2,3", 5)]
        public void Add_InputTwoNumbersSeparetedByComma_ReturnsTheNumbersSum(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,0", 3)]
        [InlineData("2,3,5,10", 20)]
        public void Add_InputMultipleNumbersSeparetedByComma_ReturnsTheNumbersSum(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1\n2,3\n9", 15)]
        public void Add_InputMultipleNumbersSeparetedByCommaOrNewLine_ReturnsTheNumbersSum(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//\t\n1\t2\n12", 15)]
        public void Add_InputMultipleNumbersSeparetedByCustomDelimiter_ReturnsTheNumbersSum(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-1,2", "-1")]
        [InlineData("2,-4,3,-5", "-4,-5")]
        public void Add_InputNegativeNumber_ThrowsNegativeNumbersNotAllowed(string input, string expected)
        {
            var calculator = new Calculator1();

            Action result = () => calculator.Add(input);

            var exception = Assert.Throws<NegativesNotAllowedException>(result);
            Assert.Equal($"Negatives not allowed:{expected}", exception.Message);
        }

        [Theory]
        [InlineData("1001,2", 2)]
        [InlineData("1010\n5", 5)]
        public void Add_InputNumberGreaterThanOneHundred_IgnoresNumbersGreaterThanOneHundred(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[|||]\n1|||2|||3", 6)]
        public void Add_InputNumbersSeparetedByCustomLengthDelimiter_ReturnsTheNumbersSum(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }
        
        [Theory]
        [InlineData("//[|][%]\n1|2%3", 6)]
        public void Add_InputNumbersSeparetedByMultipleDelimiters_ReturnsTheNumbersSum(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[||||][%][;;][@]\n1||||2%3;;9@10", 25)]
        public void Add_InputNumbersSeparetedByMultipleDelimitersOfAnyLength_ReturnsTheNumbersSum(string input, int expected)
        {
            var calculator = new Calculator1();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }
    }
}
