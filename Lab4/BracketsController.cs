using System.IO;
using CodeChallenge.Core;

namespace Lab4
{
    public class BracketsController : IFileTask
    {
        public static bool CheckBracketSequence(string bracketSeq)
        {
            var stack = new Stack<char>(bracketSeq.Length);

            foreach (char ch in bracketSeq)
            {
                if (ch == '(' || ch == '[')
                    stack.Push(ch);
                else
                {
                    if (stack.IsEmpty)
                        return false;

                    var lastBracket = stack.Pop();

                    if (ch == ')' && lastBracket != '(' || ch == ']' && lastBracket != '[')
                        return false;
                }
            }

            return stack.IsEmpty;
        }

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            while (!sr.EndOfStream)
            {
                var bracketSequence = sr.ReadLine();

                var result = CheckBracketSequence(bracketSequence);

                sw.WriteLine(result ? "YES" : "NO");
            }
        }
    }
}
