using System.IO;
using CodeChallenge.Core;

namespace Lab4
{
    public class StackChecker : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());

            var stack = new Stack<int>(length);

            while (!sr.EndOfStream)
            {
                var query = sr.ReadLine().Split();

                if (query[0][0] == '+')
                    stack.Push(int.Parse(query[1]));
                else
                    sw.WriteLine(stack.Pop());
            }
        }
    }
}
