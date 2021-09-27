using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WardrobeKata
{
    public class Wardrobe
    {
        public int Size { get; set; }

        public Wardrobe(int size)
        {
            Size = size;
        }

        public List<List<int>> Fill(List<int> elements)
        {
            //var isSizeGreaterThanOneElement = elements.Any(e => Size >= e);

            //if (!isSizeGreaterThanOneElement)
            //{
            //    return new List<int>(); ;
            //}

            var combinationList = new List<int>();
            var result = new List<List<int>>();

            var elementsSum = 0;
            foreach (var element in elements)
            {
                while (elementsSum < Size)
                {
                    elementsSum += element;
                    combinationList.Add(element);
                }

                result.Add(combinationList);
            }

            return result;
        }
    }
}
