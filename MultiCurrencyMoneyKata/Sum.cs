using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCurrencyMoneyKata
{
    public class Sum : IExpression
    {
        public IExpression augend;
        public IExpression addend;

        public Sum(IExpression augend, IExpression addend)
        {
            this.augend = augend;
            this.addend = addend;
        }

        public Money Reduce(Bank bank, string to)
        {
            int amount = augend.Reduce(bank, to).amount + addend.Reduce(bank, to).amount;
            return new Money(amount, to);
        }

        public IExpression Plus(IExpression addEnd)
        {
            return new Sum(this, addEnd);
        }

        public IExpression Times(int multiplier)
        {
            return new Sum(augend.Times(multiplier),addend.Times(multiplier));
        }
    }
}
