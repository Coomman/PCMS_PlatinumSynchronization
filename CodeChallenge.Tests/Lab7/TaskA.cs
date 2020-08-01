using Lab7;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab7
{
    internal class TaskA : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            BalanceCalculator.Node[] tree =
            {
                new BalanceCalculator.Node(-2, -1, 1),
                new BalanceCalculator.Node(8, 3, 2),
                new BalanceCalculator.Node(9, -1, -1),
                new BalanceCalculator.Node(3, 4, 5),
                new BalanceCalculator.Node(0, -1, -1),
                new BalanceCalculator.Node(6, -1, -1)
            };

            BalanceCalculator.DfsAsync(tree, tree[0]).Wait();

            tree[0].Balance.Should().Be(3);
            tree[1].Balance.Should().Be(-1);
            tree[2].Balance.Should().Be(0);
            tree[3].Balance.Should().Be(0);
            tree[4].Balance.Should().Be(0);
            tree[5].Balance.Should().Be(0);
        }
    }
}
