using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lab7
{
    public class Node
    {
        public int Value;
        public int Height = 1;

        public void FixHeight() => Height = Math.Max(Lch?.Height ?? 0, Rch?.Height ?? 0) + 1;
        public int Balance => (Rch?.Height ?? 0) - (Lch?.Height ?? 0);

        public Node Parent;
        public Node Lch;
        public Node Rch;

        public bool HasLch => Lch != null;
        public bool HasRch => Rch != null;
        public bool HasChild() => Lch != null || Rch != null;
        public bool HasChild(bool side) => side ? Lch != null : Rch != null;
        public bool HasBothChildren => Lch != null && Rch != null;

        public Node(int value, Node parent = null)
        {
            Value = value;
            Parent = parent;
        }

        public ref Node GetChild(bool side)
            => ref side ? ref Lch : ref Rch;
        public void ChangeChild(Node newChild)
        {
            Parent.GetChild(Value < Parent.Value) = newChild;

            if (newChild != null)
                newChild.Parent = Parent;
        }

        public override string ToString()
        {
            return $"Value: {Value}";
        }
    }
    public class AvlNode
    {
        public int Value { get; }

        public int Lch { get; set; }
        public int Rch { get; set; }

        public bool HasLch => Lch != -1;
        public bool HasRch => Rch != -1;

        public AvlNode(int value)
        {
            Value = value;
        }
    }

    public class AVL
    {
        private Node _root;

        private static Node Rotate(Node a, bool side)
        {
            var b = a.GetChild(side);
            a.GetChild(side) = b.GetChild(!side);

            if (a.HasChild(side))
                a.GetChild(side).Parent = a;

            b.GetChild(!side) = a;
            b.Parent = a.Parent;
            a.Parent = b;

            a.FixHeight();
            b.FixHeight();

            return b;
        }
        private void Rebalance(Node cur)
        {
            while (cur != null)
            {
                cur.FixHeight();

                if (Math.Abs(cur.Balance) != 2)
                {
                    cur = cur.Parent;
                    continue;
                }

                bool side = cur.Balance == 2;

                if (side && cur.Rch.Balance < 0)
                    cur.Rch = Rotate(cur.Rch, true);
                else if (!side && cur.Lch.Balance > 0)
                    cur.Lch = Rotate(cur.Lch, false);

                cur = Rotate(cur, !side);

                if (cur.GetChild(side) == _root)
                    _root = cur;
                else
                    cur.ChangeChild(cur);
            }
        }

        private static async Task DfsAsync(Node cur)
        {
            if (!cur.HasLch && !cur.HasRch)
                return;

            var childChecks = new List<Task>();

            if (cur.HasLch)
                childChecks.Add(Task.Run(() => DfsAsync(cur.Lch)));
            if (cur.HasRch)
                childChecks.Add(Task.Run(() => DfsAsync(cur.Rch)));

            await Task.WhenAll(childChecks);

            cur.FixHeight();
        }
        private static Node PrevNode(Node start)
        {
            var cur = start.Lch;

            while (cur.HasRch)
                cur = cur.Rch;

            return cur;
        }

        public void BuildTree(AvlNode[] nodes)
        {
            var tree = new Node[nodes.Length];

            for (int i = 0; i < tree.Length; i++)
                tree[i] = new Node(nodes[i].Value);

            for (int i = 0; i < tree.Length; i++)
            {
                if (nodes[i].HasLch)
                {
                    tree[i].Lch = tree[nodes[i].Lch];
                    tree[i].Lch.Parent = tree[i];
                }

                if (nodes[i].HasRch)
                {
                    tree[i].Rch = tree[nodes[i].Rch];
                    tree[i].Rch.Parent = tree[i];
                }
            }

            _root = tree.FirstOrDefault();
            DfsAsync(_root).Wait();
        }
        public List<AvlNode> Reorder()
        {
            var avl = new List<AvlNode>();

            var nodes = new Queue<Node>();
            nodes.Enqueue(_root);

            var nextNode = 2;
            while (nodes.Any())
            {
                var node = nodes.Dequeue();

                var avlNode = new AvlNode(node.Value);
                avl.Add(avlNode);

                if (node.HasLch)
                {
                    avlNode.Lch = nextNode++;
                    nodes.Enqueue(node.Lch);
                }

                if (node.HasRch)
                {
                    avlNode.Rch = nextNode++;
                    nodes.Enqueue(node.Rch);
                }
            }

            return avl;
        }

        public Node Find(int value)
        {
            var cur = _root;

            while (cur != null)
            {
                if (cur.Value == value)
                    return cur;

                cur = cur.GetChild(value < cur.Value);
            }

            return null;
        }
        public void Insert(int value)
        {
            if (_root is null)
            {
                _root = new Node(value);
                return;
            }

            var cur = _root;
            while (cur != null)
            {
                if (cur.Value == value)
                    return;

                var childNode = cur.GetChild(value < cur.Value);
                if (childNode is null)
                {
                    cur.GetChild(value < cur.Value) = new Node(value, cur);
                    Rebalance(cur);
                    return;
                }

                cur = childNode;
            }
        }
        public void Delete(int value, Node searchStart = null)
        {
            var cur = searchStart ?? Find(value);

            if (cur == null)
                return;

            if (cur.HasBothChildren)
            {
                var prevNode = PrevNode(cur);

                Delete(prevNode.Value, prevNode);
                cur.Value = prevNode.Value;

                return;
            }

            var parent = cur.Parent;

            if (cur.HasChild())
            {
                var child = cur.GetChild(cur.HasLch);

                if (cur == _root)
                {
                    child.Parent = null;
                    _root = child;
                }
                else
                    cur.ChangeChild(child);
            }
            else
            {
                if (cur == _root)
                    _root = null;
                else
                    cur.ChangeChild(null);
            }

            if (parent != null)
                Rebalance(parent);
        }

        public void Rotation()
        {
            Rebalance(_root);
        }
        public int GetRootBalance()
            => _root?.Balance ?? 0;
    }
}
