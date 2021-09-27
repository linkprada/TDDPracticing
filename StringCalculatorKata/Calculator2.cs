
using System;
using System.Collections.Generic;

namespace StringCalculatorKata
{
    public class Calculator2
    {
        public int Add(string numberString)
        {
            if (string.IsNullOrEmpty(numberString))
            {
                return 0;
            }

            var delimiters = new List<string> { ",", "\n" };

            if (numberString.StartsWith("//"))
            {
                var delimitersAndNumbers = numberString.Replace("//", string.Empty).Split("\n", 2);

                var customDelimiters = delimitersAndNumbers[0].Replace("]", string.Empty).Split("[");

                delimiters.AddRange(customDelimiters);

                numberString = delimitersAndNumbers[1];
            }

            var numbers = numberString.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var negativeNumbers = new List<int>();

            int sum = 0, number;
            for (int i = 0; i < numbers.Length; i++)
            {
                number = int.Parse(numbers[i]);

                if (number < 0)
                {
                    negativeNumbers.Add(number);
                }

                if (number >= 1000)
                {
                    continue;
                }

                sum += int.Parse(numbers[i]);
            }

            if (negativeNumbers.Count > 0)
            {
                throw new NegativesNotAllowedException(string.Join(",",negativeNumbers));
            }

            return sum;
        }
    }
}
