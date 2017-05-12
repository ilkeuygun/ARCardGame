using System;
using System.Collections.Generic;
using System.Linq;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Path
    {
        private const int FINISHER_BONUS = 15;
        private const int CARD_BONUS = 5;

        public List<Card> Cards { get; private set; }

        public Path(List<Point> points, Board board)
        {
            Cards = points.Select(p => board.Cards[p.X, p.Y]).ToList();
        }

        public override string ToString()
        {
            return String.Join("\n", Cards.Select(c => "Color: " + c.Color.ToString() + " -> " + c.Position.X + "-" + c.Position.Y).ToArray());
        }

        public Dictionary<CardType, int> GetPoints()
        {
            var points = new Dictionary<CardType, int>();
            points.Add(CardType.Blue, 0);
            points.Add(CardType.Red, 0);
            points.Add(CardType.Green, 0);
            points.Add(CardType.Yellow, 0);

            for (int i = 0; i < Cards.Count; i++)
            {
                if (Cards[i].Color != null)
                {
                    points[(CardType)Cards[i].Color] += CARD_BONUS;
                }
            }

            points[(CardType)Cards.Last().Color] += FINISHER_BONUS;

            return points;
        }
    }
}

