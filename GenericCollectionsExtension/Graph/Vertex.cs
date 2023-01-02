using System;
using System.Collections.Generic;

namespace GenericCollectionsExtension.Graph
{
     /// <summary>
     /// Represents a vertex in a graph, with a name and a list of edges connecting it to other vertices.
     /// </summary>
     /// <typeparam name="T">The type of the vertex name.</typeparam>
     /// <typeparam name="U">The type of the cost associated with the edges connected to the vertex.</typeparam>
    public class Vertex<T, U>
        where U : IComparable<U>
    {
        /// <summary>
        /// Gets or sets the name of the vertex.
        /// </summary>
        public T VertexName { get; set; }

        /// <summary>
        /// Gets the list of edges connecting the vertex to other vertices.
        /// </summary>
        public List<Edge<T, U>> Edges { get; }

        /// <summary>
        /// Constructs a new instance of the vertex with the specified name.
        /// </summary>
        /// <param name="Vertex">The name of the vertex.</param>
        public Vertex(T Vertex)
        {
            VertexName = Vertex;
        }

        /// <summary>
        /// Adds an edge to the list of edges connecting the vertex to other vertices.
        /// </summary>
        /// <param name="edge">The edge to be added.</param>
        public void AddEdge(Edge<T, U> edge)
        {
            Edges.Add(edge);
        }

    }
}
