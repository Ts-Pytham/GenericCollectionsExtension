using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Graph
{
    internal class Vertex<T, U>
        where U : IComparable<U>
    {
        public T VertexName { get; set; }

        public List<Edge<T, U>> Edges { get; }

        public Vertex(T Vertex)
        {
            VertexName = Vertex;
        }

        public void AddEdge(Edge<T, U> edge)
        {
            Edges.Add(edge);
        }

    }
}
