using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using LootBoxSystem.extentions;

namespace LootBoxSystem
{
    internal class LootGenerator
    {
        
        public string[] propabiliteis;
        public JObject propabiliteisItems;
        public int maxItems = 2;

        public LootGenerator(string[] propabiliteis, JObject propabiliteisItems)
        {
            this.propabiliteis = propabiliteis;
            this.propabiliteisItems = propabiliteisItems;
        }

        public List<LootPool> generatePools()
        {
            List<LootPool> pools = new List<LootPool>();
            Console.WriteLine($"Creating pool of {propabiliteis}");
            foreach (string propability in propabiliteis)
            {
                List<AItem> aItems = new List<AItem>();
                Dictionary<string, List<AItem>> possibleItems = new Dictionary<string, List<AItem>>();  
                JArray items = (JArray)this.propabiliteisItems[propability];

                foreach (JObject item in items)
                {
                    AItem aItem = ItemFactory.getAItem(item);
                    possibleItems.AddOrUpdate(aItem.GetType().Name, aItem);
                }
                Console.WriteLine($"Creating pool of {propability}");
                LootPool pool = new LootPool(possibleItems, maxItems, propability);
                pools.Add(pool);    
            }
            return pools;
        }
    }
}
