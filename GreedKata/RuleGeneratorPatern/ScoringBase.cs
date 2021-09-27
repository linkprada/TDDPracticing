using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedKata.RuleGeneratorPatern
{
    public abstract class ScoringBase
    {
        protected static void RemoveUsedDice(IList<int> diceRolled, params int[] diceUsed)
        {
            foreach (var dieUsed in diceUsed)
            {
                diceRolled.Remove(dieUsed);
            }
        }
    }
}
