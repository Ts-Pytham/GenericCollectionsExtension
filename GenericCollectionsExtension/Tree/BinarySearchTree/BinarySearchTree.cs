using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionsExtension.Tree.BinarySearchTree
{
    public class BinarySearchTree<T> : IBinarySearchTree<T>, IEnumerable<T>
        where T : IComparable<T>
    {
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        private IBinaryTreeNode<T> _root;

        public TraversalType Traversal { get; set; }

        public Dictionary<T, int> RepeatedNodes { get; private set; }

        public BinarySearchTree()
        {
            RepeatedNodes= new Dictionary<T, int>();
        }

        public void Add(T item)
        {
            if(_root is null)
            {
                _root = new BinaryTreeNode<T>(item);
            }
            else
            {
                Add(item, _root);
            }
            Count++;
        }

        private void Add(T item, IBinaryTreeNode<T> root)
        {
            if(item.CompareTo(root.Data) > 0) // Item Greater than root.Data
            {
                if(root.RightChild is null)
                {
                    root.RightChild = new BinaryTreeNode<T>(item, root);
                }
                else
                {
                    Add(item, root.RightChild);
                }
            }
            else if(item.CompareTo(root.Data) < 0) // Item less than root.Data
            {
                if(root.LeftChild is null)
                {
                    root.LeftChild = new BinaryTreeNode<T>(item, root);
                }
                else
                {
                    Add(item, root.LeftChild);
                }
            }
            else //Repeated Value
            {
                if (RepeatedNodes.Keys.Contains(item))
                {
                    RepeatedNodes[item]++; 
                }
                else
                {
                    RepeatedNodes.Add(item, 1);
                }
            }
        }

        public void Clear()
        {
            _root = null;
        }

        public bool Contains(T item)
        {
            return Search(_root, item) is not null;
        }

        //DFS method
        private IBinaryTreeNode<T> Search(IBinaryTreeNode<T> r, T item)
        {
            if(_root is null)
            {
                return null;
            }

            if(r.Data.CompareTo(item) == 0)
            {
                return r;
            }
            else if(r.Data.CompareTo(item) > 0) // root.Data Greater than item
            {
                if(r.LeftChild is null)
                {
                    return null;
                }
                else
                {
                    return Search(r.LeftChild, item);
                }
            }
            else
            {
                if (r.RightChild is null)
                {
                    return null;
                }
                else
                {
                   return Search(r.RightChild, item);
                }
            }

        }

        public bool Remove(T item)
        {
            var node = Search(_root, item);

            if (node is null)
            {
                return false;
            }

            var parent = node.Parent;

            if (node.LeftChild is null && node.RightChild is null) //Node is a leaf
            {
                if(parent is null) // Root does not parent!
                {
                    _root = null;
                }
                if(parent.LeftChild == node)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }
            }
            else if(node.LeftChild is null || node.RightChild is null) // At least one subtree is null
            {
                if (parent is null) // Is a root
                {
                    _root = node.LeftChild is not null ? node.LeftChild : node.RightChild;
                }
                else
                {
                    if (node.LeftChild is not null && parent.LeftChild == node)
                    {
                        parent.LeftChild = node.LeftChild;
                    }
                    else if (node.RightChild is not null && parent.LeftChild == node)
                    {
                        parent.LeftChild = node.RightChild;
                    }
                    else if (node.LeftChild is not null && parent.RightChild == node)
                    {
                        parent.RightChild = node.LeftChild;
                    }
                    else
                    {
                        parent.RightChild = node.RightChild;
                    }
                }
            }
            else // Probably has two sub-trees
            {
                var inorder = InOrder().ToList();
                var toReplace = inorder[inorder.IndexOf(item) + 1];
                var nodeToReplace = Search(node, toReplace);

                if (nodeToReplace.RightChild is not null) // two cases: because the node to be replaced has more information and is the one following the node to be deleted.
                {
                    node.RightChild = nodeToReplace.RightChild;
                }
                else // The node to replace is a leaf
                {
                    Remove(toReplace);
                    Count++;
                }
                node.Data = nodeToReplace.Data;
                if (parent is not null) // If parent is null, the sub-tree is root
                {
                    if (parent.RightChild == node)
                    {
                        parent.RightChild = node;
                    }
                    else
                    {
                        parent.LeftChild = node;
                    }
                }

            }

            Count--;

            return true;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            GetEnumerable().ToArray().CopyTo(array, arrayIndex);
        }

        public bool IsEmpty()
        {
            return _root is null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetEnumerable().GetEnumerator();
        }


        public IEnumerable<T> GetEnumerable()
        {
            if (Traversal == TraversalType.PreOrder)
            {
                return PreOrder();
            }
            else if (Traversal == TraversalType.InOrder)
            {
                return InOrder();
            }

            return PostOrder();
        }

        public IEnumerable<T> InOrder()
        {
            if(_root is not null)
            {
                return InOrder(_root);
            }

            return Enumerable.Empty<T>();
        }

        private IEnumerable<T> InOrder(IBinaryTreeNode<T> r)
        {
            if (r is not null)
            {
                return InOrder(r.LeftChild).Append(r.Data)
                                           .Union(InOrder(r.RightChild));
                                                 
            }

            return Enumerable.Empty<T>();
        }

        public IEnumerable<T> PreOrder()
        {
            if (_root is not null)
            {
                return PreOrder(_root);
            }

            return Enumerable.Empty<T>();
        }

        private IEnumerable<T> PreOrder(IBinaryTreeNode<T> r)
        {
            if (r is not null)
            {
                List<T> list = new() { r.Data };
                return list.Union(PreOrder(r.LeftChild)).Union(PreOrder(r.RightChild));
            }

            return Enumerable.Empty<T>();
        }


        public IEnumerable<T> PostOrder()
        {
            if (_root is not null)
            {
                return PostOrder(_root);
            }

            return Enumerable.Empty<T>();
        }

        private IEnumerable<T> PostOrder(IBinaryTreeNode<T> r)
        {
            if (r is not null)
            {
                return PostOrder(r.LeftChild).Union(PostOrder(r.RightChild))
                                             .Append(r.Data);

            }

            return Enumerable.Empty<T>();
        }
    }
}
