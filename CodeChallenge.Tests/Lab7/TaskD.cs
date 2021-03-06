﻿using Lab7;
using NUnit.Framework;

namespace CodeChallenge.Tests.Lab7
{
    internal class TaskD : ITestClass
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
            AvlNode[] tree =
            {
                new AvlNode(4) {Lch = 1, Rch = 2},
                new AvlNode(3) {Lch = -1, Rch = -1},
                new AvlNode(5) {Lch = -1, Rch = -1}
            };

            _avl.BuildTree(tree);
            _avl.Delete(4);
            var result = _avl.Reorder();

            result.ShouldContain(new AvlNode(3){Lch = 0, Rch = 2},
                new AvlNode(5){Lch = 0, Rch = 0});
        }
    }
}
