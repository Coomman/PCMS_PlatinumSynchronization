using System.IO;
using CodeChallenge.Core;

namespace Lab1
{
    public class AplusBB : IFileTask
    {
        public long Compute(long a, long b)
            => a + b * b;

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var query = sr.ReadLine().Split();

            sw.WriteLine(Compute(int.Parse(query[0]), int.Parse(query[1])));
        }
    }
}
