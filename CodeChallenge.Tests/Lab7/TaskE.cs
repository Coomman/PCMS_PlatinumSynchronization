using Lab7;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab7
{
    internal class TaskE : ITestClass
    {
        private AVL _avl;

        [SetUp]
        public void SetUp()
        {
            _avl = new AVL();
        }
        
        [Test]
        public void ExampleTest()
        {
            _avl.Insert(3);
            _avl.GetRootBalance().Should().Be(0);

            _avl.Insert(4);
            _avl.GetRootBalance().Should().Be(1);

            _avl.Insert(5);
            _avl.GetRootBalance().Should().Be(0);

            _avl.Find(4).Should().NotBeNull();
            _avl.Find(6).Should().BeNull();

            _avl.Delete(5);
            _avl.GetRootBalance().Should().Be(-1);
        }
    }
}
