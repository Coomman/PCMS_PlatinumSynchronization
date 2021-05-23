using System;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab2
{
    public class KthStat : ConsoleTask
    {
        private static void SetPivot<T>(IList<T> arr, int l, int r) where T : IComparable
        {
            int mid = l + (r - l) / 2;

            arr.Swap(mid, l + 1);

            if (arr.Compare(l, r) > 0)
                arr.Swap(l, r);

            if (arr.Compare(l + 1, r) > 0)
                arr.Swap(l + 1, r);

            if (arr.Compare(l, l + 1) > 0)
                arr.Swap(l, l + 1);
        }
        private static (int leftBound, int rightBound) Partition<T>(IList<T> arr, int l, int r) where T : IComparable
        {
            int i = l + 1;
            int j = r;

            var pivot = arr[i];

            while (true)
            {
                while (arr[++i].CompareTo(pivot) < 0) { }

                while (arr[--j].CompareTo(pivot) > 0) { }

                if (i > j)
                    break;

                arr.Swap(i, j);
            }

            arr[l + 1] = arr[j];
            arr[j] = pivot;

            return (i, j);
        }

        public static T FindKthSmallestElement<T>(IList<T> arr, int kPos) where T : IComparable
        {
            int l = 0, r = arr.Count - 1;

            while (true)
            {
                if (l + 1 >= r)
                {
                    if (l + 1 == r && arr.Compare(l, r) > 0)
                        arr.Swap(l, r);

                    return arr[kPos];
                }

                SetPivot(arr, l, r);
                var (leftBound, rightBound) = Partition(arr, l, r);

                if (rightBound >= kPos)
                    r = rightBound - 1;

                if (rightBound <= kPos)
                    l = leftBound;
            }
        }
        public static void FillArray(int[] arr, int A, int B, int C)
        {
            for (int i = 2; i < arr.Length; i++)
                arr[i] = A * arr[i - 2] + B * arr[i - 1] + C;
        }

        public override void Execute()
        {
            var numbers = ReadIntArray();

            int length = numbers[0];
            int k = numbers[1];

            numbers = ReadIntArray();

            int A = numbers[0];
            int B = numbers[1];
            int C = numbers[2];

            var arr = new int[length];
            arr[0] = numbers[3];
            arr[1] = numbers[4];

            FillArray(arr, A, B, C);

            Console.WriteLine(FindKthSmallestElement(arr, k - 1));
        }
    }
}
