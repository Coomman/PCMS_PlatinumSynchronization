using System;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab3
{
    public class RadixSorter : ConsoleTask
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

        public static void RadixSort(IList<string> arr, int iterationCount, int strLen)
        {
            for (int i = 0; i < iterationCount; i++)
                CountingSort(arr, strLen - i - 1);
        }

        public override void Execute()
        {
            var numbers = ReadIntArray();

            int length = numbers[0];
            int strLen = numbers[1];
            int iterationCount = numbers[2];

            var arr = new List<string>(length);
            for (int i = 0; i < length; i++)
                arr.Add(Console.ReadLine());

            RadixSort(arr, iterationCount, strLen);

            WriteLine(string.Join("\n", arr));
        }
    }
}
