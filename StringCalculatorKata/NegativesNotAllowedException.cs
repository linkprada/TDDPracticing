using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException()
        {
        }

        public NegativesNotAllowedException(string negativeValues)
            : base($"Negatives not allowed:{negativeValues}")
        {
        }

        public NegativesNotAllowedException(string negativeValues, Exception inner)
            : base($"Negatives not allowed:{negativeValues}", inner)
        {
        }
    }
}
