using Lab7;
using NUnit.Framework;

namespace CodeChallenge.Tests.Lab7
{
    internal class TaskB : ITestClass
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
                new AvlNode(-2) {Lch = 6, Rch = 1},
                new AvlNode(8) {Lch = 3, Rch = 2},
                new AvlNode(9) {Lch = -1, Rch = -1},
                new AvlNode(3) {Lch = 4, Rch = 5},
                new AvlNode(0) {Lch = -1, Rch = -1},
                new AvlNode(6) {Lch = -1, Rch = -1},
                new AvlNode(-7) {Lch = -1, Rch = -1}
            };

            _avl.BuildTree(tree);
            _avl.Rotation();
            var result = _avl.Reorder();

            result.ShouldContain(new AvlNode(3){Lch = 2, Rch = 3},
                new AvlNode(-2){Lch = 4, Rch = 5},
                new AvlNode(8){Lch = 6, Rch = 7},
                new AvlNode(-7){Lch = 0, Rch = 0},
                new AvlNode(0){Lch = 0, Rch = 0},
                new AvlNode(6){Lch = 0, Rch = 0},
                new AvlNode(9){Lch = 0, Rch = 0});
        }
    }
}
