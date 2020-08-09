using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using CodeChallenge.Core;

namespace Lab3
{
    public enum HeapType { Min, Max };

    public class Heap<T> where T: IComparable
    {
        private List<T> _heap;
        private readonly Func<int, int, bool> _mainCompare;
        private readonly Func<int, int, bool> _reverseCompare;

        private int Last()
            => _heap.Count - 1;

        public Heap(HeapType type)
        {
            _heap = new List<T>();

            if (type == HeapType.Min)
            {
                _mainCompare = (a, b) => _heap.Compare(a, b) < 0;
                _reverseCompare = (a, b) => _heap.Compare(a, b) > 0;
            }
            else
            {
                _mainCompare = (a, b) => _heap.Compare(a, b) > 0;
                _reverseCompare = (a, b) => _heap.Compare(a, b) < 0;
            }
        }
        public Heap(IEnumerable<T> arr, HeapType type)
        {
            _heap = new List<T>(arr);

            if (type == HeapType.Min)
            {
                _mainCompare = (a, b) => _heap.Compare(a, b) < 0;
                _reverseCompare = (a, b) => _heap.Compare(a, b) > 0;
            }
            else
            {
                _mainCompare = (a, b) => _heap.Compare(a, b) > 0;
                _reverseCompare = (a, b) => _heap.Compare(a, b) < 0;
            }
            
            MakeHeap();
        }

        private void SiftUp(int index)
        {
            while (index != 0)
            {
                int parent = (index - 1) / 2;
                if (!_mainCompare(index, parent))
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
                if (rch < _heap.Count && _reverseCompare(lch, rch))
                    swapChild = rch;

                if (!_reverseCompare(index, swapChild))
                    return;

                _heap.Swap(index, swapChild);
                index = swapChild;
            }
        }
        private void MakeHeap()
        {
            int index = _heap.Count / 2;
            while (index > 0)
                SiftDown(--index);
        }

        public void Push(T value)
        {
            _heap.Add(value);
            SiftUp(Last());
        }
        public T Top()
        {
            if (_heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            return _heap[0];
        }
        public T Pop()
        {
            var top = Top();

            _heap[0] = _heap[Last()];
            _heap.RemoveAt(Last());

            SiftDown(0);
            return top;
        }

        public void Sort(IList<T> arr)
        {
            var temp = _heap;

            _heap = new List<T>(arr);
            MakeHeap();

            for (int i = 0; i < arr.Count; i++)
                arr[i] = Pop();

            _heap = temp;
        }
        public void Merge(Heap<T> other)
        {
            _heap.AddRange(other._heap);
            MakeHeap();
        }

        public int Count
            => _heap.Count;
        public void Show()
        {
            Console.WriteLine(string.Join("\t", _heap));
        }
    }

    public class HeapSorter : IFileTask
    {
        public void ExecuteFile(StreamReader sr, StreamWriter sw)
        {
            sr.ReadLine();
            var arr = sr.ReadLine().TrimEnd().Split().Select(int.Parse).ToArray();

            var heap = new Heap<int>(HeapType.Min);
            heap.Sort(arr);

            sw.Write(string.Join(" ", arr));
        }
    }
}
