
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class Calculator1
    {
        public int Add (string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };

            var hasCustomDelimiters = numbers.StartsWith("//");
            if (hasCustomDelimiters)
            {
                var numbersAndDelimiters = SplitNumbersAndCustomDelimiters(numbers);

                ExtractCustomDelimiters(delimiters, numbersAndDelimiters);

                numbers = numbersAndDelimiters.numbers;
            }

            var parsedNumbers = ExtractParsedNumbersIgnoreGreaterThanOneHundred(numbers, delimiters);

            ValidateNoNegativeNumbers(parsedNumbers);

            return parsedNumbers.Sum();
        }

        private static void ExtractCustomDelimiters(List<string> delimiters, (string customDelimiters, string numbers) numbersAndDelimiters)
        {
            var customDelimiters = numbersAndDelimiters.customDelimiters.Replace("[", string.Empty).Split("]");

            foreach (var delimiter in customDelimiters)
            {
                delimiters.Add(delimiter);
            }
        }

        private static (string customDelimiters, string numbers) SplitNumbersAndCustomDelimiters(string numbers)
        {
            var tmp = numbers.Replace("//", string.Empty).Split("\n", 2);
            return (customDelimiters: tmp[0], numbers: tmp[1]);
        }

        private static List<int> ExtractParsedNumbersIgnoreGreaterThanOneHundred(string numbers, List<string> delimiters)
        {
            return numbers.Split(delimiters.ToArray(), StringSplitOptions.None)
                .Select(n => int.Parse(n))
                .Where(n => n < 1000)
                .ToList();
        }

        private static void ValidateNoNegativeNumbers(List<int> parsedNumbers)
        {
            var negativeNumbers = parsedNumbers.Where(pn => pn < 0).ToList();

            if (negativeNumbers.Any())
            {
                throw new NegativesNotAllowedException(string.Join(",", negativeNumbers));
            }
        }
    }
}
