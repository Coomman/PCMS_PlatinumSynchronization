using CodeChallenge.Core;

namespace Lab1
{
    public class AplusB : FileTask
    {
        public int Add(int first, int second)
            => first + second;

        public override void Execute()
        {
            var numbers = ReadIntArray();

            WriteLine(Add(numbers[0], numbers[1]));
        }
    }
}
