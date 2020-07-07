using System;
using System.Linq;
using CodeChallenge.Core;

namespace Lab2
{
    public class Sorter : IConsoleTask
    {
        public void ExecuteConsole()
        {
            Console.ReadLine();

            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            arr.MergeSort(0, arr.Length - 1);

            Console.Write(string.Join(" ", arr));
        }
    }
}
