using System;
using System.Linq;
using CodeChallenge.Core;

namespace Lab3
{
    public class BinarySearcher : ConsoleTask
    {
        public static int FindEntry<T>(T[] arr, T searchValue, bool needFirst) where T : IComparable
        {
            if (arr.First().CompareTo(searchValue) > 0 || arr.Last().CompareTo(searchValue) < 0)
                return -1;

            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int cmp = arr.ValueCompare(mid, searchValue);

                if (cmp < 0 || !needFirst && cmp == 0)
                    l = mid + 1;
                else
                    r = mid - 1;
            }

            int entry = needFirst ? r + 1 : r;
            if (arr.ValueCompare(entry, searchValue) == 0)
                return entry + 1;

            return -1;
        }

        public override void Execute()
        {
            ReadLine();
            var arr = ReadIntArray();

            ReadLine();
            var queries = ReadIntArray();

            foreach (var query in queries)
            {
                int firstEntry = FindEntry(arr, query, true);
                int lastEntry = firstEntry == -1
                    ? -1
                    : FindEntry(arr, query, false);

                WriteLine($"{firstEntry} {lastEntry}");
            }
        }
    }
}
