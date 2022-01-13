using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootBoxSystem
{
    internal class Coin : AItem
    {
        
        public Coin(int amount)
        {
            Amount = amount;
        }
        private int amount;
        public int Amount
        {
            get { return amount; }  
            set { amount = value; } 
        }

        public override string getValue()
        {
            return $"You got {Amount} coins.";
        }

    }
}
