using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Stack
{
    /// <summary>
    /// Represents an interface for a stack data structure.
    /// </summary>
    /// <typeparam name="T">The type of elements in the stack.</typeparam>
    public interface IStack<T> : ICollection<T>
    {
        /// <summary>
        /// Gets the maximum number of elements that the stack can hold.
        /// A value of -1 indicates that the stack has no capacity limit.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Returns the element at the top of the stack without removing it.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        T Peek();

        /// <summary>
        /// Removes and returns the element at the top of the stack.
        /// </summary>
        /// <returns>The element at the top of the stack.</returns>
        T Pop();
    }
}
