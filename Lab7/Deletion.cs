﻿using System.IO;
using CodeChallenge.Core;

namespace Lab7
{
    public class Deletion : IFileTask
    {
        private readonly AVL _avl = new AVL();

        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            var length = int.Parse(sr.ReadLine());

            if (length == 1)
            {
                sw.WriteLine(0);
                return;
            }

            var tree = new AvlNode[length];
            for (int i = 0; i < length; i++)
            {
                var query = sr.ReadLine().Split();
                tree[i] = new AvlNode(int.Parse(query[0]))
                    { Lch = int.Parse(query[1]) - 1, Rch = int.Parse(query[2]) - 1 };
            }

            _avl.BuildTree(tree);
            _avl.Delete(int.Parse(sr.ReadLine()));
            var result = _avl.Reorder();

            sw.WriteLine(result.Count);
            foreach (var node in result)
                sw.WriteLine($"{node.Value} {node.Lch} {node.Rch}");
        }
    }
}