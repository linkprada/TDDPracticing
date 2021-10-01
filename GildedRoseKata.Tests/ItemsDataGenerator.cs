using Xunit;

namespace GildedRoseKata.Tests
{
    public class ItemsDataGenerator
    {
        public static TheoryData<Item, int> SaleDatePassed_DecreaseQualityTwice_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "test", SellIn = -1, Quality = 5 }, 3},
                { new Item { Name = "test1", SellIn = -2, Quality = 10 }, 8},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_DecreaseQuality_NeverNegative_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "test", SellIn = -1, Quality = 1 }, 0},
                { new Item { Name = "test1", SellIn = -2, Quality = 0 }, 0},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_IncreaseQuality_NeverGreaterThanFifty_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Aged Brie", SellIn = 3, Quality = 50 }, 50},
                { new Item { Name = "Aged Brie", SellIn = -2, Quality = 48 }, 50},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_AgedBrie_IncreaseQualityAsOlder_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Aged Brie", SellIn = 10, Quality = 21 }, 22},
                { new Item { Name = "Aged Brie", SellIn = -2, Quality = 38 }, 40},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_Sulfuras_DoNothing_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 }, 80},
                { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -2, Quality = 80 }, 80},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_BackstagePassesSaleDateGreaterThanTenDays_IncreaseQuality_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 19, Quality = 13 }, 14},
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 13, Quality = 20 }, 21},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_BackstagePassesSaleDateBetweenTenAndFiveDays_IncreaseQualityByTwo_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 13 }, 15},
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 20 }, 22},
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 7, Quality = 49 }, 50},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_BackstagePassesSaleDateLessThanSixDays_IncreaseQualityByThree_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 17 }, 20},
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 }, 33},
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 3, Quality = 48 }, 50},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_BackstagePassesSaleDatePassed_QualityEqualZero_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 17 }, 0},
                { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -3, Quality = 30 }, 0},
            };
        }
        
        public static TheoryData<Item, int> UpdateQuality_ConjuredItem_DecreaseTwiceAsNormal_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Conjured Test", SellIn = 5, Quality = 17 }, 15},
                { new Item { Name = "Conjured Test1", SellIn = 20, Quality = 30 }, 28},
            };
        }

        public static TheoryData<Item, int> UpdateQuality_ConjuredItemSaleDatePassed_DecreaseTwiceAsNormal_DataGenerator()
        {
            return new TheoryData<Item, int>
            {
                { new Item { Name = "Conjured Test", SellIn = -1, Quality = 17 }, 13},
                { new Item { Name = "Conjured Test1", SellIn = -3, Quality = 30 }, 26},
            };
        }
    }
}
