using System;
using System.Collections.Generic;

namespace Lab3
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

        public static int ValueCompare<T>(this IList<T> arr, int first, T second) where T : IComparable
        {
            return arr[first].CompareTo(second);
        }
    }
}
