using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootBoxSystem
{
    internal class Skin : AItem
    {
        private string name;

        public Skin(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }   
            set { name = value; } 
        }

        public override string getValue()
        {
            return $"You got a new skin: {Name}.";
        }
    }
}
