using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using CodeChallenge.Core;

namespace Lab3
{
    public class HeapChecker : IFileTask
    {
        public static bool IsHeap<T>(IList<T> arr) where T : IComparable
        {
            for (int i = 0; i < (arr.Count - 2) / 2; i++)
                if (arr.Compare(i, 2 * i + 1) > 0 ||
                    2 * i + 2 < arr.Count && arr.Compare(i, 2 * i + 2) > 0)
                    return false;

            return true;
        }

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            sr.ReadLine();
            var arr = sr.ReadLine().TrimEnd().Split().Select(int.Parse).ToArray();

            sw.Write(IsHeap(arr) ? "YES" : "NO");
        }
    }
}
