using System;
using System.Collections.Generic;
using CodeChallenge.Core;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    public class RadixSorter : IConsoleTask
    {
        private static int CharToInt(char c)
            => c - 97;
        private static void CountingSort(IList<string> arr, int charNum)
        {
            var sorted = new List<string>[26];
            for (int i = 0; i < sorted.Length; i++)
                sorted[i] = new List<string>();

            foreach (var str in arr)
                sorted[CharToInt(str[charNum])].Add(str);

            int pointer = 0;
            foreach (var charArray in sorted)
                foreach (var str in charArray)
                    arr[pointer++] = str;
        }

        public void RadixSort(IList<string> arr, int iterationCount, int strLen)
        {
            for (int i = 0; i < iterationCount; i++)
                CountingSort(arr, strLen - i - 1);
        }

        public void ExecuteConsole()
        {
            var query = Console.ReadLine().Split();

            int length = int.Parse(query[0]);
            int strLen = int.Parse(query[1]);
            int iterationCount = int.Parse(query[2]);

            var arr = new List<string>(length);
            for (int i = 0; i < length; i++)
                arr.Add(Console.ReadLine());

            RadixSort(arr, iterationCount, strLen);

            Console.WriteLine(string.Join("\n", arr));
        }
    }
}

namespace Lab3
{
    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteConsole(new BinarySearcher());
            //TaskRunner.ExecuteConsole(new Garland());
            //TaskRunner.ExecuteFile(new HeapChecker(), "isheap");
            //TaskRunner.ExecuteFile(new HeapSorter(), "sort");
            TaskRunner.ExecuteConsole(new RadixSorter());
        }
    }
}

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

namespace CodeChallenge.Core
{
    public interface IConsoleTask
    {
        void ExecuteConsole();
    }
}

namespace CodeChallenge.Core
{
    public interface IFileTask
    {
        void ExecuteFile(StreamReader sr, StreamWriter sw);
    }
}

namespace CodeChallenge.Core
{
    public static class TaskRunner
    {
        public static void ExecuteFile(IFileTask task, string fileName)
        {
            using (var sr = new StreamReader($"{fileName}.in"))
            {
                using (var sw = new StreamWriter($"{fileName}.out"))
                    task.ExecuteFile(sr, sw);
            }
        }

        public static void ExecuteConsole(IConsoleTask task)
        {
            task.ExecuteConsole();
        }
    }
}

