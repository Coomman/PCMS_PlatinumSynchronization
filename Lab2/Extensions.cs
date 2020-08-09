using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab2
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

        public static void InsertionSort<T>(this IList<T> arr, int left, int right) where T : IComparable
        {
            for (int i = left + 1; i <= right; i++)
            {
                var cur = arr[i];
                int j = i - 1;

                while (j >= left && arr[j].CompareTo(cur) > 0)
                    arr[j + 1] = arr[j--];

                arr[j + 1] = cur;
            }
        }

        private static void Merge<T>(this IList<T> arr, int left, int mid, int right) where T : IComparable
        {
            int lit = left;
            int rit = mid + 1;

            var temp = new List<T>(right - left + 1);

            while (lit <= mid && rit <= right)
                temp.Add(arr.Compare(lit, rit) <= 0
                    ? arr[lit++]
                    : arr[rit++]);

            while (lit <= mid)
                temp.Add(arr[lit++]);

            while (rit <= right)
                temp.Add(arr[rit++]);

            for (int i = 0; i < temp.Count; i++)
                arr[left + i] = temp[i];
        }
        public static void MergeSort<T>(this IList<T> arr, int left, int right) where T : IComparable
        {
            if (left >= right)
                return;

            if (right - left < 80)
            {
                arr.InsertionSort(left, right);
                return;
            }

            int mid = left + (right - left) / 2;

            var task1 = Task.Run(() => arr.MergeSort(left, mid));
            var task2 = Task.Run(() => arr.MergeSort(mid + 1, right));

            Task.WaitAll(task1, task2);

            arr.Merge(left, mid, right);
        }
    }
}
