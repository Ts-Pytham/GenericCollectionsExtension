using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

namespace GenericCollectionsExtension.Queue
{
    /// <summary>
    /// This interface defines the operations that a queue data structure should support.
    /// A queue is a collection of elements that are inserted and removed according to the first-in-first-out (FIFO) principle.
    /// </summary>
    /// <typeparam name="T">The type of elements in the queue.</typeparam>
    public interface IQueue<T> : ICollection<T>
    {
        /// <summary>
        /// Gets the maximum number of elements that the queue can hold.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Removes and returns the first element in the queue.
        /// </summary>
        /// <returns>The first element in the queue.</returns>
        T Dequeue();

        /// <summary>
        /// Returns the first element in the queue without removing it.
        /// </summary>
        /// <returns>The first element in the queue.</returns>
        T Peek();
    }

}
