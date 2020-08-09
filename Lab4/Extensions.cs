using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Stack<T>
    {
        private T[] _stack;
        private int _size;

        private const int InitialSize = 4;

        public Stack()
        {
            _stack = new T[InitialSize];
        }
        public Stack(int capacity)
        {
            _stack = new T[capacity];
        }

        public T Peek()
        {
            SizeCheck();

            return _stack[_size - 1];
        }
        public T Pop()
        {
            SizeCheck();

            return _stack[--_size];
        }
        public void Push(T value)
        {
            if (_size == _stack.Length)
                ExpandArray();

            _stack[_size++] = value;
        }

        public bool IsEmpty
            => _size == 0;

        private void ExpandArray()
        {
            var newStack = new T[_size * 2];

            Array.Copy(_stack, newStack, _size);

            _stack = newStack;
        }
        private void SizeCheck()
        {
            if (_size == 0)
                throw new InvalidOperationException("Stack is empty");
        }
    }

    internal static class Extensions
    {
        public static void Swap<T>(this IList<T> arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
        public static int Compare<T>(this IList<T> arr, int first, int second) where T : IComparable
        {
            return arr[first].CompareTo(arr[second]);
        }
    }
}
