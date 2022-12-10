using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionsExtension.Queue.PriorityQueue
{
    public class PriorityQueue<T> : IPriorityQueue<T>, IEnumerable<T>, ICollection<T>
    {
        private readonly List<PriorityObject<T>> _queue;

        public int Count { get => _queue.Count; }
        public bool IsReadOnly { get => false; }

        public int Capacity 
        { 
            get;
        }

        public PriorityQueue()
        {
            _queue= new List<PriorityObject<T>>();
            Capacity = -1;
        }

        public PriorityQueue(int capacity)
        {
            if(capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            _queue = new List<PriorityObject<T>>(capacity);
            Capacity = capacity;
        }

        public void Add(T item)
        {
            Enqueue(item, 0);
        }

        public void Clear()
        {
            _queue.Clear();
        }

        public bool Contains(T item)
        {
            return ExistsItem(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _queue.CopyTo(array.Select(x => new PriorityObject<T> { Priority = 0, Value = x}).ToArray(), arrayIndex);
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            var value = _queue[0].Value;
            _queue.RemoveAt(0);
            return value;
        }

        public void Enqueue(T item, int priority)
        {
            if (Capacity != -1 && Capacity == Count)
            {
                throw new ArgumentOutOfRangeException(nameof(Capacity));
            }
                
            var value = new PriorityObject<T> { Value = item, Priority = priority };
            if (_queue.Count == 0)
            {
                _queue.Add(value);
            }
            else
            {
                Enqueue(value);
            }
        }

        private void Enqueue(PriorityObject<T> item)
        {
            for(int index = 0; index != Count; ++index)
            {
                if(item > _queue[index])
                {
                    _queue.Insert(index, item);
                    return;
                }
            }
            _queue.Add(item);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _queue.Select(x => x.Value).GetEnumerator();
        }

        public T Peek()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            return _queue[0].Value;
        }

        public bool Remove(T item)
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            int index = ExistsItem(item);

            if (index == -1) return false;

            _queue.RemoveAt(index);

            return true;
        }

        private int ExistsItem(T item)
        {
            for (int i = 0, j = Count - 1; i != Count && j >= 0; ++i, --j)
            {
                if (_queue[i].Value.Equals(item))
                {
                    return i;
                }

                if (_queue[j].Value.Equals(item))
                {
                    return j;
                }
            }

            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queue.Select(x => x.Value).GetEnumerator();
        }

    }
}
