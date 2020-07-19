using Lab6;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab6
{
    internal class TaskA : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            (int lch, int rch)[] tree = {(-1, 1), (3, 2), (-1, -1), (4, 5), (-1, -1), (-1, -1)};

            HeightCalculator.GetHeight(tree).Should().Be(4);
        }
    }
}
