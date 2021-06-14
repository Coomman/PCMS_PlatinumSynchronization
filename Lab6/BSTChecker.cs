using System;
using CodeChallenge.Core;

namespace Lab6
{
    public class BST<T> where T : IComparable
    {
        public class Node
        {
            public T Value { get; set; }

            public Node Parent { get; set; }
            public Node Lch { get; private set; }
            public Node Rch { get; private set; }

            public bool HasLch => Lch != null;
            public bool HasRch => Rch != null;
            public bool HasChild => Lch != null || Rch != null;
            public bool HasBothChildren => Lch != null && Rch != null;

            public Node(T value, Node parent = null)
            {
                Value = value;
                Parent = parent;
            }

            public void ChangeChild(Node child, Node newChild)
            {
                if (Lch != null && Lch == child)
                    Lch = newChild;
                else
                    Rch = newChild;

                if (newChild != null)
                    newChild.Parent = this;
            }
            public void SetChild(T value)
            {
                var ch = new Node(value, this);

                if (value.CompareTo(Value) < 0)
                    Lch = ch;
                else
                    Rch = ch;
            }
            public Node GetChild(bool predicate)
                => predicate ? Lch : Rch;

            public override string ToString()
            {
                return $"Value: {Value}";
            }
        }

        private Node _root;

        private static Node PrevNode(Node start)
        {
            var cur = start.Lch;

            while (cur.HasRch)
                cur = cur.Rch;

            return cur;
        }

        public bool Empty
            => _root is null;

        public Node Find(T value)
        {
            var cur = _root;

            while (cur != null)
            {
                if (cur.Value.Equals(value))
                    return cur;

                cur = cur.GetChild(value.CompareTo(cur.Value) < 0);
            }

            return null;
        }
        public void Insert(T value)
        {
            if (Empty)
            {
                _root = new Node(value);
                return;
            }

            var cur = _root;
            while (cur != null)
            {
                if (cur.Value.Equals(value))
                    return;

                var childNode = cur.GetChild(value.CompareTo(cur.Value) < 0);

                if (childNode is null)
                {
                    cur.SetChild(value);
                    return;
                }

                cur = childNode;
            }
        }
        public void Delete(T value, Node start = null)
        {
            var cur = start ?? Find(value);

            if (cur == null)
                return;

            if (cur.HasBothChildren)
            {
                var prevNode = PrevNode(cur);

                Delete(prevNode.Value, prevNode);
                cur.Value = prevNode.Value;

                return;
            }

            if (cur.HasChild)
            {
                var childNode = cur.GetChild(cur.HasLch);

                if (cur == _root)
                {
                    childNode.Parent = null;
                    _root = childNode;
                }
                else
                    cur.Parent.ChangeChild(cur, childNode);

                return;
            }

            if (cur == _root)
                _root = null;
            else
                cur.Parent.ChangeChild(cur, null);
        }

        public Node GetPrev(T value)
        {
            Node prev = null;

            var cur = _root;
            while (cur != null)
            {
                if (cur.Value.CompareTo(value) >= 0)
                {
                    cur = cur.Lch;
                    continue;
                }

                prev = cur;
                cur = cur.Rch;
            }

            return prev;
        }
        public Node GetNext(T value)
        {
            Node next = null;

            var cur = _root;
            while (cur != null)
            {
                if (cur.Value.CompareTo(value) <= 0)
                {
                    cur = cur.Rch;
                    continue;
                }

                next = cur;
                cur = cur.Lch;
            }

            return next;
        }
    }

    public class BSTChecker : FileTask
    {
        public override void Execute()
        {
            var tree = new BST<int>();

            while (!EndOfStream())
            {
                var query = ReadLine().Split();

                switch (query[0][0])
                {
                    case 'i':
                        tree.Insert(int.Parse(query[1]));
                        break;
                    case 'e':
                        WriteLine(tree.Find(int.Parse(query[1])) is null ? "false" : "true");
                        break;
                    case 'd':
                        tree.Delete(int.Parse(query[1]));
                        break;
                    case 'p':
                        var node = tree.GetPrev(int.Parse(query[1]));
                        WriteLine(node is null ? "none" : node.Value.ToString());
                        break;
                    default:
                        node = tree.GetNext(int.Parse(query[1]));
                        WriteLine(node is null ? "none" : node.Value.ToString());
                        break;
                }
            }
        }
    }
}