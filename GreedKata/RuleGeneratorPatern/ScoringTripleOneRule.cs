using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedKata.RuleGeneratorPatern
{
    public class ScoringTripleOneRule : ScoringBase, IScoringRule
    {
        public int ApplyRule(List<int> diceRolled)
        {
            if (diceRolled.Count(d => d == 1) >= 3)
            {
                RemoveUsedDice(diceRolled, 1, 1, 1);
                return 1000;
            }

            return 0;
        }
    }
}
