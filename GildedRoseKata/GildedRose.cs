using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            const int MaxQualityValue = 50;
            const int MinQualityValue = 0;
            Item currentItem ;
            for (var i = 0; i < Items.Count; i++)
            {
                currentItem = Items[i];

                if (currentItem.Name == "Sulfuras, Hand of Ragnaros")
                {
                    continue;
                }

                if (currentItem.Name != "Aged Brie" 
                    && currentItem.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (currentItem.Quality > MinQualityValue)
                    {
                        currentItem.Quality--;

                        if (currentItem.Name.StartsWith("Conjured"))
                        {
                            currentItem.Quality--;
                        }
                    }
                }
                else
                {
                    if (currentItem.Quality < MaxQualityValue)
                    {
                        currentItem.Quality++;

                        if (currentItem.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (currentItem.SellIn < 11)
                            {
                                if (currentItem.Quality < MaxQualityValue)
                                {
                                    currentItem.Quality++;
                                }

                                if (currentItem.SellIn < 6)
                                {
                                    if (currentItem.Quality < MaxQualityValue)
                                    {
                                        currentItem.Quality++;
                                    }
                                }
                            }
                        }
                    }
                }

                currentItem.SellIn--;

                if (currentItem.SellIn < 0)
                {
                    if (currentItem.Name != "Aged Brie")
                    {
                        if (currentItem.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (currentItem.Quality > MinQualityValue)
                            {
                                currentItem.Quality--;

                                if (currentItem.Name.StartsWith("Conjured"))
                                {
                                    currentItem.Quality--;
                                }
                            }
                        }
                        else
                        {
                            currentItem.Quality = 0;
                        }
                    }
                    else
                    {
                        if (currentItem.Quality < MaxQualityValue)
                        {
                            currentItem.Quality++;
                        }
                    }
                }
            }
        }
    }
}
