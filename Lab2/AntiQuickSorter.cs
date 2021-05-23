using System;
using System.Linq;
using CodeChallenge.Core;

namespace Lab2
{
    public class AntiQuickSorter : ConsoleTask
    {
        public static void AntiQuickSort<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                arr.Swap(i, i / 2);
        }

        public override void Execute()
        {
            int length = ReadInt();

            var arr = Enumerable.Range(1, length).ToArray();

            AntiQuickSort(arr);

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
