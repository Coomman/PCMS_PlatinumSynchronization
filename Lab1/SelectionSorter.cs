using System.IO;
using CodeChallenge.Core;

namespace Lab1
{
    public class SelectionSorter : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());
            var arr = new int[length];

            var query = sr.ReadLine().Split();
            for (int i = 0; i < length; i++)
                arr[i] = int.Parse(query[i]);

            arr.SelectionSort(0, length - 1);

            sw.WriteLine(string.Join(" ", arr));
        }
    }
}
