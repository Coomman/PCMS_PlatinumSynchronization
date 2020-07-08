using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Core;

namespace Lab5
{
    public class Map
    {
        public class Node
        {
            public string Key;
            public string Value;

            public Node(string key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly List<Node>[] _hashTable = new List<Node>[InitialSize];

        private const int InitialSize = 30_402_457;

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
            if (node is null)
            {
                if(_hashTable[hash] is null)
                    _hashTable[hash] = new List<Node>();

                _hashTable[hash].Add(new Node(key, value));
                return;
            }

            node.Value = value;
        }
        public void Delete(string key)
        {
            var node = Get(key);

            if (node == null)
                return;

            _hashTable[MakeHash(key)].Remove(node);
        }
    }

    public class MapChecker : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var map = new Map();

            while (!sr.EndOfStream)
            {
                var query = sr.ReadLine().Split();

                switch (query[0][0])
                {
                    case 'g':
                        var node = map.Get(query[1]);
                        sw.WriteLine(node?.Value ?? "none");
                        break;
                    case 'p':
                        map.Add(query[1], query[2]);
                        break;
                    default:
                        map.Delete(query[1]);
                        break;
                }
            }
        }
    }
}
