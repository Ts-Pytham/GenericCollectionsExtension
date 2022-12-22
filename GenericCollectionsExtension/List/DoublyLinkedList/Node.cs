using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.List
{
    /// <summary>
    /// Represents a doubly linked list node.
    /// </summary>
    /// <typeparam name="T">The type of the value stored in the node.</typeparam>
    internal class Node<T>
    {
        /// <summary>
        /// Gets or sets the value stored in the node.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Gets or sets the previous node in the linked list.
        /// </summary>
        public Node<T> Previous { get; set; }

        /// <summary>
        /// Gets or sets the next node in the linked list.
        /// </summary>
        public Node<T> Next { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class with the specified value.
        /// </summary>
        /// <param name="value">The value to be stored in the node.</param>
        public Node(T value)
        {
            Value = value;
            Previous = null;
            Next = null;
        }
    }
}
