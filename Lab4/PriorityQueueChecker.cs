using System;
using System.Collections.Generic;
using CodeChallenge.Core;

namespace Lab4
{
    public class PriorityQueue<T>
    {
        private readonly List<(T Value, long PushNum)> _heap = new List<(T, long)>();

        private int Count
            => _heap.Count;

        private int Last
            => _heap.Count - 1;

        private void SiftUp(int index)
        {
            while (index != 0)
            {
                int parent = (index - 1) / 2;
                if (_heap.Compare(index, parent) >= 0)
                    return;

                _heap.Swap(index, parent);
                index = parent;
            }
        }

        private void SiftDown(int index)
        {
            while (2 * index + 1 < _heap.Count)
            {
                int lch = 2 * index + 1;
                int rch = 2 * index + 2;

                int swapChild = lch;
                if (rch < _heap.Count && _heap.Compare(lch, rch) > 0)
                    swapChild = rch;

                if (_heap.Compare(index, swapChild) <= 0)
                    return;

                _heap.Swap(index, swapChild);
                index = swapChild;
            }
        }

        public void Push(T value, long pushNum)
        {
            _heap.Add((value, pushNum));
            SiftUp(Last);
        }

        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Priority queue is empty");

            var value = _heap[0].Value;

            _heap.Swap(0, Last);
            _heap.RemoveAt(Last);

            SiftDown(0);

            return value;
        }

        public void DecreaseKey(long pushNum, T newValue)
        {
            var index = _heap.FindIndex(el => el.PushNum == pushNum);
            _heap[index] = (newValue, pushNum);
            SiftUp(index);
        }
    }

    public class PriorityQueueChecker : IConsoleTask
    {
        public void ExecuteConsole()
        {
            var heap = new PriorityQueue<int>();
            long cmdNum = 1;

            do
            {
                var query = Console.ReadLine()?.Split();
                if (query == null)
                    return;

                switch (query[0][0])
                {
                    case 'p':
                        heap.Push(int.Parse(query[1]), cmdNum);
                        break;
                    case 'e':
                        try
                        {
                            Console.WriteLine(heap.Pop());
                        }
                        catch (InvalidOperationException)
                        {
                            Console.WriteLine("*");
                        }

                        break;
                    default:
                        heap.DecreaseKey(long.Parse(query[1]), int.Parse(query[2]));
                        break;
                }

                cmdNum++;

            } while (true);
        }
    }
}
