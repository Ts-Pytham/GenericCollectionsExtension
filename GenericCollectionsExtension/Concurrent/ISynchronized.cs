namespace GenericCollectionsExtension.Concurrent
{
    public interface ISynchronized<T>
    {

        /// <summary>
        /// 
        /// </summary>
        T Synchronize();

        /// <summary>
        /// Gets a value indicating whether access to the data structure is synchronized (thread-safe).
        /// </summary>
        bool IsSynchronized { get; }

        /// <summary>
        /// 
        /// </summary>
        object SyncRoot { get; }

    }
}
