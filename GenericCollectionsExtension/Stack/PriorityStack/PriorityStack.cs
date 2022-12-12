using GenericCollectionsExtension.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionsExtension.Stack
{
    /// <summary>
    /// This is a PriorityStack class.
    /// </summary>
    /// <typeparam name="T">The type of data to be stored in the PriorityStack.</typeparam>
    public class PriorityStack<T> : IPriorityStack<T>, ICollection<T>, IEnumerable<T>
    {
        /// <summary>
        /// list of PriorityObjects that store the elements in the stack along with their priorities.
        /// </summary>
        private readonly List<PriorityObject<T>> _stack;

        public int Capacity { get; }

        public int Count { get => _stack.Count; }

        public bool IsReadOnly => false;

        /// <summary>
        /// Constructs a new instance of the <see cref="PriorityStack{T}"/> class.
        /// </summary>
        public PriorityStack()
        {
            _stack = new List<PriorityObject<T>>();
            Capacity = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriorityStack{T}"/>  class with the specified capacity.
        /// </summary>
        /// <param name="capacity">The maximum number of elements that the stack can hold.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the specified capacity is less than 1.</exception>
        public PriorityStack(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _stack = new List<PriorityObject<T>>();
            Capacity = capacity;
        }

        /// <summary>
        /// Adds an element to the stack with the default priority (0).
        /// </summary>
        /// <param name="item">The element to add to the stack.</param>
        public void Add(T item)
        {
            Push(item, 0);
        }

        /// <summary>
        /// Removes all elements from the stack.
        /// </summary>
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

        /// <summary>
        /// Returns an enumerator that iterates through the stack.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the stack.</returns>
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

        /// <summary>
        /// Adds a <see cref="PriorityObject{T}"/> item to a sorted stack while maintaining priority order.
        /// If the item is more prioritized than any other in the stack, it is inserted at the first position.
        /// If it is not more prioritized than any other, it is added to the end of the stack.
        /// </summary>
        /// <param name="item">The item to add to the stack.</param>
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

        /// <summary>
        /// Removes the specified item from the stack.
        /// </summary>
        /// <param name="item">The item to remove from the stack.</param>
        /// <returns>True if the item was successfully removed from the stack, or false if the item was not found in the stack.</returns>
        public bool Remove(T item)
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            int index = ExistsItem(item);

            if (index == -1) return false;

            _stack.RemoveAt(index);

            return true;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the stack.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the stack.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _stack.Select(x => x.Value).Reverse().GetEnumerator();
        }

        /// <summary>
        /// Determines if the specified element exists in the stack.
        /// If the element exists, the method returns its index in the stack.
        /// Otherwise, the method returns -1.
        /// </summary>
        /// <param name="item">The element to search for in the stack.</param>
        /// <returns>The index of the element in the stack, or -1 if the element is not found.</returns>
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
