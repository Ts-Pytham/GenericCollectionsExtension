using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollectionsExtension.Queue
{
    /// <summary>
    /// This class implements a double-ended queue (deque).
    /// A deque is a queue that supports adding and removing elements from both ends of the queue.
    /// </summary>
    /// <typeparam name="T">The type of elements in the deque.</typeparam>
    public class Deque<T> : IDeque<T>, IEnumerable<T>
    {
        /// <summary>
        /// Gets the maximum number of elements the deque can hold.
        /// If the value is -1, the deque can hold an unlimited number of elements.
        /// </summary>
        public int Capacity { get; }

        /// <summary>
        /// Gets the number of elements in the deque.
        /// </summary>
        public int Count { get => _deque.Count; }

        /// <summary>
        /// Gets a value indicating whether the deque is read-only.
        /// This property always returns false.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// List of elements in the deque.
        /// </summary>
        private readonly List<T> _deque;

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque{T}"/> class.
        /// The deque can hold an unlimited number of elements.
        /// </summary>
        public Deque()
        {
            _deque = new List<T>();
            Capacity = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Deque{T}"/> class.
        /// The deque can hold a maximum of the specified number of elements.
        /// </summary>
        /// <param name="capacity">The maximum number of elements the deque can hold.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="capacity"/> is less than 1.
        /// </exception>
        public Deque(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            _deque = new List<T>();
            Capacity = capacity;
        }

        /// <summary>
        /// Adds the specified item to the front of the deque.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(T item)
        {
            PushFirst(item);
        }

        /// <summary>
        /// Removes all elements from the deque.
        /// </summary>
        public void Clear()
        {
            _deque.Clear();
        }

        /// <summary>
        /// Determines whether the deque contains the specified item.
        /// </summary>
        /// <param name="item">The item to search for in the deque.</param>
        /// <returns>
        /// True if the deque contains the item, false otherwise.
        /// </returns>
        public bool Contains(T item)
        {
            return _deque.Contains(item);
        }

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _deque.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public T Dequeue()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            var value = _deque[0];
            _deque.RemoveAt(0);
            return value;
        }

        /// <inheritdoc/>
        public T PopLast()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            var value = _deque[Count - 1];
            _deque.RemoveAt(Count - 1);
            return value;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the deque.
        /// </summary>
        /// <returns>An enumerator for the deque.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _deque.GetEnumerator();
        }

        /// <inheritdoc/>
        public T Peek()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            return _deque[0];
        }

        /// <inheritdoc/>
        public T PeekLast()
        {
            if (Count == 0)
                throw new IndexOutOfRangeException();

            return _deque[Count - 1];
        }

        /// <inheritdoc/>
        public void PushFirst(T item)
        {
            if (Capacity != -1 && Capacity == Count)
            {
                throw new ArgumentOutOfRangeException(nameof(Capacity));
            }

            _deque.Insert(0, item);
        }

        /// <inheritdoc/>
        public void PushLast(T item)
        {
            if (Capacity != -1 && Capacity == Count)
            {
                throw new ArgumentOutOfRangeException(nameof(Capacity));
            }

            _deque.Insert(Count, item);
        }

        /// <summary>
        /// Removes the first occurrence of the specified item from the deque.
        /// </summary>
        /// <param name="item">The item to remove from the deque.</param>
        /// <returns>
        /// True if the item was found and removed from the deque, false otherwise.
        /// </returns>
        public bool Remove(T item)
        {
            return _deque.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the deque.
        /// </summary>
        /// <returns>An enumerator for the deque.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _deque.GetEnumerator();
        }
    }
}
