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

        //public static void ShouldContain(this BST tree, params int[] values)
        //{
        //    foreach (int num in values)
        //        tree.Find(num).Value.Should().Be(num);
        //}

        //public static void ShouldNotContain(this BST tree, params int[] values)
        //{
        //    foreach (int num in values)
        //        tree.Find(num).Should().BeNull();
        //}
    }
}
