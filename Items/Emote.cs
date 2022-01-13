using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootBoxSystem
{
    internal class Emote : AItem
    {
        private string animationName;

        public Emote(string animationName)
        {
            this.animationName = animationName;
        }

        public string AnimationName
        
        {
           get { return animationName; }   
           set { animationName = value; }  
        }
        

        public override string getValue()
        {
            return $"You got a new emote: {AnimationName}.";
        }

    }
}
