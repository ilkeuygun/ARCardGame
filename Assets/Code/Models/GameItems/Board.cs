using System;
using Com.Yosi.Linkar.Code.Util;

namespace Com.Yosi.Linkar.Code.Models.GameItems
{
    public class Board
    {
        public const int SIZE = 15;
        private const int TARGET_AREA_SIZE = 4;

        public Tile[,] Tiles { get; private set; }

        public Point StartPosition { get; private set; }
        public Point TargetPosition { get; private set; }

        public Board()
        {
            Tiles = new Tile[SIZE, SIZE];

            setStartPosition();
            setTargetPosition();
        }

        private void setStartPosition()
        {
            int center = (SIZE - 1) / 2;
            StartPosition = new Point(center, center);
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
    }
}

