using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StringCalculatorKata.Tests
{
    public class CalculatorTests
    {

        [Theory]
        [InlineData("",0)]
        [InlineData("1",1)]
        [InlineData("1,2",3)]
        public void Add_AddTwoNumbersSeparatedByComma(string calculation, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(calculation);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("0,0", 0)]
        [InlineData("5,10,20", 35)]
        [InlineData("1,2,3,4", 10)]
        public void Add_AddMultipleNumbersSeparatedByComma(string calculation, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(calculation);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1\n2,3", 6)]
        [InlineData("1,2\n3\n4", 10)]
        public void Add_AddMultipleNumbersSeparatedByNewLine(string calculation, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(calculation);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;2", 3)]
        //[InlineData("//;,\n1;2,3", 6)]
        public void Add_AddMultipleNumbersSeparatedByCustomDelimiter(string calculation, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(calculation);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//;\n1;2\n-3", "-3")]
        [InlineData("//;\n-1;-2,3", "-1,-2")]
        public void Add_AddNegativeNumberThrowException(string calculation, string negativeNumbers)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            Action action = () => sut.Add(calculation);
            //Assert
            var exception = Assert.Throws<NegativesNotAllowedException>(action);
            Assert.Contains(negativeNumbers, exception.Message);
        }

        [Theory]
        [InlineData("//;\n1000;2\n", 2)]
        [InlineData("//;\n1234;3,3", 6)]
        public void Add_AddNumbersGreaterThanOneHundredShouldBeIgnored(string calculation, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(calculation);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[***]\n1***2\n***3", 6)]
        [InlineData("//[***]\n1,2\n***8", 11)]
        public void Add_AddMultipleNumbersSeparatedByOneDelimitersWithDifferentLength(string calculation, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(calculation);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[*][%]\n1*2%3", 6)]
        [InlineData("//[*][k]\n1*2k8", 11)]
        public void Add_AddMultipleNumbersSeparatedByCustomDelimiters(string calculation, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(calculation);
            //Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("//[***][%%]\n1***2%%3", 6)]
        [InlineData("//[*][kyu]\n1*2kyu8", 11)]
        public void Add_AddMultipleNumbersSeparatedByCustomDelimitersWithDifferentLength(string calculation, int expected)
        {
            //Arrange
            var sut = new Calculator();
            //Act
            var result = sut.Add(calculation);
            //Assert
            Assert.Equal(expected, result);
        }

    }
}
