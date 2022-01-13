using Newtonsoft.Json.Linq;
using System;

namespace LootBoxSystem
{
    internal class ItemFactory
    {
        internal static AItem getAItem(JObject item)
        {
            
            if (item.ContainsKey("Amount"))
            {
                int amount = (int)item["Amount"];
                AItem aItem = new Coin(amount);
                return aItem;
            }

            if (item.ContainsKey("AnimationName"))
            {
                string animationName = (string)item["AnimationName"];
                AItem aItem = new Emote(animationName);
                return aItem;
            }

            if (item.ContainsKey("Name"))
            {
                string name = (string)item["Name"];
                AItem aItem = new Skin(name);
                return aItem;
            }


            throw new Exception("raw item now implemented");

        }
    }
}