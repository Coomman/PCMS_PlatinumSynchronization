using CodeChallenge.Core;

namespace Lab2
{
    public class Sorter : ConsoleTask
    {
        public override void Execute()
        {
            ReadLine();

            var arr = ReadIntArray();

            arr.MergeSort(0, arr.Length - 1);

            Write(string.Join(" ", arr));
        }
    }
}
