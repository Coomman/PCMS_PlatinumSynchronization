using System;
using CodeChallenge.Core;

namespace Lab4
{
    public class Queue<T>
    {
        private T[] _queue;

        private int _head;
        private int _tail;

        private const int InitialSize = 4;

        public Queue()
        {
            _queue = new T[InitialSize];
        }
        public Queue(int capacity)
        {
            _queue = new T[capacity];
        }

        public T Peek()
        {
            SizeCheck();

            return _queue[_head];
        }
        public T Pop()
        {
            SizeCheck();

            return _queue[_head++];
        }
        public void Push(T value)
        {
            if (_tail == _queue.Length)
                ExpandArray();

            _queue[_tail++] = value;
        }

        private void ExpandArray()
        {
            var newQueue = new T[_tail * 2];

            Array.Copy(_queue, _head, newQueue, 0, _tail - _head);
            _tail -= _head;
            _head = 0;

            _queue = newQueue;
        }
        private void SizeCheck()
        {
            if (_head == _tail)
                throw new InvalidOperationException("Queue is empty");
        }
    }

    public class QueueChecker : FileTask
    {
        public override void Execute()
        {
            var length = ReadInt();

            var queue = new Queue<int>(length);

            while (!EndOfStream())
            {
                var query = ReadLine().Split();

                if (query[0][0] == '+')
                    queue.Push(int.Parse(query[1]));
                else
                    WriteLine(queue.Pop());
            }
        }
    }
}
