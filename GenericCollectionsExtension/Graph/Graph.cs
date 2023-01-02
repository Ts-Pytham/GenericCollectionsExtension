using GenericCollectionsExtension.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Graph
{
    public class Graph<TVertex, TEdge> : IGraph<TVertex, TEdge>, ICollection<Vertex<TVertex, TEdge>>, IEnumerable<Vertex<TVertex, TEdge>>
        where TEdge : IComparable<TEdge>
    {

        public List<Vertex<TVertex, TEdge>> Vertexs { get; }

        public int Count => Vertexs.Count;

        public bool IsReadOnly => false;

        public Graph()
        {
            Vertexs = new List<Vertex<TVertex, TEdge>>();
        }

        public Graph(Vertex<TVertex, TEdge> item)
        {
            Vertexs = new List<Vertex<TVertex, TEdge>>();

            Add(item);
        }

        public Graph(IEnumerable<Vertex<TVertex, TEdge>> items)
        {
            Vertexs = new List<Vertex<TVertex, TEdge>>();

            foreach(var item in items)
            {
                Add(item);
            }
        }

        public void Add(Vertex<TVertex, TEdge> item)
        {
            if (HasVertex(item.VertexName))
            {
                throw new ExistentVertexException();
            }

            AddVertex(item.VertexName);
        }

        public void AddEdge(TVertex v1, TVertex v2, TEdge edge)
        {
            if (HasVertex(v1, out Vertex<TVertex, TEdge> vertex) is null || !HasVertex(v2))
            {
                throw new NonExistentVertexException();
            }

            vertex.AddEdge(new Edge<TVertex, TEdge>(v2, edge));
        }

        public void AddVertex(TVertex vertex)
        {
            if (HasVertex(vertex))
            {
                throw new ExistentVertexException();
            }

            Vertexs.Add(new Vertex<TVertex, TEdge>(vertex));
        }

        public void Clear()
        {
            Vertexs.Clear();
        }

        public bool Contains(Vertex<TVertex, TEdge> item)
        {
            return Vertexs.Contains(item);
        }

        public void CopyTo(Vertex<TVertex, TEdge>[] array, int arrayIndex)
        {
            Vertexs.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Vertex<TVertex, TEdge>> GetEnumerator()
        {
            return Vertexs.GetEnumerator();
        }

        public bool HasEdge(TVertex v1, TVertex v2)
        {
            throw new NotImplementedException();
        }

        public bool HasVertex(TVertex vertex)
        {
            return Vertexs.Find(x => x.VertexName.Equals(vertex)) is not null;
        }

        public Vertex<TVertex, TEdge> HasVertex(TVertex name, out Vertex<TVertex, TEdge> vertex)
        {
            vertex = Vertexs.Find(x => x.VertexName.Equals(name));

            return vertex;
        }

        public bool Remove(Vertex<TVertex, TEdge> item)
        {
            throw new NotImplementedException();
        }

        public void RemoveEdge(TVertex v1, TVertex v2)
        {
            throw new NotImplementedException();
        }

        public void RemoveVertex(TVertex vertex)
        {
            Vertexs.Remove(HasVertex(vertex, out _));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Vertexs.GetEnumerator();

        }
    }
}
