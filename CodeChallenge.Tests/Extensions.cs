using Lab6;
using Lab7;
using System;
using CodeChallenge.Core;
using FluentAssertions;
using System.Linq;
using System.Collections.Generic;

namespace CodeChallenge.Tests
{
    internal static class Extensions
    {
        public static bool CheckSort<T>(this T[] arr) where T : IComparable
        {
            if (arr is null || arr.Length < 2)
                return true;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr.Compare(i, i + 1) > 0)
                    return false;
            }

            return true;
        }

        public static void ShouldContain<T>(this BST<T> tree, params T[] values) where T: IComparable
        {
            foreach (var value in values)
                tree.Find(value).Should().NotBeNull();
        }
        public static void ShouldNotContain<T>(this BST<T> tree, params T[] values) where T: IComparable
        {
            foreach (var value in values)
                tree.Find(value).Should().BeNull();
        }

        public static void ShouldContain(this List<AvlNode> avl, params AvlNode[] nodes)
        {
            avl.Count.Should().Be(nodes.Length);

            foreach (var node in nodes)
                avl.Any(avlNode => node.Value == avlNode.Value &&
                                   node.Lch == avlNode.Lch && node.Rch == avlNode.Rch).Should().BeTrue();
        }
    }
}
