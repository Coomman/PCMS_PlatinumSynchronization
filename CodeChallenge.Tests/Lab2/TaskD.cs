using Lab2;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab2
{
    internal class TaskD : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            var arr = new[] {1, 2, 3};

            AntiQuickSorter.AntiQuickSort(arr);

            arr[0].Should().Be(2);
            arr[1].Should().Be(3);
            arr[2].Should().Be(1);
        }
    }
}
