using System;
using Com.Yosi.Linkar.Code.Models.GameItems;
using System.Collections.Generic;

namespace Com.Yosi.Linkar.Code.Models.Graph
{
    public class Node
    {
        public Point Position { get; private set; }
        public int Distance { get; private set; }

        public Node(Point position, int distance)
        {
            Position = position;
            Distance = distance;
        }

        public List<Point> GetNeighbourPoints()
        {
            return new List<Point>()
            {
                new Point(Position.X - 1, Position.Y),
                new Point(Position.X, Position.Y - 1),
                new Point(Position.X + 1, Position.Y),
                new Point(Position.X, Position.Y + 1)
            };
        }
    }
}

