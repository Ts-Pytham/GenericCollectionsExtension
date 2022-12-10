using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollectionsExtension.Queue
{
    public class Deque<T> : IDeque<T>, IEnumerable<T>
    {
        public int Capacity { get; }

        public int Count { get => _deque.Count; }

        public bool IsReadOnly => false;

        private readonly List<T> _deque;

        public Deque()
        {
            _deque = new List<T>();
            Capacity = -1;
        }

        public Deque(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _deque = new List<T>();
            Capacity = capacity;
        }

        public void Add(T item)
        {
            PushFirst(item);
        }

        public void Clear()
        {
            _deque.Clear();
        }

        public bool Contains(T item)
        {
            return _deque.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _deque.CopyTo(array, arrayIndex);
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            var value = _deque[0];
            _deque.RemoveAt(0);
            return value;
        }

        public T PopLast()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            var value = _deque[Count - 1];
            _deque.RemoveAt(Count - 1);
            return value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _deque.GetEnumerator();
        }

        public T Peek()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            return _deque[0];
        }

        public T PeekLast()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            return _deque[Count - 1];
        }

        
        public void PushFirst(T item)
        {
            if (Capacity != -1 && Capacity == Count)
            {
                throw new ArgumentOutOfRangeException(nameof(Capacity));
            }

            _deque.Insert(0, item);
        }

        public void PushLast(T item)
        {
            if (Capacity != -1 && Capacity == Count)
            {
                throw new ArgumentOutOfRangeException(nameof(Capacity));
            }

            _deque.Insert(Count, item);
        }

        public bool Remove(T item)
        {
            return _deque.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _deque.GetEnumerator();
        }
    }
}
