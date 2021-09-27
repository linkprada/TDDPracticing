using System;
using Xunit;

namespace RomanNumberKata.Tests
{
    public class RomanNumberTest
    {
        [Fact]
        public void Convert_ConvertNumberOne_ReturnsRomanNumberOne()
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(1);

            Assert.Equal("I", convertedNumber);
        }

        [Fact]
        public void Convert_ConvertNumberTwo_ReturnsRomanNumberTwo()
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(2);

            Assert.Equal("II", convertedNumber);
        }

        [Fact]
        public void Convert_ConvertNumberTwo_ReturnsRomanNumberThree()
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(3);

            Assert.Equal("III", convertedNumber);
        }

        [Fact]
        public void Convert_ConvertNumberFive_ReturnsRomanNumberFive()
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(5);

            Assert.Equal("V", convertedNumber);
        }

        [Theory]
        [InlineData(6, "VI")]
        [InlineData(23, "XXIII")]
        [InlineData(105, "CV")]
        public void Convert_BaseNumberPlusAnotherOne_ReturnsNormalRomanNumber(int input, string expected)
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(input);

            Assert.Equal(expected, convertedNumber);
        }

        [Theory]
        [InlineData(4, "IV")]
        [InlineData(407, "CDVII")]
        [InlineData(74, "LXXIV")]
        //[InlineData(49, "XLIX")]
        public void Convert_NumberHasFour_ReturnsRomanNumberConstructedWithRomanFour(int input, string expected)
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(input);

            Assert.Equal(expected, convertedNumber);
        }

        [Theory]
        [InlineData(19, "XIX")]
        [InlineData(59, "LIX")]
        [InlineData(90, "XC")]
        public void Convert_NumberHasNine_ReturnsRomanNumberConstructedWithRomanNine(int input, string expected)
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(input);

            Assert.Equal(expected, convertedNumber);
        }

        [Theory]
        [InlineData(18, "XVIII")]
        [InlineData(72, "LXXII")]
        [InlineData(54, "LIV")]
        public void Convert_NumberDoesNotHaveNine_ReturnsRomanNumberConstructedFromBases(int input, string expected)
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(input);

            Assert.Equal(expected, convertedNumber);
        }

        [Theory]
        [InlineData(12, "XII")]
        [InlineData(36, "XXXVI")]
        [InlineData(68, "LXVIII")]
        public void Convert_NumberDoesNotHaveFour_ReturnsRomanNumberConstructedFromBases(int input, string expected)
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(input);

            Assert.Equal(expected, convertedNumber);
        }

        [Fact]
        public void Convert_BigNumber_ReturnsRomanRepresantation()
        {
            var romanNumber = new RomanNumber();

            var convertedNumber = romanNumber.Convert(1999);

            Assert.Equal("MCMXCIX", convertedNumber);
        }

    }
}
