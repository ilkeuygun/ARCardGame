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
    }
}

