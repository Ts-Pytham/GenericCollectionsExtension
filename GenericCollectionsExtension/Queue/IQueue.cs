using System.Collections.Generic;

namespace GenericCollectionsExtension.Queue
{
    public interface IQueue<T> : ICollection<T>
    {
        int Capacity { get; }
        T Dequeue();
        T Peek();
    }
}
