using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Queue
{
    public interface IPriorityQueue<T> : IQueue<T>
    {
        void Enqueue(T item, int priority);
    }
}
