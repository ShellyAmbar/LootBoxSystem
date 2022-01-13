using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootBoxSystem
{
     public abstract class AItem
    {
        public string getMessage()
        {
            return this.getValue();
        }

        public override string ToString()
        {
            return this.getValue();
        }

        public abstract string getValue();


    }
}
