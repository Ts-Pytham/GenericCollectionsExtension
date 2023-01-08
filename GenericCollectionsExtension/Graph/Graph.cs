﻿using GenericCollectionsExtension.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionsExtension.Graph
{
    /// <summary>
    /// Represents a graph data structure, composed of vertices and edges connecting them.
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertices in the graph.</typeparam>
    /// <typeparam name="TEdge">The type of the edges in the graph (cost).</typeparam>
    public class Graph<TVertex, TEdge> : IGraph<TVertex, TEdge>, ICollection<Vertex<TVertex, TEdge>>, IEnumerable<Vertex<TVertex, TEdge>>
        where TEdge : IComparable<TEdge>
    {
        /// <summary>
        /// Gets the list of vertices in the graph.
        /// </summary>
        public List<Vertex<TVertex, TEdge>> Vertexs { get; }

        /// <summary>
        /// Gets the number of vertices in the graph.
        /// </summary>
        public int Count => Vertexs.Count;

        /// <summary>
        /// Gets a value indicating whether the graph is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Constructs a new instance of the graph with no vertices.
        /// </summary>
        public Graph()
        {
            Vertexs = new List<Vertex<TVertex, TEdge>>();
        }

        /// <summary>
        /// Constructs a new instance of the graph with a single vertex.
        /// </summary>
        /// <param name="item">The vertex to be added to the graph.</param>
        public Graph(Vertex<TVertex, TEdge> item)
        {
            Vertexs = new List<Vertex<TVertex, TEdge>>();

            Add(item);
        }

        /// <summary>
        /// Constructs a new instance of the graph with a collection of vertices.
        /// </summary>
        /// <param name="items">The vertices to be added to the graph.</param>
        public Graph(IEnumerable<Vertex<TVertex, TEdge>> items)
        {
            Vertexs = new List<Vertex<TVertex, TEdge>>();

            foreach(var item in items)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Adds a vertex to the graph.
        /// </summary>
        /// <param name="item">The vertex to be added.</param>
        /// <exception cref="ExistentVertexException">Thrown if the vertex already exists in the graph.</exception>
        public void Add(Vertex<TVertex, TEdge> item)
        {
            if (HasVertex(item.VertexName))
            {
                throw new ExistentVertexException();
            }

            AddVertex(item.VertexName);
        }

        /// <inheritdoc cref="IGraph{TVertex, TEdge}.AddEdge(TVertex, TVertex, TEdge)"/>
        public void AddEdge(TVertex v1, TVertex v2, TEdge cost)
        {
            if (HasVertex(v1, out Vertex<TVertex, TEdge> vertex) is null || HasVertex(v2, out Vertex<TVertex, TEdge> vertex2) is null)
            {
                throw new NonExistentVertexException();
            }
            var edge = new Edge<TVertex, TEdge>(vertex, vertex2, cost);
            vertex.AddEdge(edge);
            vertex2.AddEdge(edge);
        }

        /// <inheritdoc cref="IGraph{TVertex, TEdge}.AddVertex(TVertex)"/>
        public void AddVertex(TVertex vertex)
        {
            if (HasVertex(vertex))
            {
                throw new ExistentVertexException();
            }

            Vertexs.Add(new Vertex<TVertex, TEdge>(vertex));
        }

        /// <summary>
        /// Removes all vertices from the graph.
        /// </summary>
        public void Clear()
        {
            Vertexs.Clear();
        }

        /// <summary>
        /// Determines whether the graph contains a specific vertex.
        /// </summary>
        /// <param name="item">The vertex to locate in the graph.</param>
        /// <returns><see langword="true"/> if the vertex is found in the graph; otherwise, <see langword="false"/>.</returns>
        public bool Contains(Vertex<TVertex, TEdge> item)
        {
            return Vertexs.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the graph to an array, starting at a particular array index.
        /// </summary>
        /// <param name="array">The one-dimensional array that is the destination of the elements copied from the graph. The array must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(Vertex<TVertex, TEdge>[] array, int arrayIndex)
        {
            Vertexs.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the graph.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the graph.</returns>
        public IEnumerator<Vertex<TVertex, TEdge>> GetEnumerator()
        {
            return Vertexs.GetEnumerator();
        }

        /// <inheritdoc cref="IGraph{TVertex, TEdge}.HasEdge(TVertex, TVertex)"/>
        public bool HasEdge(TVertex v1, TVertex v2)
        {
            if(HasVertex(v1, out Vertex<TVertex, TEdge> vertex) is null ||
               HasVertex(v2, out Vertex<TVertex, TEdge> vertex2) is null)
            {
                return false;
            }

            return vertex.Edges.Exists(x => x.Sucessor.Equals(vertex2));
        }

        /// <summary>
        /// Searches for an edge between two vertices and returns it if found.
        /// </summary>
        /// <param name="v1">The starting vertex of the edge.</param>
        /// <param name="v2">The ending vertex of the edge.</param>
        /// <param name="edge">If found, the edge connecting the two vertices; otherwise, the default value of TEdge.</param>
        public Edge<TVertex, TEdge> HasEdge(TVertex v1, TVertex v2, out Edge<TVertex, TEdge> edge)
        {
            edge = null;
            if (HasVertex(v1, out Vertex<TVertex, TEdge> vertex) is null || 
                HasVertex(v2, out Vertex<TVertex, TEdge> vertex2) is null)
            {
                return null;
            }

            edge = vertex.Edges.Find(x => x.Sucessor.Equals(vertex2));
            return edge;
        }

        /// <summary>
        /// Searches for an edge between two vertices and returns it, along with the starting vertex, if found.
        /// </summary>
        /// <param name="v1">The starting vertex of the edge.</param>
        /// <param name="v2">The ending vertex of the edge.</param>
        /// <param name="vertex">If found, the starting vertex of the edge; otherwise, the default value of TVertex.</param>
        /// <param name="edge">If found, the edge connecting the two vertices; otherwise, the default value of TEdge.</param>
        /// <returns>The edge if it is found; otherwise, <see langword="null"/>.</returns>
        public Edge<TVertex, TEdge> HasEdge(TVertex v1, TVertex v2, out Vertex<TVertex, TEdge> vertex, out Vertex<TVertex, TEdge> vertex2, out Edge<TVertex, TEdge> edge)
        {
            edge = null;
            var v = HasVertex(v2, out vertex2);
            if (HasVertex(v1, out vertex) is null ||
                vertex2 is null)
            {
                return null;
            }

            edge = vertex.Edges.Find(x => x.Sucessor.Equals(v));
            return edge;
        }

        /// <inheritdoc cref="IGraph{TVertex, TEdge}.HasVertex(TVertex)"/>
        public bool HasVertex(TVertex vertex)
        {
            return Vertexs.Exists(x => x.VertexName.Equals(vertex));
        }

        /// <summary>
        /// Determines if the graph has a vertex with the given name.
        /// </summary>
        /// <param name="name">The name of the vertex to search for.</param>
        /// <param name="vertex">The vertex with the given name, if it exists in the graph.</param>
        /// <returns>The vertex with the given name, if it exists in the graph.</returns>
        public Vertex<TVertex, TEdge> HasVertex(TVertex name, out Vertex<TVertex, TEdge> vertex)
        {
            vertex = Vertexs.Find(x => x.VertexName.Equals(name));

            return vertex;
        }

        /// <summary>
        /// Removes a vertex from the graph.
        /// </summary>
        /// <param name="item">The vertex to remove from the graph.</param>
        /// <returns>True if the vertex was successfully removed, false otherwise.</returns>
        public bool Remove(Vertex<TVertex, TEdge> item)
        {
            return Vertexs.Remove(HasVertex(item.VertexName, out _));
        }

        /// <inheritdoc cref="IGraph{TVertex, TEdge}.RemoveEdge(TVertex, TVertex)"/>
        public bool RemoveEdge(TVertex v1, TVertex v2)
        {
            if(HasEdge(v1, v2, out Vertex<TVertex, TEdge> vertex, out Vertex<TVertex, TEdge> vertex2, out Edge <TVertex, TEdge> edge) is null)
            {
                return false;
            }

            return vertex.Edges.Remove(edge) && vertex2.Edges.Remove(edge);
        }

        /// <inheritdoc cref="IGraph{TVertex, TEdge}.RemoveVertex(TVertex)"/>
        public bool RemoveVertex(TVertex vertex)
        {
            return Vertexs.Remove(HasVertex(vertex, out _));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the graph.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the graph.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return Vertexs.GetEnumerator();

        }

        /// <summary>
        /// Returns an enumerable of vertexes that are the successors of the specified vertex in the graph.
        /// </summary>
        /// <param name="v">The vertex whose successors are to be returned.</param>
        /// <returns>An enumerable of vertexes that are the successors of the specified vertex in the graph.</returns>
        /// <exception cref="NonExistentVertexException">Thrown if the specified vertex does not exist in the graph.</exception>
        public IEnumerable<Vertex<TVertex, TEdge>> Successors(TVertex v)
        {
            if(HasVertex(v, out Vertex<TVertex, TEdge> vertex) is null)
            {
                throw new NonExistentVertexException();
            }

            return vertex.Edges.Select(x => HasVertex(x.Sucessor.VertexName, out _));
        }

        /// <summary>
        /// Returns an enumerable of vertexes that are the predecessors of the specified vertex in the graph.
        /// </summary>
        /// <param name="v">The vertex whose predecessors are to be returned.</param>
        /// <returns>An enumerable of vertexes that are the predecessors of the specified vertex in the graph.</returns>
        /// <exception cref="NonExistentVertexException">Thrown if the specified vertex does not exist in the graph.</exception>
        public IEnumerable<Vertex<TVertex, TEdge>> Predecessors(TVertex v)
        {
            if (HasVertex(v, out Vertex<TVertex, TEdge> vertex) is null)
            {
                throw new NonExistentVertexException();
            }

            return vertex.Edges.Select(x => HasVertex(x.Predecessor.VertexName, out _));
        }
    }
}
