using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Graph
{
    public interface IGraph<TVertex, TEdge>
        where TEdge : IComparable<TEdge>
    {
        public void AddVertex(TVertex vertex);

        public void AddEdge(TVertex v1, TVertex v2, TEdge edge);

        public void RemoveVertex(TVertex vertex);

        public void RemoveEdge(TVertex v1, TVertex v2);

        public bool HasVertex(TVertex vertex);

        public bool HasEdge(TVertex v1, TVertex v2);

    }
}
