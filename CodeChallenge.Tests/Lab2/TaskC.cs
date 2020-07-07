using Lab2;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab2
{
    internal class TaskC : ITestClass
    {
        private InversionCounter _task;

        [SetUp]
        public void SetUp()
        {
            _task = new InversionCounter();
        }

        [Test]
        public void ExampleTest()
        {
            var arr = new[] { 1, 8, 2, 1, 4, 7, 3, 2, 3, 6 };

            _task.MergeSort(arr, 0, arr.Length - 1);

            _task.InversionsCount.Should().Be(17);
        }
    }
}
