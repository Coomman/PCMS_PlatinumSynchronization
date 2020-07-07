using System;
using System.IO;
using CodeChallenge.Core;

namespace Lab3
{
    public class HeapChecker : IFileTask
    {
        public static bool IsHeap<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < (arr.Length - 2) / 2; i++)
                if (arr.Compare(i, 2 * i + 1) > 0 ||
                    2 * i + 2 < arr.Length && arr.Compare(i, 2 * i + 2) > 0)
                    return false;

            return true;
        }

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());
            var query = sr.ReadLine().Split();

            var arr = new int[length];
            for (int i = 0; i < length; i++)
                arr[i] = int.Parse(query[i]);

            sw.Write(IsHeap(arr) ? "YES" : "NO");
        }
    }
}
