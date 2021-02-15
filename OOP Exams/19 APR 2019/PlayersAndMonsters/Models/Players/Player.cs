﻿
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;


namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private readonly ICardRepository cardRepository;
        private string username;
        private int health;

        public Player(ICardRepository cardRepository, string username, int health)
        {
           this.cardRepository = cardRepository;
            this.Username = username;
            this.Health = health;
        }



        public ICardRepository CardRepository => cardRepository;

        public string Username 
        {
            get => username;
            private set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");

                }

                username = value;
            
            }
        }

        public int Health
        {
            get => health;
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }

                health = value;
            }
        
        }

        public bool IsDead => this.Health <= 0 ;

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }

            if (Health < damagePoints)
            {
                Health = 0;

            }
            else
            {
                Health -= damagePoints;

            }
            

        }
    }
}
