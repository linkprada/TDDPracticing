using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            var delemiters = new List<string> { ",", "\n" };

            var hasDelimiters = numbers.StartsWith("//");
            if (hasDelimiters)
            {
                var splitedNumbersAndDelimiters = numbers.Replace("//", string.Empty).Split("\n", 2);

                ExtractDelimiters(delemiters, splitedNumbersAndDelimiters[0]);

                numbers = splitedNumbersAndDelimiters[1];
            }

            var splitedNumbers = ExtractNumbers(numbers, delemiters);

            ValidatePositiveNumbers(splitedNumbers);

            return splitedNumbers.Sum();
        }

        private static void ExtractDelimiters(List<string> delemiters, string delimitersString)
        {
            var customDelimiters = delimitersString.Replace("[", string.Empty).Split("]", StringSplitOptions.RemoveEmptyEntries);

            foreach (var delimiter in customDelimiters)
            {
                delemiters.Add(delimiter);
            }
        }

        private IEnumerable<int> ExtractNumbers(string numbers, List<string> delemiters)
        {
            return numbers.Split(delemiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(int.Parse)
                                                    .Where(n => n < 1000);
        }

        private void ValidatePositiveNumbers(IEnumerable<int> splitedNumbers)
        {
            var negativeNumbers = splitedNumbers.Where(n => n < 0);

            if (negativeNumbers.Any())
            {
                throw new NegativesNotAllowedException(string.Join(",", negativeNumbers));
            }
        }
    }
}
