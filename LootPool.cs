using System;
using System.Collections.Generic;
using System.Linq;
using LootBoxSystem.extentions;

namespace LootBoxSystem
{
    public class LootPool
    {
        private Dictionary<string, List<AItem>> possibleItems;
        private int maxItemsLooted;
        private List<AItem> items;
        private bool isGenerated;
        private List<string> itemNames;
        private string propability;
        public LootPool(Dictionary<string, List<AItem>> possibleItems, int maxItemsLooted, string propability, bool isGenerated=false)
        {
            this.possibleItems = possibleItems;
            this.maxItemsLooted = maxItemsLooted;
            this.isGenerated = isGenerated;
            this.propability = propability;
        }

        public void OpenBox()
        {
            Console.WriteLine($"User Opening box...of {this.propability}% propability ");
            this.getGeneratedItems();
            for (int i = 0; i < maxItemsLooted; i++)
            {
                Console.WriteLine("User Picking items...");
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
            initializeItems();

            for (int i = 0; i < maxItemsLooted; i++)
            {
                AItem item = getRandomItem();
                addItem(item);
            }
            this.isGenerated = true;
            return items;
        }

        private void addItem(AItem item)
        {
            items.Add(item);
            itemNames.Add(item.GetType().Name);
        }

        private void initializeItems()
        {
            items = new List<AItem>();
            itemNames = new List<string> { };
        }

        private AItem getRandomItem()
        {
            string[] keys = possibleItems.Keys.ToArray(); 
            List<string> possibleKeys = new List<string>(Array.FindAll(keys, c => !this.itemNames.Contains(c)));
            string key = possibleKeys.pickRandom();
            List<AItem> possibleItemsKey = possibleItems[key];
            AItem item = (AItem)possibleItemsKey.pickRandom();
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
