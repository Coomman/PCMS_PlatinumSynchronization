using System.IO;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab5
{
    public class MultiMap<TKey, TValue>
    {
        public class LinkedSet
        {
            public class Node
            {
                public TValue Value;

                public Node Prev;
                public Node Next;

                public Node(TValue value)
                {
                    Value = value;
                }
            }

            private readonly List<Node>[] _hashTable = new List<Node>[InitialSize];

            private const int InitialSize = 521;

            private Node _lastNode;

            public TKey Key { get; }
            public int Size { get; private set; }

            public LinkedSet(TKey key)
            {
                Key = key;
            }

            private static int MakeHash(TValue key)
                => EntryPoint.MakeHash(key, InitialSize);

            public Node Get(TValue value)
            {
                return _hashTable[MakeHash(value)]?.Find(node => node.Value.Equals(value));
            }
            public void Add(TValue value)
            {
                var node = Get(value);

                if (node is null)
                {
                    var hash = MakeHash(value);

                    if (_hashTable[hash] is null)
                        _hashTable[hash] = new List<Node>();

                    var newNode = new Node(value);
                    if (_lastNode != null)
                    {
                        newNode.Prev = _lastNode;
                        _lastNode.Next = newNode;
                    }

                    _lastNode = newNode;
                    _hashTable[hash].Add(newNode);

                    Size++;

                    return;
                }

                node.Value = value;
            }
            public void Delete(TValue value)
            {
                var node = Get(value);

                if (node is null)
                    return;

                if (node.Prev != null)
                    node.Prev.Next = node.Next;

                if (node.Next != null)
                    node.Next.Prev = node.Prev;

                if (node == _lastNode)
                    _lastNode = node.Prev;

                Size--;

                _hashTable[MakeHash(value)].Remove(node);
            }

            public void Show(StreamWriter sw)
            {
                sw.Write($"{Size} ");

                for (var cur = _lastNode; cur != null; cur = cur.Prev)
                    sw.Write($"{cur.Value} ");

                sw.WriteLine();
            }
        }

        private readonly List<LinkedSet>[] _hashTable = new List<LinkedSet>[InitialSize];

        private const int InitialSize = 3_021_377;

        private static int MakeHash(TKey key)
            => EntryPoint.MakeHash(key, InitialSize);

        public LinkedSet Get(TKey key)
        {
            return _hashTable[MakeHash(key)]?.Find(map => map.Key.Equals(key));
        }
        public void Add(TKey key, TValue value)
        {
            var set = Get(key);

            if (set is null)
            {
                int hash = MakeHash(key);

                if (_hashTable[hash] is null)
                    _hashTable[hash] = new List<LinkedSet>();

                var linkedSet = new LinkedSet(key);
                linkedSet.Add(value);

                _hashTable[hash].Add(linkedSet);

                return;
            }

            if (set.Get(value) is null)
                set.Add(value);
        }
        public void Delete(TKey key, TValue value)
        {
            Get(key)?.Delete(value);
        }
        public void DeleteAll(TKey key)
        {
            var set = Get(key);

            if (set != null)
                _hashTable[MakeHash(key)].Remove(set);
        }
    }

    public class MultiMapChecker : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var multiMap = new MultiMap<string, string>();

            while (!sr.EndOfStream)
            {
                var query = sr.ReadLine().Split();

                switch (query[0][0])
                {
                    case 'g':
                        var set = multiMap.Get(query[1]);
                        if (set == null)
                            sw.WriteLine(0);
                        else
                            set.Show(sw);
                        break;
                    case 'p':
                        multiMap.Add(query[1], query[2]);
                        break;
                    case 'd' when query.Length == 2:
                        multiMap.DeleteAll(query[1]);
                        break;
                    default:
                        multiMap.Delete(query[1], query[2]);
                        break;
                }
            }
        }
    }
}
