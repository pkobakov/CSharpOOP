﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
   public class TrapCard:Card
    {
        private const int trapCardDamagePoints = 120;
        private const int trapCardHealthPoints = 5;
        public TrapCard(string name) : base(name, trapCardDamagePoints, trapCardHealthPoints)
        {

        }
    }
}
