using System;
using System.Linq;
using CodeChallenge.Core;
using FluentAssertions;
using NUnit.Framework;

namespace CodeChallenge.Tests
{
    public class Tests
    {
        private BST Tree { get; set; }

        [SetUp]
        public void Setup()
        {
            Tree = new BST();
        }

        #region Find

        [Test]
        public void Find_InEmptyTree_ReturnsNull()
        {
            Tree.ShouldNotContain(0);
        }

        [Test]
        public void Find_InTreeContainsThisValue_ReturnsRightNode()
        {
            Tree.Insert(1);

            Tree.ShouldContain(1);
        }

        [Test]
        public void Find_InTreeDoesNotContainThisValue_ReturnsNull()
        {
            Tree.Insert(2);

            Tree.ShouldNotContain(5);
        }

        [Test]
        public void Find_InTreeWithManyElementsContainsThisValue_ReturnsRightNode()
        {
            Tree.Insert(1);
            Tree.Insert(2);
            Tree.Insert(3);
            Tree.Insert(4);
            Tree.Insert(5);

            Tree.ShouldContain(4);
        }

        #endregion

        #region Delete

        [Test]
        public void Delete_ElementWithoutChilds_WorksCorrect()
        {
            Tree.Insert(2);
            Tree.Insert(1);
            Tree.Insert(3);
            Tree.Delete(1);

            Tree.ShouldContain(2, 3);
            Tree.ShouldNotContain(1);
        }

        [Test]
        public void Delete_ElementWithOnlyLeftChild_WorksCorrect()
        {
            Tree.Insert(3);
            Tree.Insert(2);
            Tree.Insert(1);
            Tree.Delete(2);

            Tree.ShouldContain(1, 3);
            Tree.ShouldNotContain(2);
        }

        [Test]
        public void Delete_RootInTreeWithOneElement_MakesTreeEmpty()
        {
            Tree.Insert(1);
            Tree.Delete(1);

            Tree.Empty.Should().BeTrue();
        }

        [Test]
        public void Delete_RootWithLeftChild_WorksCorrect()
        {
            Tree.Insert(3);
            Tree.Insert(2);
            Tree.Insert(1);
            Tree.Delete(3);

            Tree.ShouldContain(1, 2);
            Tree.ShouldNotContain(3);
        }

        [Test]
        public void Delete_ElementWithOnlyRightChild_WorksCorrect()
        {
            Tree.Insert(4);
            Tree.Insert(1);
            Tree.Insert(2);
            Tree.Delete(1);

            Tree.ShouldContain(4, 2);
            Tree.ShouldNotContain(1);
        }

        [Test]
        public void Delete_RootWithOnlyRightChild_WorksCorrect()
        {
            Tree.Insert(1);
            Tree.Insert(2);
            Tree.Insert(3);
            Tree.Delete(1);

            Tree.ShouldContain(2, 3);
            Tree.ShouldNotContain(1);
        }

        [Test]
        public void Delete_ElementWithBothChilds_WorksCorrect()
        {
            Tree.Insert(2);
            Tree.Insert(1);
            Tree.Insert(4);
            Tree.Insert(3);
            Tree.Insert(5);
            Tree.Delete(4);

            Tree.ShouldContain(1, 2, 3, 5);
            Tree.ShouldNotContain(4);
        }

        [Test]
        public void Delete_RootWithBothChilds_WorksCorrect()
        {
            Tree.Insert(2);
            Tree.Insert(1);
            Tree.Insert(4);
            Tree.Insert(3);
            Tree.Insert(5);
            Tree.Delete(2);

            Tree.ShouldContain(1, 5, 3, 4);
            Tree.ShouldNotContain(2);
        }

        #endregion

        #region GetPrevNext

        [Test]
        public void LongGetPrevTest()
        {
            var numbers = Enumerable.Range(-10000, 20001).ToArray();
            var rand = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = rand.Next(0, numbers.Length - i - 1);
                Tree.Insert(numbers[swapNum]);
                numbers.Swap(swapNum, numbers.Length - i - 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = rand.Next(0, numbers.Length - i - 1);
                Tree.Delete(numbers[swapNum]);

                int cur = numbers[swapNum];
                numbers.Swap(swapNum, numbers.Length - i - 1);

                int? prev = null;
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] < cur && (prev is null || prev < numbers[j]))
                        prev = numbers[j];
                }

                if (prev is null)
                    Tree.GetPrev(cur).Should().BeNull();
                else
                    Tree.GetPrev(cur).Should().Be(prev);
            }
        }

        [Test]
        public void LongGetNextTest()
        {
            var numbers = Enumerable.Range(-10000, 20001).ToArray();
            var rand = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = rand.Next(0, numbers.Length - i - 1);
                Tree.Insert(numbers[swapNum]);
                numbers.Swap(swapNum, numbers.Length - i - 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = rand.Next(0, numbers.Length - i - 1);
                Tree.Delete(numbers[swapNum]);

                int cur = numbers[swapNum];
                numbers.Swap(swapNum, numbers.Length - i - 1);

                int? next = null;
                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    if (numbers[j] > cur && (next is null || next > numbers[j]))
                        next = numbers[j];
                }

                if (next is null)
                    Tree.GetNext(cur).Should().BeNull();
                else
                    Tree.GetNext(cur).Should().Be(next);
            }
        }

        #endregion


        [Test]
        [Ignore("Too long")]
        public void LongInsertDeleteTest()
        {
            var numbers = Enumerable.Range(-10000, 20001).ToArray();
            var rand = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = rand.Next(0, numbers.Length - i - 1);
                Tree.Insert(numbers[swapNum]);
                numbers.Swap(swapNum, numbers.Length - i - 1);
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                var swapNum = rand.Next(0, numbers.Length - i - 1);
                Tree.Delete(numbers[swapNum]);
                numbers.Swap(swapNum, numbers.Length - i - 1);

                for (int j = 0; j < numbers.Length - i - 1; j++)
                {
                    Tree.ShouldContain(numbers[j]);
                }
            }
        }
    }
}