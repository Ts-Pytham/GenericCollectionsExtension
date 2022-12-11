using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Tree
{
    public interface IBinarySearchTree<T> : ICollection<T>
    {
        TraversalType Traversal { get; set; }
        bool IsEmpty();
    }
}
