using System.IO;
using System.Linq;
using System.Globalization;
using CodeChallenge.Core;

namespace Lab1
{
    public class Sortland : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());

            var arr = sr.ReadLine().TrimEnd().Split()
                .Select((wealth, index) => (wealth: float.Parse(wealth, CultureInfo.InvariantCulture), num: index + 1))
                .ToArray();

            arr.SelectionSort(0, length - 1);

            sw.Write($"{arr[0].num} ");
            sw.Write($"{arr[length / 2].num} ");
            sw.Write(arr[length - 1].num);
        }
    }
}
