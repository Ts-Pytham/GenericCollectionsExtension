using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Graph
{
    public class Edge<T, U>
        where U : IComparable<U>
    {
        public T Suceessor { get; set; }

        public U Cost { get; set; }

        public Edge(T suceessor, U cost)
        {
            Suceessor = suceessor;
            Cost = cost;
        }
    }
}
