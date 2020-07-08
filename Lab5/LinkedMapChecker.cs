using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab5
{
    public class LinkedMap
    {
        public class Node
        {
            public string Key;
            public string Value;

            public Node Prev;
            public Node Next;

            public Node(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly List<Node>[] _hashTable = new List<Node>[InitialSize];

        private const int InitialSize = 30_402_457;

        private Node _lastNode;

        private static int MakeHash(string str)
        {
            int hash = str.Select((ch, i) => (i + 1) * ch).Sum();

            return Math.Abs(hash % InitialSize);
        }

        public Node Get(string key)
        {
            return _hashTable[MakeHash(key)]?.Find(node => node.Key == key);
        }
        public void Add(string key, string value)
        {
            var node = Get(key);

            var hash = MakeHash(key);
            if (node == null)
            {
                if(_hashTable[hash] is null)
                    _hashTable[hash] = new List<Node>();

                var newNode = new Node(key, value);
                if (_lastNode != null)
                {
                    newNode.Prev = _lastNode;
                    _lastNode.Next = newNode;
                }

                _lastNode = newNode;
                _hashTable[hash].Add(newNode);

                return;
            }

            node.Value = value;
        }
        public void Delete(string key)
        {
            var node = Get(key);

            if (node == null)
                return;

            if (node.Prev != null)
                node.Prev.Next = node.Next;

            if (node.Next != null)
                node.Next.Prev = node.Prev;

            if (node == _lastNode)
                _lastNode = node.Prev;

            _hashTable[MakeHash(key)].Remove(node);
        }
        public Node Prev(string key)
            => Get(key)?.Prev;
        public Node Next(string key)
            => Get(key)?.Next;
    }

    public class LinkedMapChecker : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var linkedMap = new LinkedMap();

            while (!sr.EndOfStream)
            {
                var query = sr.ReadLine().Split();

                switch (query[0][0])
                {
                    case 'g':
                        var node = linkedMap.Get(query[1]);
                        sw.WriteLine(node?.Value ?? "none");
                        break;
                    case 'p' when query[0][1] == 'u':
                        linkedMap.Add(query[1], query[2]);
                        break;
                    case 'd':
                        linkedMap.Delete(query[1]);
                        break;
                    case 'p' when query[0][1] == 'r':
                        node = linkedMap.Prev(query[1]);
                        sw.WriteLine(node?.Value ?? "none");
                        break;
                    case 'n':
                        node = linkedMap.Next(query[1]);
                        sw.WriteLine(node?.Value ?? "none");
                        break;
                }
            }
        }
    }
}
