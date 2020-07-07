using Lab3;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab3
{
    internal class TaskA : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            int[] arr = {1, 1, 2, 2, 2};
            int[] queries = {1, 2, 3};

            BinarySearcher.FindEntry(arr, queries[0], true).Should().Be(1);
            BinarySearcher.FindEntry(arr, queries[0], false).Should().Be(2);
            BinarySearcher.FindEntry(arr, queries[1], true).Should().Be(3);
            BinarySearcher.FindEntry(arr, queries[1], false).Should().Be(5);
            BinarySearcher.FindEntry(arr, queries[2], true).Should().Be(-1);
            BinarySearcher.FindEntry(arr, queries[2], false).Should().Be(-1);
        }
    }
}
