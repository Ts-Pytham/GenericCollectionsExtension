namespace GenericCollectionsExtension.Queue.PriorityQueue
{
    public class PriorityObject<T>
    {
        public T Value { get; set; }
        public int Priority { get; set; }

        public static bool operator >(PriorityObject<T> o, PriorityObject<T> o2)
        {
            return o.Priority > o2.Priority;
        }

        public static bool operator <(PriorityObject<T> o, PriorityObject<T> o2)
        {
            return o.Priority < o2.Priority;
        }

        public static bool operator >=(PriorityObject<T> o, PriorityObject<T> o2)
        {
            return o.Priority >= o2.Priority;
        }

        public static bool operator <=(PriorityObject<T> o, PriorityObject<T> o2)
        {
            return o.Priority <= o2.Priority;
        }

        public static bool operator ==(PriorityObject<T> o, PriorityObject<T> o2)
        {
            return o.Priority == o2.Priority;
        }

        public static bool operator !=(PriorityObject<T> o, PriorityObject<T> o2)
        {
            return o.Priority != o2.Priority;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PriorityObject<T> obj2))
            {
                return false;
            }

            return obj2.Priority == Priority;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"Value: {Value}, Priority: {Priority}";
        }
    }
}
