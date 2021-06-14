using CodeChallenge.Core;

namespace Lab4
{
    public class StackChecker : FileTask
    {
        public override void Execute()
        {
            var length = ReadInt();

            var stack = new Stack<int>(length);

            while (!EndOfStream())
            {
                var query = ReadLine().Split();

                if (query[0][0] == '+')
                    stack.Push(int.Parse(query[1]));
                else
                    WriteLine(stack.Pop());
            }
        }
    }
}
