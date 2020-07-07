using Lab3;
using System;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab3
{
    internal class TaskB : ITestClass
    {
        private readonly Garland _task = new Garland();

        [Test]
        public void ExampleTest()
        {
            Math.Round(_task.FindFiniteHeight(8, 15), 2)
                .Should().Be(9.75);

            Math.Round(_task.FindFiniteHeight(692, 532.81), 2)
                .Should().Be(446113.34);
        }
    }
}
