using System.IO;
using CodeChallenge.Core;

namespace Lab4
{
    public class BracketsController : IFileTask
    {
        public static bool CheckBracketSequence(string brackets)
        {
            var stack = new Stack<char>(brackets.Length);

            foreach (char ch in brackets)
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
