using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Path
    {
        public List<Card> Cards { get; private set; }

        public Path(List<Point> points, Board board)
        {
            Cards = points.Select(p => board.Cards[p.X, p.Y]).ToList();
        }

        public override string ToString()
        {
            return String.Join("\n", Cards.Select(c => "Color: " + c.Color.ToString() + " -> " + c.Position.X + "-" + c.Position.Y).ToArray());
        }
    }
}

