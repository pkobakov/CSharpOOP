using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory.Models;

namespace WarCroft.Entities.Characters.Contracts
{
	

    public abstract class Character
    {
		// TODO: Implement the rest of the class.
		private string name;

		public Character(string name, double baseHealth, double health, double armor, double abilityPoints)
        {
			this. Name = name;
			this.BaseHealth = baseHealth;
			this.Health = health;
			this.Armor = armor;
			this.AbilityPoints = abilityPoints;

        }
		public string Name 
		{
			get=> name;
			private set
			{
                if (string.IsNullOrWhiteSpace(value))
                {
					string exceptionMessage = string.Format(ExceptionMessages.CharacterNameInvalid);
					throw new ArgumentException(exceptionMessage);
                }

				name = value;
			}	
		}

        public double BaseHealth  { get; set; }
        public double Health { get; set; }
        public double Armor  { get; set; }
        public double AbilityPoints { get; set; }
        public Bag bag { get; set; }
        public bool IsAlive { get; set; } = true;

		protected void EnsureAlive()
		{
			if (!this.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}