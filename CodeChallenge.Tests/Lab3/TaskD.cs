using Lab3;
using NUnit.Framework;

namespace CodeChallenge.Tests.Lab3
{
    internal class TaskD : ITestClass
    {
        private readonly Heap<int> _heap = new Heap<int>(HeapType.Min);

        [Test]
        public void ExampleTest()
        {
            int[] arr = {1, 8, 2, 1, 4, 7, 3, 2, 3, 6};

            _heap.Sort(arr);

            arr.CheckSort();
        }
    }
}
