using System;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Player
    {
        public CardType Color { get; private set; }
        public int Score { get; private set;}
    
        public Player(CardType color)
        {
            Color = color;
            Score = 0;
        }
    }
}

