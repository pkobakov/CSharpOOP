using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion(int weight) : base(weight=5)
        {
        }

        public void AffectCharacter(Character character)
        { 
        
        }
    }
}
