using System;
using System.Linq;

namespace Lab5
{
    internal static class Extensions
    {
        private static int MakeHash(int key, int hashTableSize)
        {
            return Math.Abs(key) % hashTableSize;
        }
        private static int MakeHash(string key, int hashTableSize)
        {
            int hash = key.Select((ch, i) => (i + 1) * ch).Sum();

            return Math.Abs(hash) % hashTableSize;
        }

        public static int MakeHash<T>(T key, int hashTableSize)
        {
            if (key is string strKey)
                return MakeHash(strKey, hashTableSize);

            if (key is int intKey)
                return MakeHash(intKey, hashTableSize);

            throw new ArgumentOutOfRangeException(nameof(key), "Implementation for this type of key does not exist");
        }
    }
}
