using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Graph
{
    public class Edge<T, U>
        where U : IComparable<U>
    {
        public T Sucessor { get; set; }

        public U Cost { get; set; }

        public Edge(T sucessor, U cost)
        {
            Sucessor = sucessor;
            Cost = cost;
        }
    }
}
