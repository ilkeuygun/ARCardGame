using System;

namespace Com.Yosi.Linkar.Code.Util
{
    public static class RandomUtil
    {
        private static Random random;

        static RandomUtil()
        {
            random = new Random();
        }

        public static bool GetBool()
        {
            return random.Next(0, 1) == 1;
        }

        public static int GetInt(int max)
        {
            return GetInt(0, max);
        }

        public static int GetInt(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}

