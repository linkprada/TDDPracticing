using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCurrencyMoneyKata
{
    public class Money : IEquatable<Money>, IExpression
    {
        internal int amount;
        protected string currency;

        public Money(int amount, string currency)
        {
            this.amount = amount;
            this.currency = currency;
        }

        public static Money dollar(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money franc(int amount)
        {
            return new Money(amount, "CHF");
        }

        public IExpression Times(int multiplier)
        {
            return new Money(amount * multiplier, currency);
        }

        public bool Equals(Money money)
        {
            return amount == money.amount
                && Currency().Equals(money.Currency());
        }

        public override string ToString()
        {
            return amount + " " + currency;
        }

        public IExpression Plus(IExpression addEnd)
        {
            return new Sum(this, addEnd);
        }

        public string Currency() 
        {
            return currency;   
        }

        public Money Reduce(Bank bank, string to)
        {
            int rate = bank.Rate(currency, to);
            return new Money(amount / rate, to);
        }
    }
}
