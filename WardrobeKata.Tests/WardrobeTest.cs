using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace WardrobeKata.Tests
{
    public class WardrobeTest
    {
        [Fact]
        public void Constructor_NewWardrobe_MustHaveSize()
        {
            var wardrobe = new Wardrobe(1);

            Assert.NotEqual(0, wardrobe.Size);
        }

        [Fact]
        public void Fill_WardrobeWithOneElement_ReturnsCombinationEqualToWardrobeSize()
        {
            var input = new List<int> { 1 };
            var wardrobe = new Wardrobe(2);

            var combinationElementsList = wardrobe.Fill(input);

            Assert.True(combinationElementsList[0].SequenceEqual((new int[] { 1, 1 })));
        }

        //[Theory]
        //[InlineData(new int[] { 3,1 })]
        //public void Fill_NoElementIsLessThanWardrobeSize_ReturnsNoCombination(int[] input)
        //{
        //    var wardrobe = new Wardrobe(2);

        //    var combinationElementsList = wardrobe.Fill(input);

        //    Assert.False(combinationElementsList.Any());
        //}

        [Theory]
        [MemberData(nameof(DataGenerator))]
        public void Fill_WardrobeWithTwoElement_ReturnsMultipleCombinationEqualToWardrobeSize(List<int>, List<List<int>> data)
        {
            var input = data[0];
            var expected = data[1];
            var wardrobe = new Wardrobe(2);

            var combinationElementsList = wardrobe.Fill(input);

            Assert.(combinationElementsList, cel => cel.Sum() == wardrobe.Size);
        }

        public static TheoryData<List<int>,List<List<int>>> DataGenerator()
        {
            return new TheoryData<List<int>, List<List<int>>>
            {
                {
                    new List<int> { 1, 2 },
                    new List<List<int>>
                    {
                        new List<int> { 1, 1 },
                        new List<int> { 2 }
                    }
                }
            };
        }
    }
}
