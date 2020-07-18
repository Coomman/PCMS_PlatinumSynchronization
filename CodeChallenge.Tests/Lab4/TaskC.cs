using Lab4;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab4
{
    internal class TaskC : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            BracketsController.CheckBracketSequence("()()").Should().BeTrue();
            BracketsController.CheckBracketSequence("([])").Should().BeTrue();

            BracketsController.CheckBracketSequence("([)]").Should().BeFalse();
            BracketsController.CheckBracketSequence("((]]").Should().BeFalse();
            BracketsController.CheckBracketSequence(")(").Should().BeFalse();
        }
    }
}
