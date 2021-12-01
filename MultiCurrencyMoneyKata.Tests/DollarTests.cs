using System;
using Xunit;

namespace MultiCurrencyMoneyKata.Tests
{
    // inspired from : TDD By Exemple Kent Beck
    public class DollarTests
    {
        [Fact]
        public void TestDollarMultiplication()
        {
            Money five = Money.dollar(5);
            Assert.Equal(Money.dollar(10), five.Times(2));
            Assert.Equal(Money.dollar(15), five.Times(3));
        }

        [Fact]
        public void TestEquality()
        {
            Assert.True(Money.dollar(5).Equals(Money.dollar(5)));
            Assert.False(Money.dollar(5).Equals(Money.dollar(6)));

            Assert.False(Money.franc(5).Equals(Money.dollar(5)));
        }

        [Fact]
        public void testCurrency()
        {
            Assert.Equal("USD", Money.dollar(1).Currency());
            Assert.Equal("CHF", Money.franc(1).Currency());
        }

        [Fact]
        public void testSimpleAddition()
        {
            var five = Money.dollar(5);
            IExpression sum = five.Plus(five);
            var bank = new Bank();
            var reduce = bank.Reduce(sum, "USD");
            Assert.Equal(Money.dollar(10), reduce);
        }

        [Fact]
        public void testPlusReturnsSum()
        {
            Money five = Money.dollar(5);
            IExpression result = five.Plus(five);
            Sum sum = (Sum)result;
            Assert.Equal(five, sum.augend);
            Assert.Equal(five, sum.addend);
        }

        [Fact]
        public void testReduceSum()
        {
            IExpression sum = new Sum(Money.dollar(3), Money.dollar(4));
            Bank bank = new Bank();
            Money result = bank.Reduce(sum, "USD");
            Assert.Equal(Money.dollar(7), result);
        }

        [Fact]
        public void testReduceMoney()
        {
            Bank bank = new Bank();
            Money result = bank.Reduce(Money.dollar(1), "USD");
            Assert.Equal(Money.dollar(1), result);
        }

        [Fact]
        public void testReduceMoneyDifferentCurrency()
        {
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(Money.franc(2), "USD");
            Assert.Equal(Money.dollar(1), result);
        }

        [Fact]
        public void testIdentityRate()
        {
            Assert.Equal(1, new Bank().Rate("USD", "USD"));
        }

        [Fact]
        public void testMixedAddition()
        {
            IExpression fiveBucks = Money.dollar(5);
            IExpression tenFrancs = Money.franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            Money result = bank.Reduce(fiveBucks.Plus(tenFrancs), "USD");
            Assert.Equal(Money.dollar(10), result);
        }

        [Fact]
        public void testSumPlusMoney()
        {
            IExpression fiveBucks = Money.dollar(5);
            IExpression tenFrancs = Money.franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            IExpression sum = new Sum(fiveBucks, tenFrancs).Plus(fiveBucks);
            Money result = bank.Reduce(sum, "USD");
            Assert.Equal(Money.dollar(15), result);
        }

        [Fact]
        public void testSumTimes()
        {
            IExpression fiveBucks = Money.dollar(5);
            IExpression tenFrancs = Money.franc(10);
            Bank bank = new Bank();
            bank.AddRate("CHF", "USD", 2);
            IExpression sum = new Sum(fiveBucks, tenFrancs).Times(2);
            Money result = bank.Reduce(sum, "USD");
            Assert.Equal(Money.dollar(20), result);
        }
    }
}
