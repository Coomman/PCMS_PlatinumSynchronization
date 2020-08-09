using System.IO;
using System.Linq;
using CodeChallenge.Core;

namespace Lab1
{
    public class SelectionSorter : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());

            var arr = sr.ReadLine().TrimEnd().Split().Select(int.Parse).ToArray();

            arr.SelectionSort(0, length - 1);

            sw.WriteLine(string.Join(" ", arr));
        }
    }
}
