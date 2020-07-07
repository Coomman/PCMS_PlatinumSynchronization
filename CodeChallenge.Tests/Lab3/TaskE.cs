using Lab3;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab3
{
    internal class TaskE : ITestClass
    {
        private string[] _arr;

        [SetUp]
        public void SetUp()
        {
            _arr = new[] { "bbb", "aba", "baa"};
        }

        [Test]
        public void ExampleTest()
        {
            RadixSorter.RadixSort(_arr, 1, 3);

            _arr[0].Should().Be("aba");
            _arr[1].Should().Be("baa");
            _arr[2].Should().Be("bbb");
        }

        [Test]
        public void ExampleTest2()
        {
            RadixSorter.RadixSort(_arr, 2, 3);

            _arr[0].Should().Be("baa");
            _arr[1].Should().Be("aba");
            _arr[2].Should().Be("bbb");
        }

        [Test]
        public void ExampleTest3()
        {
            RadixSorter.RadixSort(_arr, 3, 3);

            _arr[0].Should().Be("aba");
            _arr[1].Should().Be("baa");
            _arr[2].Should().Be("bbb");
        }
    }
}
