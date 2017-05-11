using System;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Card
    {
        public Color? Color { get; private set; }
        public Point Position { get; private set; }

        public Card(Color? color, Point position)
        {
            Color = color;
            Position = position;
        }
    }
}

