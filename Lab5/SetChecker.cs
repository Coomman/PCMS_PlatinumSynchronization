using System;
using System.IO;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab5
{
    public class Set
    {
        private readonly List<int>[] _hashTable = new List<int>[InitialSize];

        private const int InitialSize = 24_036_583;

        private static int MakeHash(int value)
            => Math.Abs(value) % InitialSize;

        public bool Contains(int value)
        {
            return _hashTable[MakeHash(value)]?.Contains(value) ?? false;
        }
        public void Add(int value)
        {
            var hash = MakeHash(value);

            if(_hashTable[hash] is null)
                _hashTable[hash] = new List<int>();

            if (!_hashTable[hash].Contains(value))
                _hashTable[hash].Add(value);
        }
        public void Delete(int value)
        {
            _hashTable[MakeHash(value)]?.Remove(value);
        }
    }

    public class SetChecker : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var set = new Set();

            while (!sr.EndOfStream)
            {
                var query = sr.ReadLine().Split();

                switch (query[0][0])
                {
                    case 'e':
                        sw.WriteLine(set.Contains(int.Parse(query[1])) ? "true" : "false");
                        break;
                    case 'i':
                        set.Add(int.Parse(query[1]));
                        break;
                    default:
                        set.Delete(int.Parse(query[1]));
                        break;
                }
            }
        }
    }
}
