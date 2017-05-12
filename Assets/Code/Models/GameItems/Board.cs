using System;
using System.Linq;
using Com.Yosi.Linkar.Code.Util;
using System.Collections.Generic;
using Com.Yosi.Linkar.Code.Models.Graph;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Board
    {
        public const int SIZE = 15;
        private const int TARGET_AREA_SIZE = 4;

        public Card[,] Cards { get; private set; }

        public Point StartPosition { get; private set; }
        public Point TargetPosition { get; set; }

        public Board()
        {
            Cards = new Card[SIZE, SIZE];

            setStartPosition();
            setTargetPosition();
        }

        private void setStartPosition()
        {
            int center = (SIZE - 1) / 2;
            StartPosition = new Point(center, center);
            AddCard(new Card(null, StartPosition));
        }

        private void setTargetPosition()
        {
            int x = RandomUtil.GetInt(TARGET_AREA_SIZE - 1);
            int y = RandomUtil.GetInt(TARGET_AREA_SIZE - 1);

            bool isUpper = RandomUtil.GetBool();
            bool isLeft = RandomUtil.GetBool();

            int verticalAreaStart = isUpper ? 0 : SIZE - TARGET_AREA_SIZE;
            int horizontalAreaStart = isLeft ? 0 : SIZE - TARGET_AREA_SIZE;

            TargetPosition = new Point(verticalAreaStart + x, horizontalAreaStart + y);
        }

        public void AddCard(Card card)
        {
            Cards[card.Position.X, card.Position.Y] = card;
        }

        public List<Path> GetClosestPathsToTarget()
        {
            return getClosestPathsBetween(StartPosition, TargetPosition);
        }

        public List<Path> GetImcompleteClosestPathsToTarget()
        {
            List<Card> closestCards = getClosestCardsToTarget();
            List<Path> closestIncompletePaths = new List<Path>(); 

            foreach (Card card in closestCards)
            {
                closestIncompletePaths.AddRange(getClosestPathsBetween(StartPosition, card.Position));
            }

            return closestIncompletePaths;
        }

        private List<Card> getClosestCardsToTarget()
        {
            int minDistance = int.MaxValue;
            List<Card> closestCards = new List<Card>();

            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    Card card = Cards[i, j];
                    if (card != null)
                    {
                        int distance = getDistanceBetween(card.Position, TargetPosition);
                        if (distance < minDistance)
                        {   
                            minDistance = distance;
                            closestCards = new List<Card>() { card };
                        }
                        else if (distance == minDistance)
                        {
                            closestCards.Add(card);
                        }
                    }
                }
            }

            return closestCards;
        }

        private int getDistanceBetween(Point p1, Point p2)
        {
            return Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);
        }

        private List<Path> getClosestPathsBetween(Point p1, Point p2)
        {
            int[,] distances = new int[SIZE, SIZE];
            HashSet<Point>[,] neighbours = new HashSet<Point>[SIZE, SIZE];
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    distances[i, j] = int.MaxValue;
                    neighbours[i, j] = new HashSet<Point>();
                }
            }

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(new Node(StartPosition, 0));
            distances[StartPosition.X, StartPosition.Y] = 0;

            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();
                Point currentPosition = currentNode.Position;

                if (currentNode.Distance > distances[currentPosition.X, currentPosition.Y])
                {
                    continue;
                }

                List<Point> currentNeighbours = currentNode.GetNeighbourPoints().FindAll(p => Cards[p.X, p.Y] != null);

                int newItemDistance = distances[currentNode.Position.X, currentNode.Position.Y] + 1;

                foreach (Point neighbour in currentNeighbours)
                {
                    if (distances[neighbour.X, neighbour.Y] > newItemDistance)
                    {
                        distances[neighbour.X, neighbour.Y] = newItemDistance;

                        Node newNode = new Node(neighbour, newItemDistance);
                        neighbours[neighbour.X, neighbour.Y] = new HashSet<Point>() { currentPosition };

                        queue.Enqueue(newNode);
                    }
                    else if (distances[neighbour.X, neighbour.Y] == newItemDistance)
                    {
                        neighbours[neighbour.X, neighbour.Y].Add(currentPosition);
                    }
                }
            }


            // only finds one path
            Point currentPoint = TargetPosition;
            List<Point> pathPoints = new List<Point>();
            pathPoints.Add(currentPoint);

            while (neighbours[currentPoint.X, currentPoint.Y].Any())
            {
                currentPoint = neighbours[currentPoint.X, currentPoint.Y].First();
                pathPoints.Add(currentPoint);
            }

            return new List<Path>() { new Path(pathPoints, this) };

            // todo find all paths
            //Stack<Point> stack = new Stack<Point>();
            //stack.Push(TargetPosition);

            //while (stack.Count != 0)
            //{
            //    Point currentPoint = stack.Pop();
//
  //              foreach (Point neighbour in neighbours[currentPoint.X, currentPoint.Y])
    //            {
      //              stack.Push(neighbour);
        //        }
          //  }

            //return null;
        }
    }
}

