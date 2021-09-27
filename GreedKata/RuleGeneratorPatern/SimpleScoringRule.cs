using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedKata.RuleGeneratorPatern
{
    public class SimpleScoringRule : IScoringRule
    {
        private readonly int _pipCount;
        private readonly int _value;

        public SimpleScoringRule(int pipCount, int value)
        {
            _pipCount = pipCount;
            _value = value;
        }

        public int ApplyRule(List<int> diceRolled)
        {
            return diceRolled.Count(d => d == _pipCount) * _value;
        }
    }
}
