using GenericCollectionsExtension.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionsExtension.Stack
{
    public class PriorityStack<T> : IPriorityStack<T>, ICollection<T>, IEnumerable<T>
    {
        private readonly List<PriorityObject<T>> _stack;

        public int Capacity { get; }

        public int Count { get => _stack.Count; }

        public bool IsReadOnly => false;

        public PriorityStack()
        {
            _stack = new List<PriorityObject<T>>();
            Capacity = -1;
        }

        public PriorityStack(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _stack = new List<PriorityObject<T>>();
            Capacity = capacity;
        }

        public void Add(T item)
        {
            Push(item, 0);
        }

        public void Clear()
        {
            _stack.Clear();
        }

        public bool Contains(T item)
        {
            return ExistsItem(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _stack.CopyTo(array.Select(x => new PriorityObject<T> { Priority = 0, Value = x }).ToArray(), arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _stack.Select(x => x.Value).Reverse().GetEnumerator();
        }

        public T Peek()
        {
            return _stack[Count - 1].Value;
        }

        public T Pop()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            var value = _stack[Count - 1].Value;
            _stack.RemoveAt(Count - 1);
            return value;
        }

        public void Push(T item, int priority)
        {
            if (Capacity != -1 && Capacity == Count)
            {
                throw new ArgumentOutOfRangeException(nameof(Capacity));
            }

            if (priority < 0)
            {
                throw new NegativeNumberException();
            }

            var value = new PriorityObject<T> { Value = item, Priority = priority };

            if (_stack.Count == 0)
            {
                _stack.Add(value);
            }
            else
            {
                Push(value);
            }
        }

        private void Push(PriorityObject<T> item)
        {
            for (int index = 0; index != Count; ++index)
            {
                if (item > _stack[index])
                {
                    _stack.Insert(index, item);
                    return;
                }
            }
            _stack.Add(item);
        }

        public bool Remove(T item)
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            int index = ExistsItem(item);

            if (index == -1) return false;

            _stack.RemoveAt(index);

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _stack.Select(x => x.Value).Reverse().GetEnumerator();
        }

        private int ExistsItem(T item)
        {
            for (int i = 0, j = Count - 1; i != Count && j >= 0; ++i, --j)
            {
                if (_stack[i].Value.Equals(item))
                {
                    return i;
                }

                if (_stack[j].Value.Equals(item))
                {
                    return j;
                }
            }

            return -1;
        }
    }
}
