using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzKata
{
    public class FizzBuzz
    {
        public string PrintNumber(int number)
        {
            string result = "";
            if (number % 3 == 0 || number.ToString().Contains("3"))
            {
                result += "Fizz";
            }
            if (number % 5 == 0 || number.ToString().Contains("5"))
            {
                result += "Buzz";
            }
            if (result.Length == 0)
            {
                result = number.ToString();
            }

            return result;
        }
    }
}
