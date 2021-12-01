using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiCurrencyMoneyKata
{
    public class Bank
    {
        private readonly Dictionary<Pair, int> rates = new();

        public Money Reduce(IExpression source, string to)
        {
            return source.Reduce(this, to);
        }

        public void AddRate(string from, string to, int rate)
        {
            rates.Add(new Pair(from, to), rate);
        }

        public int Rate(string from, string to)
        {
            if (from.Equals(to))
            {
                return 1;
            }
            return rates[new Pair(from, to)];
        }

        private class Pair : IEquatable<Pair>
        {
            private readonly string _from;
            private readonly string _to;
            public Pair(string from, string to)
            {
                _from = from;
                _to = to;
            }

            public bool Equals(Pair other)
            {
                return _from.Equals(other._from) && _to.Equals(other._to);
            }

            public override int GetHashCode()
            {
                return 0;
            }
        }
    }
}
