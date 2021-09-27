
using System.Collections.Generic;
using System.Linq;

namespace GreedKata
{
    public class GreedGame
    {
        public int Score (int[] roll)
        {
            int score = 0, pairs = 0;
            List<int> pairsNumber = new List<int>();
            for (int number = 1; number < 6; number++)
            {
                var numberCount = roll.Count(n => n == number);

                if (numberCount == 0)
                {
                    continue;
                }

                if (roll.Count() == roll.Distinct().Count())
                {
                    return 1200;
                }

                if (numberCount == 6)
                {
                    return TripleComboScore(number) * 8;
                }
                
                if (numberCount == 5)
                {
                    score += TripleComboScore(number) * 4;
                }
                else if (numberCount == 4)
                {
                    score += TripleComboScore(number) * 2;
                }
                else if (numberCount == 3)
                {
                    score += TripleComboScore(number);
                }
                else if (numberCount == 2)
                {
                    pairs++;
                    pairsNumber.Add(number);
                    if (pairs == 3)
                    {
                        return 800;
                    }
                }
                else
                {
                    score += NoComboScore(number);
                }                
            }

            if (pairsNumber.Count < 3)
            {
                if (pairsNumber.Contains(1))
                {
                    score += 100 * 2;
                }
                if (pairsNumber.Contains(5))
                {
                    score += 50 * 2;
                }
            }

            return score;
        }

        private static int TripleComboScore(int number)
        {
            var score = number * 100;
            if (number == 1)
            {
                score += 900;
            }

            return score;
        }

        private static int NoComboScore(int number)
        {
            if (number == 1)
            {
                return 100;
            }
            if (number == 5)
            {
                return 50;
            }

            return 0;
        }
    }
}
