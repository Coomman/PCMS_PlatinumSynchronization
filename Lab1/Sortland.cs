using System.IO;
using System.Globalization;
using CodeChallenge.Core;

namespace Lab1
{
    public class Sortland : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());
            var arr = new (float wealth, int num)[length];

            var query = sr.ReadLine().Split();
            for (int i = 0; i < length; i++)
                arr[i] = (float.Parse(query[i], CultureInfo.InvariantCulture), i + 1);

            arr.SelectionSort(0, length - 1);

            sw.Write($"{arr[0].num} ");
            sw.Write($"{arr[length / 2].num} ");
            sw.Write(arr[length - 1].num);
        }
    }
}
