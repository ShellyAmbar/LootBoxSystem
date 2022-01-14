using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootBoxSystem.extentions
{
    public static class RandomList
    {
        static Random rnd = new Random();

        public static TValue pickRandom<TValue>(this List<TValue> list)
        {
            int indexRandomItem = rnd.Next(list.Count);
            TValue item = (TValue)list[indexRandomItem];
            return item;
        }
    }
}
