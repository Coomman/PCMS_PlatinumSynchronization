using System;
using System.Collections.Generic;

namespace Lab1
{
    internal static class Extensions
    {
        public static void Swap<T>(this IList<T> arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        public static int Compare<T>(this IList<T> arr, int first, int second) where T : IComparable
        {
            return arr[first].CompareTo(arr[second]);
        }

        public static void SelectionSort<T>(this IList<T> arr, int left, int right) where T : IComparable
        {
            for (int i = left; i < right; i++)
            {
                var min = i;

                for (int j = i + 1; j <= right; j++)
                    if (arr.Compare(j, min) < 0)
                        min = j;

                if (min != i)
                    arr.Swap(min, i);
            }
        }
    }
}
