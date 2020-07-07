using Lab3;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab3
{
    internal class TaskC : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            int[] arr = {1, 0, 1, 2, 0};
            HeapChecker.IsHeap(arr).Should().BeFalse();

            arr = new[] {1, 3, 2, 5, 4};
            HeapChecker.IsHeap(arr).Should().BeTrue();
        }
    }
}
