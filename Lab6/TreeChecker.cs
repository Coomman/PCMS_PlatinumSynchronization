using System.IO;
using System.Linq;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab6
{
    public class TreeChecker : IFileTask
    {
        public class Node
        {
            public int Value { get; }

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
        }

        private class NodeBounds
        {
            public Node Node { get; }

            public int LeftBound { get; }
            public int RightBound { get; }

            public NodeBounds(Node node, int leftBound, int rightBound)
            {
                Node = node;
                LeftBound = leftBound;
                RightBound = rightBound;
            }

            public bool CheckBounds()
            {
                return Node.Value > LeftBound && Node.Value < RightBound;
            }
        }

        public bool Check(IList<Node> tree)
        {
            var stack = new Stack<NodeBounds>();
            stack.Push(new NodeBounds(tree[0], int.MinValue, int.MaxValue));

            while (stack.Any())
            {
                var cur = stack.Pop();

                if (!cur.CheckBounds())
                    return false;

                if (cur.Node.HasLch)
                    stack.Push(new NodeBounds(tree[cur.Node.Lch], cur.LeftBound, cur.Node.Value));

                if(cur.Node.HasRch)
                    stack.Push(new NodeBounds(tree[cur.Node.Rch], cur.Node.Value, cur.RightBound));
            }

            return true;
        }

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());

            if (length < 2)
            {
                sw.Write("YES");
                return;
            }

            var tree = new Node[length];

            for (int i = 0; i < length; i++)
            {
                var query = sr.ReadLine().Split();

                tree[i] = new Node(int.Parse(query[0]),int.Parse(query[1]) - 1, int.Parse(query[2]) - 1);
            }

            sw.Write(Check(tree) ? "YES" : "NO");
        }
    }
}
