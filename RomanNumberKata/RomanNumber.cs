using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanNumberKata
{
    public class RomanNumber
    {
        private readonly Dictionary<int, string> _baseNumbersDictionary = new Dictionary<int, string>()
        {
            { 1, "I" },
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" },
        };

        public string Convert(int number)
        {
            if (_baseNumbersDictionary.ContainsKey(number))
            {
                return _baseNumbersDictionary[number];
            }

            var romanNumber = "";
            var subNumber = 0;

            while (number > 0)
            {
                var baseNumber = _baseNumbersDictionary.Keys.Last(b => b <= number);

                subNumber = ExtractSubNumber(number);

                if (subNumber < 10)
                {
                    subNumber = number;
                }

                if (_baseNumbersDictionary.ContainsKey(subNumber))
                {
                    romanNumber += _baseNumbersDictionary[subNumber];
                    number -= subNumber;
                }
                else if (subNumber.ToString().Contains("9"))
                {
                    romanNumber += ConvertNumberContainsNine(baseNumber);
                    number -= subNumber;
                }
                else if (subNumber.ToString().Contains("4"))
                {
                    romanNumber += ConvertNumberContainsFour(baseNumber);
                    number -= subNumber;
                }
                else
                {
                    var quotient = subNumber / baseNumber;
                    for (int i = 0; i < quotient; i++)
                    {
                        romanNumber += _baseNumbersDictionary[baseNumber];
                        number -= baseNumber;
                    }
                }
            }

            return romanNumber;
        }

        private int ExtractSubNumber(int number)
        {
            int reminder;
            switch (number)
            {
                case > 1000:
                    reminder = number % 1000;
                    break;
                case > 100:
                    reminder = number % 100;
                    break;
                case > 10:
                    reminder = number % 10;
                    break;
                default:
                    reminder = number;
                    break;
            }

            return number - reminder;
        }

        private string ConvertNumberContainsNine(int baseNumber)
        {
            var baseGreaterThanNumber = _baseNumbersDictionary.Keys.First(key => key > baseNumber);
            var baseLesserThanNumber = _baseNumbersDictionary.Keys.Last(key => key < baseNumber);
            return _baseNumbersDictionary[baseLesserThanNumber] + _baseNumbersDictionary[baseGreaterThanNumber];
        }

        private string ConvertNumberContainsFour(int baseNumber)
        {
            var baseGreaterThanNumber = _baseNumbersDictionary.Keys.First(key => key > baseNumber);
            return _baseNumbersDictionary[baseNumber] + _baseNumbersDictionary[baseGreaterThanNumber];
        }
    }
}
