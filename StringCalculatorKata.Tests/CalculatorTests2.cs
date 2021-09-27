using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class CalculatorTests2
    {
        [Fact]
        public void Add_InputEmpty_ReturnsZero()
        {
            var calculator = new Calculator2();

            var result = calculator.Add("");

            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_StringNumber_ReturnsNumber()
        {
            var calculator = new Calculator2();

            var result = calculator.Add("1");

            Assert.Equal(1, result);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("2", 2)]
        public void Add_TwoStringNumbers_ReturnsSum(string input, int expected)
        {
            var calculator = new Calculator2();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1,2,6", 9)]
        [InlineData("2,3,9", 14)]
        public void Add_MultipleStringNumbers_ReturnsSum(string input, int expected)
        {
            var calculator = new Calculator2();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2,6", 9)]
        [InlineData("2,3\n9", 14)]
        public void Add_MultipleStringNumbersWithMultipleDelimiters_ReturnsSum(string input, int expected)
        {
            var calculator = new Calculator2();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//tt\n1tt2tt11", 14)]
        public void Add_MultipleStringNumbersWithCustomDelimiter_ReturnsSum(string input, int expected)
        {
            var calculator = new Calculator2();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;2,-13", "-13")]
        [InlineData("//tt\n-1tt2tt-11", "-1,-11")]
        public void Add_NegativeNumber_ThrowsExceptionWithAllNegativeNumbers(string input, string negativeNumbers)
        {
            var calculator = new Calculator2();

            Action result = () => calculator.Add(input);

            var exception = Assert.Throws<NegativesNotAllowedException>(result);
            Assert.Contains(negativeNumbers, exception.Message);
        }

        [Theory]
        [InlineData("//;\n1;2,1000", 3)]
        [InlineData("//tt\n1tt2tt5000", 3)]
        public void Add_NumbersGreaterThanOneThousand_IgnoredInSum(string input, int expected)
        {
            var calculator = new Calculator2();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[|||]\n1|||2|||3", 6)]
        [InlineData("//[...]\n1...2...10", 13)]
        public void Add_StringNumbersWithCustomDelimitersLength_ReturnsSum(string input, int expected)
        {
            var calculator = new Calculator2();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[|][%]\n1|2%3", 6)]
        [InlineData("//[...][&&]\n1...2&&10", 13)]
        public void Add_MultipleStringNumbersWithCustomDelimitersLength_ReturnsSum(string input, int expected)
        {
            var calculator = new Calculator2();

            var result = calculator.Add(input);

            Assert.Equal(expected, result);
        }
    }
}
