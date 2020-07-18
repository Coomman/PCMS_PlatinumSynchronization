using Lab5;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab5
{
    internal class TaskC : ITestClass
    {
        private LinkedMap<string, string> _linkedMap;

        [SetUp]
        public void SetUp()
        {
            _linkedMap = new LinkedMap<string, string>();
        }

        [Test]
        public void ExampleTest()
        {
            _linkedMap.Add("zero", "a");
            _linkedMap.Add("one", "b");
            _linkedMap.Add("two", "c");
            _linkedMap.Add("three", "d");
            _linkedMap.Add("four", "e");

            _linkedMap.Get("two").Value.Should().Be("c");
            _linkedMap.Prev("two").Value.Should().Be("b");
            _linkedMap.Next("two").Value.Should().Be("d");

            _linkedMap.Delete("one");
            _linkedMap.Delete("three");

            _linkedMap.Get("two").Value.Should().Be("c");
            _linkedMap.Prev("two").Value.Should().Be("a");
            _linkedMap.Next("two").Value.Should().Be("e");
            _linkedMap.Next("four").Should().BeNull();
        }
    }
}
