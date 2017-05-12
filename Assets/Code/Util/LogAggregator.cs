using System;
using UnityEngine;

namespace Com.Yosi.Linkar.Code.Util
{
    public static class LogAggregator
    {
        private static string _data = String.Empty;

        public static void AddItem(String item)
        {
            _data += item + "\n";
        }

        public static void Print()
        {
            Debug.Log(_data);
            _data = String.Empty;
        }
    }
}
