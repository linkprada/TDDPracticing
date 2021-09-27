
using GreedKata.RuleGeneratorPatern;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreedKata
{
    public class GreedGame1
    {
        private readonly List<IScoringRule> _scoringRules;

        public GreedGame1()
        {
            _scoringRules = new List<IScoringRule> 
            {
                new ScoringTripleOneRule(),
                new SimpleTripleScoringRule(3),
                new SimpleTripleScoringRule(4),
                new SimpleTripleScoringRule(5),
                new SimpleTripleScoringRule(2),
                new SimpleTripleScoringRule(6),
                new SimpleScoringRule(5, 50),
                new SimpleScoringRule(1, 100),
            };
        }
        public int Score(List<int> diceRolled)
        {
            var totalScore = 0;

            foreach (var scoringRule in _scoringRules)
            {
                totalScore += scoringRule.ApplyRule(diceRolled);
            }

            return totalScore;
        }
    }
}
