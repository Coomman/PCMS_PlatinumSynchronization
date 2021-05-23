using System.Linq;
using CodeChallenge.Core;

namespace Lab1
{
    public class Sortland : FileTask
    {
        public override void Execute()
        {
            var length = ReadInt();

            var arr = ReadFloatArray()
                .Select((wealth, index) => (wealth, num: index + 1))
                .ToArray();

            arr.SelectionSort(0, length - 1);

            Write($"{arr[0].num} ");
            Write($"{arr[length / 2].num} ");
            Write(arr[length - 1].num);
        }
    }
}
