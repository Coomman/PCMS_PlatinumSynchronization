using Lab8;
using System.Collections.Generic;

using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab8
{
    internal class TaskF : ITestClass
    {
        private Labyrinth _lab;

        [Test]
        public void ExampleTest()
        {
            var field = new List<char[]>(5)
            {
                ".S..".ToCharArray(),
                "###.".ToCharArray(),
                "T...".ToCharArray(),
                ".##.".ToCharArray(),
                "....".ToCharArray()
            };

            _lab = new Labyrinth(field);
            _lab.Bfs();
            var route = _lab.GetBestRoute();

            route.Length.Should().Be(7);
            new string(route).Should().BeEquivalentTo("RRDDLLL");
        }
    }
}
