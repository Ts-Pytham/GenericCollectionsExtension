using System.Collections.Generic;

namespace GenericCollectionsExtension.List
{
    public interface IDoublyLinkedList<T> : ICollection<T>, IEnumerable<T>
    {

        T this[int index] { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void AddLast(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        int Find(T item);

        /// <summary>
        /// 
        /// </summary>
        T GetLast();

        /// <summary>
        /// 
        /// </summary>
        T GetFirst();
    }
}
