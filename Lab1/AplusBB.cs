using CodeChallenge.Core;

namespace Lab1
{
    public class AplusBB : FileTask
    {
        public long Compute(long a, long b)
            => a + b * b;

        public override void Execute()
        {
            var numbers = ReadIntArray();

            WriteLine(Compute(numbers[0], numbers[1]));
        }
    }
}
