using System;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Player
    {
        public Color Color { get; private set; }
        public int Score { get; private set;}
    
        public Player(Color color)
        {
            Color = color;
            Score = 0;
        }
    }
}

