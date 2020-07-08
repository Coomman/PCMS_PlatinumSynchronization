using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab5
{
    public class LinkedSet
    {
        public class Node
        {
            public string Value;

            public Node Prev;
            public Node Next;

            public Node(string value)
            {
                Value = value;
            }
        }

        public string Key { get; }
        public int Size { get; private set; }

        private readonly List<Node>[] _hashTable = new List<Node>[InitialSize];

        private const int InitialSize = 521;

        private Node _lastNode;

        public LinkedSet(string key)
        {
            Key = key;
        }

        private static int MakeHash(string str)
        {
            int hash = str.Select((ch, i) => (i + 1) * ch).Sum();

            return Math.Abs(hash % InitialSize);
        }

        public Node Get(string value)
        {
            return _hashTable[MakeHash(value)]?.Find(node => node.Value == value);
        }
        public void Add(string value)
        {
            var node = Get(value);

            var hash = MakeHash(value);
            if (node == null)
            {
                if(_hashTable[hash] is null)
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
        public void Delete(string value)
        {
            var node = Get(value);

            if (node == null)
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

            var cur = _lastNode;
            while (cur != null)
            {
                sw.Write($"{cur.Value} ");
                cur = cur.Prev;
            }

            sw.WriteLine();
        }
    }

    public class MultiMap
    {
        private readonly List<LinkedSet>[] _hashTable = new List<LinkedSet>[InitialSize];

        private const int InitialSize = 3_021_377;

        private static int MakeHash(string key)
        {
            int hash = key.Select((ch, i) => (i + 1) * ch).Sum();

            return Math.Abs(hash % InitialSize);
        }

        public LinkedSet Get(string key)
        {
            return _hashTable[MakeHash(key)]?.Find(map => map.Key == key);
        }
        public void Add(string key, string value)
        {
            var set = Get(key);
            if (set == null)
            {
                int hash = MakeHash(key);
                if (_hashTable[hash] == null)
                    _hashTable[hash] = new List<LinkedSet>();

                var linkedSet = new LinkedSet(key);
                linkedSet.Add(value);

                _hashTable[hash].Add(linkedSet);

                return;
            }

            if (set.Get(value) is null)
                set.Add(value);
        }
        public void Delete(string key, string value)
        {
            var set = Get(key);
            set?.Delete(value);
        }
        public void DeleteAll(string key)
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
            var multiMap = new MultiMap();

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
