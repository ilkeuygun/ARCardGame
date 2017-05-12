using System;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Card
    {
        public CardType? Color { get; private set; }
        public Point Position { get; private set; }

        public Card(CardType? color, Point position)
        {
            Color = color;
            Position = position;
        }
    }
}

