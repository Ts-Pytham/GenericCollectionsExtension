﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionsExtension.Tree
{
    /// <summary>
    /// Represents the nodes of a binary tree.
    /// </summary>
    /// <typeparam name="T">T is generic.</typeparam>
    internal interface IBinaryTreeNode<T>
    {
        /// <summary>
        /// Sub tree of left child node
        /// </summary>
        IBinaryTreeNode<T> LeftChild { get; set; }
        /// <summary>
        /// Sub tree of right child node.
        /// </summary>
        IBinaryTreeNode<T> RightChild { get; set; }
        /// <summary>
        /// Node parent.
        /// </summary>
        IBinaryTreeNode<T> Parent { get; set; }
        /// <summary>
        /// Tree node information.
        /// </summary>
        T Data { get; set; }
    }
}
