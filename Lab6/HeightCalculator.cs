using System;
using System.Linq;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab6
{
    public class HeightCalculator : FileTask
    {
        public static int GetHeight(IList<(int lch, int rch)> tree)
        {
            var height = 1;

            var stack = new Stack<(int index, int height)>();
            stack.Push((0, 1));

            while (stack.Any())
            {
                var cur = stack.Pop();
                height = Math.Max(height, cur.height);

                var node = tree[cur.index];

                if(node.lch != -1)
                    stack.Push((node.lch, cur.height + 1));

                if(node.rch != -1)
                    stack.Push((node.rch, cur.height + 1));
            }

            return height;
        }

        public override void Execute()
        {
            var length = ReadInt();

            if (length == 0)
            {
                Write(0);
                return;
            }

            var tree = new (int, int)[length];

            for (int i = 0; i < length; i++)
            {
                var query = ReadLine().Split();

                tree[i] = ((int.Parse(query[1]) - 1, int.Parse(query[2]) - 1));
            }

            Write(GetHeight(tree));
        }
    }
}
