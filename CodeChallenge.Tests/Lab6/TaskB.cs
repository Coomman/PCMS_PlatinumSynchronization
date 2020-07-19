using Lab6;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab6
{
    internal class TaskB : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            TreeChecker.Node[] tree =
            {
                new TreeChecker.Node(-2, -1, 1),
                new TreeChecker.Node(8, 3, 2), 
                new TreeChecker.Node(9, -1, -1),
                new TreeChecker.Node(3, 4, 5),
                new TreeChecker.Node(0, -1, -1),
                new TreeChecker.Node(6, -1, -1) 
            };

            TreeChecker.Check(tree, tree[0]).GetAwaiter().GetResult().Should().BeTrue();
        }

        [Test]
        public void ExampleTest2()
        {
            TreeChecker.Node[] tree =
            {
                new TreeChecker.Node(5, 1, 2),
                new TreeChecker.Node(6, -1, -1),
                new TreeChecker.Node(4, -1, -1)
            };

            TreeChecker.Check(tree, tree[0]).GetAwaiter().GetResult().Should().BeFalse();
        }
    }
}
