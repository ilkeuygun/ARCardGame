using System;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Game
    {
        private static readonly Color[] DEFAULT_COLORS = new Color[] { Color.Blue, Color.Green, Color.Red, Color.Yellow };

        public Player[] Players { get; private set; }
        public Board Board { get; private set; }

        public Game()
        {
            Board = new Board();
            Players = new Player[DEFAULT_COLORS.Length];

            for (int i = 0; i < DEFAULT_COLORS.Length; i++)
            {
                Players[i] = new Player(DEFAULT_COLORS[i]);
            }
        }
    }
}

