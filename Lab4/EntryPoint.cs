using System;
using CodeChallenge.Core;

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

    internal class EntryPoint
    {
        private static void Main()
        {
            //TaskRunner.ExecuteFile(new StackChecker(), "stack");
            //TaskRunner.ExecuteFile(new QueueChecker(), "queue");
            //TaskRunner.ExecuteFile(new BracketsController(), "brackets");
            //TaskRunner.ExecuteFile(new PolishNotationController(), "postfix");
            TaskRunner.ExecuteConsole(new PriorityQueueChecker());
        }
    }
}
