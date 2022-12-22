using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollectionsExtension.List
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>, IEnumerable<T>, ICollection<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public T this[int index] 
        {
            get => Loop(index);
            set => SetValue(index, value); 
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count { get; private set; }

        public bool IsReadOnly => false;

        /// <summary>
        /// 
        /// </summary>
        public DoublyLinkedList()
        {
            Count = 0;
            _head = null;
            _tail = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public DoublyLinkedList(T item)
        {
            Count = 0;
            _head = null;
            _tail = null;
            Add(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        public DoublyLinkedList(IEnumerable<T> values)
        {
            foreach(var value in values)
            {
                Add(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if(_head is null)
            {
                _head = new Node<T>(item);
                _tail = _head;
            }
            else
            {
                var newNode = new Node<T>(item)
                {
                    Next = _head
                };
                _head.Previous = newNode;
                _head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            if (_head is null)
            {
                _head = new Node<T>(item);
                _tail = _head;
            }
            else
            {
                var newNode = new Node<T>(item);
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }
            Count++;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item)
        {
            return Find(item) != -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            GetEnumerable().ToArray().CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int Find(T item)
        {
            if (_head is null) return -1;

            if (_head.Value.Equals(item)) return 0;

            if (_tail.Value.Equals(item)) return Count - 1;

            var aux = _head;

            for (int i = 1; i != Count - 1; ++i)
            {
                if (aux.Value.Equals(item))
                {
                    return i;
                }
                aux = aux.Next;
            }

            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            if (_head is null) yield break;
            var aux = _head;
            for (int i = 0; i != Count; ++i)
            {
                yield return aux.Value;

                aux = aux.Next;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetEnumerable()
        {
            if (_head is null) yield break;

            var aux = _head;
            for (int i = 0; i != Count; ++i)
            {
                yield return aux.Value;

                aux = aux.Next;
            }
        }

        public T GetFirst()
        {
            if (_head is null) return default;

            return _head.Value;
        }

        public T GetLast()
        {
            if (_tail is null) return default;

            return _tail.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if(_head is null) return false;

            if (_head.Value.Equals(item))
            {
                _head = _head.Next;
                _head.Previous = null;
                Count--;
                return true;
            }
            else if (_tail.Value.Equals(item))
            {
                _tail = _tail.Previous;
                _tail.Next = null;
                Count--;
                return true;
            }
            else
            {
                var aux1 = _head;
                var aux2 = _tail;
                var deleted = false;
                while (aux1 is not null && aux2 is not null)
                {

                    if (aux1.Value.Equals(item))
                    {
                        aux1.Next.Previous = aux1.Previous;
                        aux1.Previous.Next = aux1.Next;
                        Count--;
                        deleted = true;
                    }
                    else if (aux2.Value.Equals(item))
                    {
                        aux2.Next.Previous = aux2.Previous;
                        aux2.Previous.Next = aux2.Next;
                        Count--;
                        deleted = true;
                    }
                    aux1 = aux1.Next;
                    aux2 = aux2.Previous;
                }
                return deleted;
            }
  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        private T Loop(int index)
        {
            if(index > Count || index < 0) throw new IndexOutOfRangeException();

            if (index == 0) return _head.Value;

            if (index == Count - 1) return _tail.Value;

            var aux = _head.Next;

            for(int i = 1; i != Count - 1; ++i)
            {
                if(index == i)
                {
                    return aux.Value;
                }
                aux = aux.Next;
            }

            return default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        private void SetValue(int index, T value)
        {
            if (index > Count || index < 0) throw new IndexOutOfRangeException();

            if (index == 0) _head.Value = value;

            if (index == Count - 1) _tail.Value = value;

            var aux = _head;

            for (int i = 1; i != Count - 1; ++i)
            {
                if (index == i)
                {
                    aux.Value = value;
                    return;
                }
                aux = aux.Next;
            }
        }
    }
}
