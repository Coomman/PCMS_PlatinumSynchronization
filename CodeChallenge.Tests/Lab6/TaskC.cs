using Lab6;
using System;
using System.Linq;
using CodeChallenge.Core;
using NUnit.Framework;
using FluentAssertions;

namespace CodeChallenge.Tests.Lab6
{
    internal class TaskC : ITestClass
    {
        private readonly Random _rand = new Random();
        private BST<int> _tree;

        [SetUp]
        public void SetUp()
        {
            _tree = new BST<int>();
        }

        [Test]
        public void ExampleTest()
        {
            _tree.Insert(2);
            _tree.Insert(5);
            _tree.Insert(3);

            _tree.Find(2).Should().NotBeNull();
            _tree.Find(4).Should().BeNull();
            _tree.GetNext(4).Value.Should().Be(5);
            _tree.GetPrev(4).Value.Should().Be(3);

            _tree.Delete(5);

            _tree.GetNext(4).Should().BeNull();
            _tree.GetPrev(4).Value.Should().Be(3);
        }

        #region Find

        [Test]
        public void Find_InEmptyTree_ReturnsNull()
        {
            _tree.ShouldNotContain(0);
        }

        [Test]
        public void Find_InTreeContainsThisValue_ReturnsRightNode()
        {
            _tree.Insert(1);

            _tree.ShouldContain(1);
        }

        [Test]
        public void Find_InTreeDoesNotContainThisValue_ReturnsNull()
        {
            _tree.Insert(2);

            _tree.ShouldNotContain(5);
        }

        [Test]
        public void Find_InTreeWithManyElementsContainsThisValue_ReturnsRightNode()
        {
            _tree.Insert(1);
            _tree.Insert(2);
            _tree.Insert(3);
            _tree.Insert(4);
            _tree.Insert(5);

            _tree.ShouldContain(4);
        }

        #endregion

        #region Delete

        [Test]
        public void Delete_ElementWithoutChilds_WorksCorrect()
        {
            _tree.Insert(2);
            _tree.Insert(1);
            _tree.Insert(3);
            _tree.Delete(1);

            _tree.ShouldContain(2, 3);
            _tree.ShouldNotContain(1);
        }

        [Test]
        public void Delete_ElementWithOnlyLeftChild_WorksCorrect()
        {
            _tree.Insert(3);
            _tree.Insert(2);
            _tree.Insert(1);
            _tree.Delete(2);

            _tree.ShouldContain(1, 3);
            _tree.ShouldNotContain(2);
        }

        [Test]
        public void Delete_ElementWithOnlyRightChild_WorksCorrect()
        {
            _tree.Insert(4);
            _tree.Insert(1);
            _tree.Insert(2);
            _tree.Delete(1);

            _tree.ShouldContain(4, 2);
            _tree.ShouldNotContain(1);
        }

        [Test]
        public void Delete_ElementWithBothChilds_WorksCorrect()
        {
            _tree.Insert(2);
            _tree.Insert(1);
            _tree.Insert(4);
            _tree.Insert(3);
            _tree.Insert(5);
            _tree.Delete(4);

            _tree.ShouldContain(1, 2, 3, 5);
            _tree.ShouldNotContain(4);
        }

        [Test]
        public void Delete_RootInTreeWithOneElement_MakesTreeEmpty()
        {
            _tree.Insert(1);
            _tree.Delete(1);

            _tree.Empty.Should().BeTrue();
        }

        [Test]
        public void Delete_RootWithLeftChild_WorksCorrect()
        {
            _tree.Insert(3);
            _tree.Insert(2);
            _tree.Insert(1);
            _tree.Delete(3);

            _tree.ShouldContain(1, 2);
            _tree.ShouldNotContain(3);
        }

        [Test]
        public void Delete_RootWithOnlyRightChild_WorksCorrect()
        {
            _tree.Insert(1);
            _tree.Insert(2);
            _tree.Insert(3);
            _tree.Delete(1);

            _tree.ShouldContain(2, 3);
            _tree.ShouldNotContain(1);
        }

        [Test]
        public void Delete_RootWithBothChilds_WorksCorrect()
        {
            _tree.Insert(2);
            _tree.Insert(1);
            _tree.Insert(4);
            _tree.Insert(3);
            _tree.Insert(5);
            _tree.Delete(2);

            _tree.ShouldContain(1, 5, 3, 4);
            _tree.ShouldNotContain(2);
        }

        #endregion

        #region GetPrevNext

        [Test]
        public void LongGetPrevTest()
        {
            var numbers = Enumerable.Range(-10000, 20001).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = _rand.Next(0, numbers.Length - i - 1);
                _tree.Insert(numbers[swapNum]);
                numbers.Swap(swapNum, numbers.Length - i - 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = _rand.Next(0, numbers.Length - i - 1);
                _tree.Delete(numbers[swapNum]);

                int cur = numbers[swapNum];
                numbers.Swap(swapNum, numbers.Length - i - 1);

                int? prev = null;
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] < cur && (prev is null || prev < numbers[j]))
                        prev = numbers[j];
                }

                if (prev is null)
                    _tree.GetPrev(cur).Should().BeNull();
                else
                    _tree.GetPrev(cur).Value.Should().Be(prev);
            }
        }

        [Test]
        public void LongGetNextTest()
        {
            var numbers = Enumerable.Range(-10000, 20001).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = _rand.Next(0, numbers.Length - i - 1);
                _tree.Insert(numbers[swapNum]);
                numbers.Swap(swapNum, numbers.Length - i - 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = _rand.Next(0, numbers.Length - i - 1);
                _tree.Delete(numbers[swapNum]);

                int cur = numbers[swapNum];
                numbers.Swap(swapNum, numbers.Length - i - 1);

                int? next = null;
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > cur && (next is null || next > numbers[j]))
                        next = numbers[j];
                }

                if (next is null)
                    _tree.GetNext(cur).Should().BeNull();
                else
                    _tree.GetNext(cur).Value.Should().Be(next);
            }
        }

        #endregion


        [Test]
        [Ignore("Too long")]
        public void LongInsertDeleteTest()
        {
            var numbers = Enumerable.Range(-10000, 20001).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = _rand.Next(0, numbers.Length - i - 1);
                _tree.Insert(numbers[swapNum]);
                numbers.Swap(swapNum, numbers.Length - i - 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = _rand.Next(0, numbers.Length - i - 1);
                _tree.Delete(numbers[swapNum]);
                numbers.Swap(swapNum, numbers.Length - i - 1);

                for (int j = 0; j < numbers.Length - i - 1; j++)
                    _tree.ShouldContain(numbers[j]);
            }
        }
    }
}
