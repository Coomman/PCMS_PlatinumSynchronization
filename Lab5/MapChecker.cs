using System.IO;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab5
{
    public class Map<TKey, TValue>
    {
        public class Node
        {
            public TKey Key { get; }
            public TValue Value { get; set; }

            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }

        private readonly List<Node>[] _hashTable = new List<Node>[InitialSize];

        private const int InitialSize = 30_402_457;

        private static int MakeHash(TKey key)
            => EntryPoint.MakeHash(key, InitialSize);

        public Node Get(TKey key)
        {
            return _hashTable[MakeHash(key)]?.Find(node => node.Key.Equals(key));
        }
        public void Add(TKey key, TValue value)
        {
            var node = Get(key);

            if (node is null)
            {
                var hash = MakeHash(key);

                if (_hashTable[hash] is null)
                    _hashTable[hash] = new List<Node>();

                _hashTable[hash].Add(new Node(key, value));
                return;
            }

            node.Value = value;
        }
        public void Delete(TKey key)
        {
            var node = Get(key);

            if (node is null)
                return;

            _hashTable[MakeHash(key)].Remove(node);
        }
    }

    public class MapChecker : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var map = new Map<string, string>();

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
