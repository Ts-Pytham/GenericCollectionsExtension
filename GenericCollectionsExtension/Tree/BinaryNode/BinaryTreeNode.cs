using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Tree
{
    internal class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public IBinaryTreeNode<T> LeftChild { get; set; }
        public IBinaryTreeNode<T> RightChild { get; set; }
        public IBinaryTreeNode<T> Parent { get; set; }
        public T Data { get; set; }

        public BinaryTreeNode(T data)
        {
            Data = data;
            LeftChild = null;
            RightChild = null;
            Parent = null;
        }

        public BinaryTreeNode(T data, IBinaryTreeNode<T> parent)
        {
            Data = data;
            LeftChild = null;
            RightChild = null;
            Parent = parent;
        }
    }
}
