using Lab6;
using System;
using CodeChallenge.Core;
using FluentAssertions;

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
                tree.Find(value).Value.Should().NotBeNull();
        }
        public static void ShouldNotContain<T>(this BST<T> tree, params T[] values) where T: IComparable
        {
            foreach (var value in values)
                tree.Find(value).Should().BeNull();
        }
    }
}
