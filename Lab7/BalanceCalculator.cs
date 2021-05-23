using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using CodeChallenge.Core;

namespace Lab7
{
    public class BalanceCalculator : FileTask
    {
        public class Node
        {
            public int Value { get; }
            public int Balance { get; set; }

            public int Lch { get; }
            public int Rch { get; }

            public bool HasLch => Lch != -1;
            public bool HasRch => Rch != -1;

            public Node(int value, int lch, int rch)
            {
                Value = value;
                Lch = lch;
                Rch = rch;
            }

            public override string ToString()
            {
                return $"Balance: {Balance}";
            }
        }

        public static async Task<int> DfsAsync(IList<Node> tree, Node cur)
        {
            if (!cur.HasLch && !cur.HasRch)
            {
                cur.Balance = 0;
                return 1;
            }

            int leftHeight = 0;
            int rightHeight = 0;

            var childChecks = new Task<int>[2];

            if (cur.HasLch)
                childChecks[0] = Task.Run(() => DfsAsync(tree, tree[cur.Lch]));
            if (cur.HasRch)
                childChecks[1] = Task.Run(() => DfsAsync(tree, tree[cur.Rch]));

            if (cur.HasLch)
                leftHeight = await childChecks[0];
            if (cur.HasRch)
                rightHeight = await childChecks[1];

            cur.Balance = rightHeight - leftHeight;

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public override void Execute()
        {
            var length = ReadInt();

            if (length < 2)
            {
                Write(0);
                return;
            }

            var tree = new Node[length];
            for (int i = 0; i < length; i++)
            {
                var numbers = ReadIntArray();
                tree[i] = new Node(numbers[0], numbers[1] - 1, numbers[2] - 1);
            }

            DfsAsync(tree, tree[0]).Wait();

            foreach (var node in tree)
                WriteLine(node.Balance);
        }
    }
}
