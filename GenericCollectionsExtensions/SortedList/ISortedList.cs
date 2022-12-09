using System.Collections.Generic;

namespace GenericCollectionsExtension.SortedList
{
    public interface ISortedList<T> : ICollection<T>, IEnumerable<T>
    {
        T this[int index] { get; set; }

        int IndexOf(T item);

        void RemoveAt(int index);
    }
}
