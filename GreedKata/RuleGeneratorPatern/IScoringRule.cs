using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedKata.RuleGeneratorPatern
{
    public interface IScoringRule
    {
        int ApplyRule(List<int> diceRolled);
    }
}
