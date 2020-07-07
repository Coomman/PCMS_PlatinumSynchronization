using NUnit.Framework;
using FluentAssertions;
using CodeChallenge.Core;

namespace CodeChallenge.Tests.Lab2
{
    internal class TaskA : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            var arr = new[] {1, 8, 2, 1, 4, 7, 3, 2, 3, 6};
            
            arr.MergeSort(0, arr.Length - 1);

            arr.CheckSort().Should().BeTrue();
        }
    }
}
