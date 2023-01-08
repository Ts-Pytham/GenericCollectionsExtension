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
        public Vertex<T, U> Sucessor { get; set; }

        /// <summary>
        /// The predecessor of this vertex in the graph.
        /// </summary>
        public Vertex<T, U> Predecessor { get; set; }

        /// <summary>
        /// Gets or sets the cost of the edge.
        /// </summary>
        public U Cost { get; set; }

        /// <summary>
        /// Initializes a new instance of the Edge class with the specified sucessor vertex, predecessor vertex, and cost.
        /// </summary>
        /// <param name="sucessor">The sucessor vertex of the edge.</param>
        /// <param name="predecessor">The predecessor vertex of the edge.</param>
        /// <param name="cost">The cost of the edge.</param>
        public Edge(Vertex<T, U> predecessor, Vertex<T, U> sucessor, U cost)
        {
            Sucessor = sucessor;
            Predecessor = predecessor;
            Cost = cost;
        }
    }
}
