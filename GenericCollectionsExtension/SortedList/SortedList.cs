using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericCollectionsExtension.SortedList
{
    /// <summary>
    /// Represents a sorted list each time you enter an item in the list.
    /// </summary>
    /// <typeparam name="T">T is type of element in the list and implements <see cref="IComparable{T}"/>.</typeparam>
    public class SortedList<T> : ISortedList<T>, ICollection<T>, IEnumerable<T>, IReadOnlyList<T>
        where T : IComparable<T>
    {
        private readonly List<T> _sortedList;

        /// <summary>
        /// Criterion for sorting the list.
        /// </summary>
        private readonly Criterion _criterion;

        /// <inheritdoc/>
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

                if(value.CompareTo(_sortedList[index]) == 0)
                {
                    return;
                }

                if(index == 0)
                {
                    if (value.CompareTo(this[1]) <= 0 && _criterion == Criterion.Ascending)
                    {
                        _sortedList[index] = value;
                    }
                    else if (value.CompareTo(this[1]) >= 0 && _criterion == Criterion.Descending)
                    {
                        _sortedList[index] = value;
                    }
                    else
                    {
                        _sortedList.RemoveAt(index);
                        Add(value);
                    }
                }
                else if(index == Count - 1)
                {
                    if (value.CompareTo(this[Count - 2]) >= 0 && _criterion == Criterion.Ascending)
                    {
                        _sortedList[index] = value;
                    }
                    else if (value.CompareTo(this[Count - 2]) <= 0 && _criterion == Criterion.Descending)
                    {
                        _sortedList[index] = value;
                    }
                    else
                    {
                        _sortedList.RemoveAt(index);
                        Add(value);
                    }
                }
                else
                {
                    if (value.CompareTo(this[index-1]) >= 0 && value.CompareTo(this[index+1]) <= 0 && _criterion == Criterion.Ascending)
                    {
                        _sortedList[index] = value;
                    }
                    else if (value.CompareTo(this[index - 1]) <= 0 && value.CompareTo(this[index + 1]) >= 0 && _criterion == Criterion.Descending)
                    {
                        _sortedList[index] = value;
                    }
                    else
                    {
                        _sortedList.RemoveAt(index);
                        Add(value);
                    }
                }
                
            }
        }

        /// <inheritdoc/>
        public int Count
        {
            get => _sortedList.Count;
        }

        /// <inheritdoc/>
        public bool IsReadOnly => false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SortedList{T}"/> class and initialize the criterion to ascending by default.
        /// </summary>
        public SortedList()
        {
            _sortedList = new List<T>();
            _criterion = Criterion.Ascending;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SortedList{T}"/> class and initializes the criterion.
        /// </summary>
        /// <param name="criterion">Can be ascending or descending.</param>
        public SortedList(Criterion criterion)
        {
            _sortedList = new List<T>();
            _criterion = criterion;
        }

        /// <inheritdoc/>
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
        /// <param name="item">The object to be added</param>
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

        /// <inheritdoc/>
        public void Clear()
        {
            _sortedList.Clear();
        }

        /// <inheritdoc/>
        public bool Contains(T item)
        {
            return _sortedList.Contains(item);
        }

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _sortedList.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return _sortedList.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _sortedList.GetEnumerator();
        }

        /// <inheritdoc/>
        public int IndexOf(T item)
        {
            return _sortedList.IndexOf(item);
        }

        /// <summary>
        /// Performs a binary search on a sorted list to find a specific element.
        /// </summary>
        /// <param name="item">The element to search for in the list.</param>
        /// <returns>The index of the element in the list if found, or -1 if not found.</returns>
        public int BinarySearch(T item)
        {
            int low = 0;
            int high = _sortedList.Count - 1;

            while(low <= high)
            {
                int mid = low + (high - low) / 2;

                if(item.CompareTo(_sortedList[mid]) == 0)
                {
                    return mid;
                }
                else if (item.CompareTo(_sortedList[mid]) < 0)
                {
                    if(_criterion == Criterion.Ascending)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                else
                {
                    if (_criterion == Criterion.Ascending)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            return -1;
        }

        /// <inheritdoc/>
        public bool Remove(T item)
        {
            return _sortedList.Remove(item);
        }

        /// <inheritdoc/>
        public void RemoveAt(int index)
        {
            _sortedList.RemoveAt(index);
        }


    }
}