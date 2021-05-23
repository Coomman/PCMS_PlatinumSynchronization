using CodeChallenge.Core;

namespace Lab4
{
    public class BracketsController : FileTask
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

        public override void Execute()
        {
            while (!Sr.EndOfStream)
            {
                var bracketSequence = ReadLine();

                var result = CheckBracketSequence(bracketSequence);

                WriteLine(result ? "YES" : "NO");
            }
        }
    }
}
