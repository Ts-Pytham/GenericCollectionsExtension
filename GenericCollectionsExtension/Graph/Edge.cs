using System;

namespace GenericCollectionsExtension.Graph
{
    /// <summary>
    /// Represents an edge in a graph, connecting two vertices and having a cost associated with it.
    /// </summary>
    /// <typeparam name="T">The type of the vertices connected by the edge.</typeparam>
    /// <typeparam name="U">The type of the cost associated with the edge.</typeparam>
    public class Edge<T, U>
        where U : IComparable<U>
    {
        /// <summary>
        /// Gets or sets the vertex that the edge connects to.
        /// </summary>
        public T Sucessor { get; set; }

        /// <summary>
        /// Gets or sets the cost of the edge.
        /// </summary>
        public U Cost { get; set; }

        /// <summary>
        /// Constructs a new instance of the edge with the specified sucessor and cost.
        /// </summary>
        /// <param name="sucessor">The vertex that the edge connects to.</param>
        /// <param name="cost">The cost of the edge.</param>
        public Edge(T sucessor, U cost)
        {
            Sucessor = sucessor;
            Cost = cost;
        }
    }
}
