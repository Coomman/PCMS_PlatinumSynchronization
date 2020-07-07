using NUnit.Framework;
using FluentAssertions;
using CodeChallenge.Core;

namespace CodeChallenge.Tests.Lab1
{
    internal class TaskE : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            var arr = new (double wealth, int num)[]  {(10.00, 1), (8.70, 2), (0.01, 3), (5.00, 4), (3.00, 5)};

            arr.InsertionSort(0, arr.Length - 1);

            arr[0].num.Should().Be(3);
            arr[arr.Length / 2].num.Should().Be(4);
            arr[^1].num.Should().Be(1);
        }
    }
}
