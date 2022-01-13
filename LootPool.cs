using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System;

namespace LootBoxSystem
{
    public class LootPool
    {
        private List<AItem> possibleItems;
        public int itemsGenerateCount;
        public List<AItem> items;
        private bool isGenerated;
        private string propability;
        static Random rnd = new Random();
        public LootPool(List<AItem> possibleItems, int itemsGenerateCount, string propability, bool isGenerated=false)
        {
            this.possibleItems = possibleItems;
            this.itemsGenerateCount = itemsGenerateCount;
            this.isGenerated = isGenerated;
            this.propability = propability;
        }

        public void OpenBox()
        {
            Console.WriteLine($"User Opening box...of {this.propability}% propability ");
            this.getGeneratedItems();
            for (int i = 0; i <= items.Count; i++)
            {
                Console.WriteLine("User Picking items");
                string message = this.PickItem();
                Console.WriteLine(message);
            }
        }
        List<AItem> getGeneratedItems()
        {
            if (this.isGenerated)
            {
                return items;
            }
            Console.WriteLine("Generating items...");
            items = new List<AItem>();
            for (int i = 0; i < itemsGenerateCount; i++)
            {
                AItem item = getRandomItem();
                items.Add(item);
            }
            this.isGenerated = true;
            return items;
        }

        private AItem getRandomItem()
        {
            int indexRandom = rnd.Next(possibleItems.Count);
            AItem item = (AItem)possibleItems[indexRandom];
            possibleItems.RemoveAt(indexRandom);
            return item;
        }
        public string PickItem()
        {
            AItem item = this.popItem();
            return item.getMessage();
        }
        AItem popItem()
        {
            int index = this.items.Count - 1;
            AItem item = this.items[index];
            this.items.RemoveAt(index);
            return item;
        }
        public override string ToString()
        {
            return $"{possibleItems}";
        }
    }
}
