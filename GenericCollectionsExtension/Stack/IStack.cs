using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Stack
{
    public interface IStack<T> : ICollection<T>
    {
        int Capacity { get; }
        T Peek();
        T Pop();
    }
}
