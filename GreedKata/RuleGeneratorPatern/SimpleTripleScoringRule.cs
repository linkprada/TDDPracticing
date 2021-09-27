using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedKata.RuleGeneratorPatern
{
    public class SimpleTripleScoringRule : ScoringBase, IScoringRule
    {
        private readonly int _pipCount;

        public SimpleTripleScoringRule(int pipCount)
        {
            _pipCount = pipCount;
        }

        public int ApplyRule(List<int> diceRolled)
        {
            if (diceRolled.Count(d => d == _pipCount) == 3)
            {
                RemoveUsedDice(diceRolled, _pipCount, _pipCount, _pipCount);
                return _pipCount * 100;
            }

            return 0;
        }
    }
}
