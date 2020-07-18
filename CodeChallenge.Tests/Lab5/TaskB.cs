using Lab5;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab5
{
    internal class TaskB : ITestClass
    {
        private Map<string, string> _map;

        [SetUp]
        public void SetUp()
        {
            _map = new Map<string, string>();
        }

        [Test]
        public void ExampleTest()
        {
            _map.Add("hello", "privet");
            _map.Add("bye", "poka");

            _map.Get("hello").Value.Should().Be("privet");
            _map.Get("bye").Value.Should().Be("poka");

            _map.Delete("hello");

            _map.Get("hello").Should().BeNull();
        }
    }
}
