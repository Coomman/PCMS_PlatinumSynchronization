using Lab2;
using NUnit.Framework;
using FluentAssertions;
using CodeChallenge.Core;

namespace CodeChallenge.Tests.Lab2
{
    internal class TaskB : ITestClass
    {
        [Test]
        public void ExampleTest()
        {
            var arr = new[]
            {
                new Race.Racer("Ivanov", "Russia"),
                new Race.Racer("Silver", "USA"),
                new Race.Racer("Petrov", "Russia")
            };

            arr.MergeSort(0, arr.Length - 1);

            arr[0].Surname.Should().Be("Ivanov");
            arr[1].Surname.Should().Be("Petrov");
            arr[2].Surname.Should().Be("Silver");
        }
    }
}
