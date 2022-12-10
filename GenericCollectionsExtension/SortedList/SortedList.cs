using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollectionsExtension.SortedList
{
    /// <summary>
    /// Represents a sorted list each time you enter an item in the list.
    /// </summary>
    /// <typeparam name="T">T is type of element in the list and implements IComparable.</typeparam>
    public class SortedList<T> : ISortedList<T>, ICollection<T>, IEnumerable<T>, IReadOnlyList<T>
        where T : IComparable<T>
    {
        private readonly List<T> _sortedList;

        /// <summary>
        /// Criterion for sorting the list.
        /// </summary>
        private readonly Criterion _criterion;

        public T this[int index] 
        {
            get
            {
                if(index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return _sortedList[index];
            }
            set 
            {
                if (index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _sortedList[index] = value; 
            }
        }

        public int Count
        {
            get => _sortedList.Count;
        }

        public bool IsReadOnly => false;

        /// <summary>
        /// Initializes a new instance of the SortedList class and initialize the criterion to ascending by default.
        /// </summary>
        public SortedList()
        {
            _sortedList = new List<T>();
            _criterion = Criterion.Ascending;
        }

        /// <summary>
        /// Initializes a new instance of the SortedList class and initializes the criterion.
        /// </summary>
        /// <param name="criterion">Can be ascending or descending.</param>
        public SortedList(Criterion criterion)
        {
            _sortedList = new List<T>();
            _criterion = criterion;
        }


        public void Add(T item)
        {
            if (Count == 0)
            {
                _sortedList.Add(item);
            }
            else
            {
                AddSorted(item);
            }
        }
        /// <summary>
        /// Adds an item and sorts it.
        /// </summary>
        /// <param name="item"></param>
        private void AddSorted(T item)
        {
            if (_criterion == Criterion.Ascending)
            {
                if (item.CompareTo(_sortedList[0]) == -1) // Initial Position
                {
                    _sortedList.Insert(0, item);
                }
                else if (item.CompareTo(_sortedList[Count - 1]) >= 0) // Last Position
                {
                    _sortedList.Insert(Count, item);
                }
                else
                {
                    for (int index = 1; index != Count; index++)
                    {
                        if (item.CompareTo(_sortedList[index]) == -1)
                        {
                            _sortedList.Insert(index, item);
                            return;
                        }
                    }

                }
            }
            else
            {
                if (item.CompareTo(_sortedList[0]) >= 0) // Initial Position
                {
                    _sortedList.Insert(0, item);
                }
                else if (item.CompareTo(_sortedList[Count - 1]) == -1) // Last Position
                {
                    _sortedList.Insert(Count, item);
                }
                else
                {
                    for (int index = 1; index != Count; index++)
                    {
                        if (item.CompareTo(_sortedList[index]) >= 0)
                        {
                            _sortedList.Insert(index, item);
                            return;
                        }
                    }

                }
            }
        }

        public void Clear()
        {
            _sortedList.Clear();
        }

        public bool Contains(T item)
        {
            return _sortedList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _sortedList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _sortedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _sortedList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _sortedList.IndexOf(item);
        }

        public bool Remove(T item)
        {
            return _sortedList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _sortedList.RemoveAt(index);
        }
    }
}