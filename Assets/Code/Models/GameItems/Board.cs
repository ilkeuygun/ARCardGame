using System;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Board
    {
        public const int DIMENSION = 15;

        public Tile[,] Tiles { get; set; }

        public Board()
        {
            Tiles = new Tile[DIMENSION, DIMENSION];
        }
    }
}

