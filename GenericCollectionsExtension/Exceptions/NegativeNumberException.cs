using System;

namespace GenericCollectionsExtension.Exceptions
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException()
            :base("The value cannot be negative!") 
        {
        }

        public NegativeNumberException(string message) 
            : base(message) { }

    }
}
