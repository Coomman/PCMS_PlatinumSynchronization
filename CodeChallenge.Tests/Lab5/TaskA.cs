using Lab5;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab5
{
    internal class TaskA : ITestClass
    {
        private Set<int> _set;

        [SetUp]
        public void SetUp()
        {
            _set = new Set<int>();
        }

        [Test]
        public void ExampleTest()
        {
            _set.Add(2);
            _set.Add(5);
            _set.Add(3);

            _set.Contains(2).Should().BeTrue();
            _set.Contains(4).Should().BeFalse();

            _set.Add(2);
            _set.Delete(2);

            _set.Contains(2).Should().BeFalse();
        }
    }
}
