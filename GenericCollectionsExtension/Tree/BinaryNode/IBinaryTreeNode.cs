using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Tree
{
    internal interface IBinaryTreeNode<T>
    {
        IBinaryTreeNode<T> LeftChild { get; set; }
        IBinaryTreeNode<T> RightChild { get; set; }
        IBinaryTreeNode<T> Parent { get; set; }
        T Data { get; set; }
    }
}
