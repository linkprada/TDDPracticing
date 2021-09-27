using System;
using Xunit;

namespace FizzBuzzKata.Tests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void PrintNumber_InputNumberOne_PrintsNumnberOne()
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.PrintNumber(1);

            Assert.True(result.Equals("1"));
        }

        [Theory]
        [InlineData(2,"2")]
        [InlineData(4,"4")]
        [InlineData(11,"11")]
        public void PrintNumber_InputANumber_PrintsTheNumber(int input, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.PrintNumber(input);

            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData(3, "Fizz")]
        [InlineData(6, "Fizz")]
        [InlineData(12, "Fizz")]
        public void PrintNumber_InputNumberDivisibleByThree_PrintsFizz(int input, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.PrintNumber(input);

            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData(5, "Buzz")]
        [InlineData(10, "Buzz")]
        [InlineData(55, "Buzz")]
        public void PrintNumber_InputNumberDivisibleByFive_PrintsBuzz(int input, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.PrintNumber(input);

            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData(15, "FizzBuzz")]
        [InlineData(30, "FizzBuzz")]
        [InlineData(60, "FizzBuzz")]
        public void PrintNumber_InputNumberDivisibleByFiveAndThree_PrintsFizzBuzz(int input, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.PrintNumber(input);

            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData(13, "Fizz")]
        [InlineData(23, "Fizz")]
        [InlineData(73, "Fizz")]
        public void PrintNumber_InputNumberContainsThree_PrintsFizz(int input, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.PrintNumber(input);

            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData(52, "Buzz")]
        [InlineData(59, "Buzz")]
        [InlineData(56, "Buzz")]
        public void PrintNumber_InputNumberContainsFive_PrintsBuzz(int input, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.PrintNumber(input);

            Assert.True(result.Equals(expected));
        }

        [Theory]
        [InlineData(53, "FizzBuzz")]
        [InlineData(35, "FizzBuzz")]
        public void PrintNumber_InputNumberontainsFiveAndThree_PrintsFizzBuzz(int input, string expected)
        {
            var fizzBuzz = new FizzBuzz();

            var result = fizzBuzz.PrintNumber(input);

            Assert.True(result.Equals(expected));
        }
    }
}
