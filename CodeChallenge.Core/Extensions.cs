using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CodeChallenge.Core
{
    public static class Extensions
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

        public static void SelectionSort<T>(this IList<T> arr, int left, int right) where T : IComparable
        {
            for (int i = left; i < right; i++)
            {
                var min = i;

                for (int j = i + 1; j <= right; j++)
                    if (arr.Compare(j, min) < 0)
                        min = j;

                if(min != i)
                    arr.Swap(min, i);
            }
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

        private static (int leftBound, int rightBound) Partition<T>(this IList<T> arr, int left, int right) where T : IComparable
        {
            int l = left;
            int r = right;
            var pivot = arr[left];
            int cur = left + 1;

            while (cur <= r)
            {
                int cmp = arr[cur].CompareTo(pivot);

                if (cmp < 0)
                    arr.Swap(l++, cur++);
                else if (cmp > 0)
                    arr.Swap(cur, r--);
                else
                    cur++;
            }

            return (l, r);
        }
        public static void ParallelQuickSort<T>(this IList<T> arr, int left, int right) where T : IComparable
        {
            if (right <= left)
                return;

            if (right - left + 1 <= 80)
            {
                arr.InsertionSort(left, right);
                return;
            }

            var (leftBound, rightBound) = arr.Partition(left, right);

            var leftPart = Task.Run(() => arr.ParallelQuickSort(left, leftBound - 1));
            var rightPart = Task.Run(() => arr.ParallelQuickSort(rightBound + 1, right));

            Task.WaitAll(leftPart, rightPart);
        }
    }
}
