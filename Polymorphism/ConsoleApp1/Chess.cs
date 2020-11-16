using System;
using System.Collections.Generic;
using System.Text;

namespace Demo
{
    public class Chess:Game
    {

        private bool isWhitePlaying;
        private Player playerFirst;
        private Player playerSecond;

        public Chess(Player playerFirst, Player playerSecond)
        {
            this.playerFirst = playerFirst;
            this.playerSecond = playerSecond;
        }
        public override void Start()
        {
            base.Start();

        }

        public override void Stop()
        {
            base.Stop();
        }

        public Player GetMovingPlayer() 
        {

            if (isWhitePlaying)
            {
                return playerFirst;
            }
            return playerSecond;
        }

        public override string GetDescription()
        {
            return $"{playerFirst.Name} is the winner. {playerSecond.Name} lost!!!";
        }

    }
}
