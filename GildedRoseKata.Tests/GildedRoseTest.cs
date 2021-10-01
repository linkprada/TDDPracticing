using Xunit;
using System.Collections.Generic;

namespace GildedRoseKata.Tests
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_TestItemInInventory_DenotesStatus()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 0 } };
            GildedRose gildedRose = new(Items);
            gildedRose.UpdateQuality();
            Assert.Equal("test", Items[0].Name);
            Assert.Equal(0, Items[0].SellIn);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_TestItemInInventoryBeforeSaleDatePassed_DecreaseQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = 1, Quality = 1 } };
            GildedRose gildedRose = new(Items);
            gildedRose.UpdateQuality();
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_TestItemInInventory_DecreaseSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "test", SellIn = 2, Quality = 1 } };
            GildedRose gildedRose = new(Items);
            gildedRose.UpdateQuality();
            Assert.Equal(1, Items[0].SellIn);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.SaleDatePassed_DecreaseQualityTwice_DataGenerator), 
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_SaleDatePassed_DecreaseQualityTwice(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_DecreaseQuality_NeverNegative_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_DecreaseQuality_NeverNegative(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_IncreaseQuality_NeverGreaterThanFifty_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_IncreaseQuality_NeverGreaterThanFifty(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_AgedBrie_IncreaseQualityAsOlder_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_AgedBrie_IncreaseQualityAsOlder(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_Sulfuras_DoNothing_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_Sulfuras_DoNothing(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_BackstagePassesSaleDateGreaterThanTenDays_IncreaseQuality_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_BackstagePassesSaleDateGreaterThanTenDays_IncreaseQuality(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_BackstagePassesSaleDateBetweenTenAndFiveDays_IncreaseQualityByTwo_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_BackstagePassesSaleDateBetweenTenAndFiveDays_IncreaseQualityByTwo(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_BackstagePassesSaleDateLessThanSixDays_IncreaseQualityByThree_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_BackstagePassesSaleDateLessThanSixDays_IncreaseQualityByThree(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_BackstagePassesSaleDatePassed_QualityEqualZero_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_BackstagePassesSaleDatePassed_QualityEqualZero(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_ConjuredItem_DecreaseTwiceAsNormal_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_ConjuredItem_DecreaseTwiceAsNormal(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }
        
        [Theory]
        [MemberData(
            nameof(ItemsDataGenerator.UpdateQuality_ConjuredItemSaleDatePassed_DecreaseTwiceAsNormal_DataGenerator),
            MemberType = typeof(ItemsDataGenerator)
        )]
        public void UpdateQuality_ConjuredItemSaleDatePassed_DecreaseTwiceAsNormal(Item inputItem, int expectedQuality)
        {
            TestUpdateQuality(inputItem, expectedQuality);
        }

        private static void TestUpdateQuality(Item inputItem, int expectedQuality)
        {
            IList<Item> Items = new List<Item> { inputItem };
            GildedRose gildedRose = new(Items);
            gildedRose.UpdateQuality();
            Assert.Equal(expectedQuality, Items[0].Quality);
        }
    }
}
