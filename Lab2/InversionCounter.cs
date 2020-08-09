using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using CodeChallenge.Core;

namespace Lab2
{
    public class InversionCounter : IFileTask
    {
        public long InversionsCount { get; private set; }

        private void Merge<T>(IList<T> arr, int p, int q, int r) where T : IComparable
        {
            int n1 = q - p + 1;
            int n2 = r - q;

            var leftPart = new T[n1];
            var rightPart = new T[n2];

            for (int i = 0; i < n1; i++)
                leftPart[i] = arr[p + i];

            for (int j = 0; j < n2; j++)
                rightPart[j] = arr[q + j + 1];

            int lit = 0, rit = 0, k = p;

            while (lit < n1 && rit < n2)
                if (leftPart[lit].CompareTo(rightPart[rit]) <= 0)
                    arr[k++] = leftPart[lit++];
                else
                {
                    arr[k++] = rightPart[rit++];
                    InversionsCount += leftPart.Length - lit;
                }

            while (lit < n1)
                arr[k++] = leftPart[lit++];

            while (rit < n2)
                arr[k++] = rightPart[rit++];
        }
        public void MergeSort<T>(IList<T> arr, int left, int right) where T : IComparable
        {
            if (left >= right)
                return;

            int mid = (left + right) / 2;

            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            Merge(arr, left, mid, right);
        }

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());

            var arr = sr.ReadLine().TrimEnd().Split().Select(int.Parse).ToArray();

            MergeSort(arr, 0, length - 1);

            sw.Write(InversionsCount);
        }
    }
}
