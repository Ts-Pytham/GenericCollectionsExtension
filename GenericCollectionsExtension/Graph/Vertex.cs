using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionsExtension.Graph
{
     /// <summary>
     /// Represents a vertex in a graph, with a name and a list of edges connecting it to other vertices.
     /// </summary>
     /// <typeparam name="T">The type of the vertex name.</typeparam>
     /// <typeparam name="U">The type of the cost associated with the edges connected to the vertex.</typeparam>
    public class Vertex<T, U> : IEquatable<Vertex<T, U>>
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
            Edges = new List<Edge<T, U>>();
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

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as Vertex<T, U>);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            var hashCode = -1712825106;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(VertexName);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Edge<T, U>>>.Default.GetHashCode(Edges);
            return hashCode;
        }

        /// <summary>
        /// Determines if this vertex is equal to another vertex based on the vertex name and edges.
        /// </summary>
        /// <param name="other">The other vertex to compare with.</param>
        /// <returns>True if the vertices are equal, false otherwise.</returns>
        public bool Equals(Vertex<T, U> other)
        {
            if(other is null) return false;

            if (other.VertexName.Equals(VertexName) && other.Edges.SequenceEqual(Edges))
            {
                return true;
            }

            return false;
        }
    }
}
