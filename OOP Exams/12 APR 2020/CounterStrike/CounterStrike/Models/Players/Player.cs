using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;
        
        public Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    string msg = String.Format(ExceptionMessages.InvalidPlayerName);
                    throw new ArgumentException(msg);
                }

                username = value;
            }

        }


        public int Health 
        {  
            get => health;

            private set 
            {
                if (value<0)
                {
                    string msg = String.Format(ExceptionMessages.InvalidPlayerName);
                    throw new ArgumentException(msg);
                }

                health = value;
            }
        }

        public int Armor 
        {
            get => armor;

            private set
            {

                if (value < 0)
                {
                    string msg = String.Format(ExceptionMessages.InvalidPlayerArmor);
                    throw new ArgumentException(msg);
                }


                armor = value;
            }

           
        }
        public IGun Gun 
        { 
            get => gun;

            private set 
            {
                if (value == null)
                {
                    string msg = String.Format(ExceptionMessages.InvalidGunType);
                    throw new ArgumentException(msg);
                }
                
                gun = value;

            }
        
        }

        public bool IsAlive
        {
            get => Health > 0;
        
        }

        public void TakeDamage(int points) 
        {
           
            if (armor-points>=0)
            {
                armor -= points; //First you need to reduce the armor.
              
            }
            else if (armor > 0)
            {
                points -= armor;
                armor = 0;
            }

            health -= points;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name}: {this.Username}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armor: {this.Armor}");
            sb.AppendLine($"--Gun: {this.Gun.Name}");

            return sb.ToString().Trim();
        }
    }
}
