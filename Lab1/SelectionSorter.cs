using CodeChallenge.Core;

namespace Lab1
{
    public class SelectionSorter : FileTask
    {
        public void ExecuteFile()
        {
            var length = ReadInt();

            var arr = ReadIntArray();

            arr.SelectionSort(0, length - 1);

            WriteLine(string.Join(" ", arr));
        }
    }
}
