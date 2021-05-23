using CodeChallenge.Core;

namespace Lab7
{
    public class Deletion : FileTask
    {
        private readonly AVL _avl = new AVL();

        public override void Execute()
        {
            var length = ReadInt();

            if (length == 1)
            {
                WriteLine(0);
                return;
            }

            var tree = new AvlNode[length];
            for (int i = 0; i < length; i++)
            {
                var numbers = ReadIntArray();
                tree[i] = new AvlNode(numbers[0])
                    { Lch = numbers[1] - 1, Rch = numbers[2] - 1 };
            }

            _avl.BuildTree(tree);
            _avl.Delete(ReadInt());
            var result = _avl.Reorder();

            WriteLine(result.Count);
            foreach (var node in result)
                WriteLine($"{node.Value} {node.Lch} {node.Rch}");
        }
    }
}
