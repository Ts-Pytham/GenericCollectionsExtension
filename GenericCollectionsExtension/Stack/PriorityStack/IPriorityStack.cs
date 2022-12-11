using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Stack
{
    public interface IPriorityStack<T> : IStack<T>
    {
        void Push(T item, int priority);
    }
}
