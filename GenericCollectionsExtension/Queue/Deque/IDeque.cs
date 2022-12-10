using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Queue
{
    public interface IDeque<T> : IQueue<T>
    {
        void PushFirst(T item);
        void PushLast(T item);
        T PopLast();
        T PeekLast();
    }
}
