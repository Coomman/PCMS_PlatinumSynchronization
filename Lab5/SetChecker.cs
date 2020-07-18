﻿using System.IO;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab5
{
    public class Set<T>
    {
        private readonly List<T>[] _hashTable = new List<T>[InitialSize];

        private const int InitialSize = 24_036_583;

        private static int MakeHash(T key)
            => EntryPoint.MakeHash(key, InitialSize);

        public bool Contains(T value)
        {
            return _hashTable[MakeHash(value)]?.Contains(value) ?? false;
        }
        public void Add(T value)
        {
            var hash = MakeHash(value);

            if(_hashTable[hash] is null)
                _hashTable[hash] = new List<T>();

            if (!_hashTable[hash].Contains(value))
                _hashTable[hash].Add(value);
        }
        public void Delete(T value)
        {
            _hashTable[MakeHash(value)]?.Remove(value);
        }
    }

    public class SetChecker : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var set = new Set<int>();

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
