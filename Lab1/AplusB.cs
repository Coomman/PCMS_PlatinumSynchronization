using System.IO;
using CodeChallenge.Core;

namespace Lab1
{
    public class AplusB : IFileTask
    {
        public int Add(int first, int second)
            => first + second;

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var query = sr.ReadLine().Split();

            sw.WriteLine(Add(int.Parse(query[0]), int.Parse(query[1])));
        }
    }
}
