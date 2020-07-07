using Lab2;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab2
{
    internal class TaskE : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            var arr = new int[5];
            arr[0] = 1;
            arr[1] = 2;

            KthStat.FillArray(arr, 2, 3, 5);

            KthStat.FindKthSmallestElement(arr, 2).Should().Be(13);
        }

        [Test]
        public void ExampleTest2()
        {
            var arr = new int[5];
            arr[0] = 1;
            arr[1] = 2;

            KthStat.FillArray(arr, 200000, 300000, 5);

            KthStat.FindKthSmallestElement(arr, 2).Should().Be(2);
        }
    }
}
