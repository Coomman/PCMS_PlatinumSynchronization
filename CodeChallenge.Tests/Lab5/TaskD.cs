using Lab5;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab5
{
    internal class TaskD : ITestClass
    {
        private MultiMap<string, string> _multiMap;

        [SetUp]
        public void SetUp()
        {
            _multiMap = new MultiMap<string, string>();
        }

        [Test]
        public void ExampleTest()
        {
            _multiMap.Add("a", "a");
            _multiMap.Add("a", "b");
            _multiMap.Add("a", "c");

            var set = _multiMap.Get("a");
            set.Size.Should().Be(3);
            set.Get("a").Should().NotBeNull();
            set.Get("b").Should().NotBeNull();
            set.Get("c").Should().NotBeNull();

            _multiMap.Delete("a", "b");

            set = _multiMap.Get("a");
            set.Size.Should().Be(2);
            set.Get("a").Should().NotBeNull();
            set.Get("b").Should().BeNull();
            set.Get("c").Should().NotBeNull();

            _multiMap.DeleteAll("a");

            _multiMap.Get("a").Should().BeNull();
        }
    }
}
