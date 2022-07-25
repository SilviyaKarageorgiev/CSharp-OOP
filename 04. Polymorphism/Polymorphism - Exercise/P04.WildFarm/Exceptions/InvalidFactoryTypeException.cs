using System;

namespace P04.WildFarm.Exceptions
{
    public class InvalidFactoryTypeException : Exception
    {
        private const string DefaultMessage = "InvalidType!";

        public InvalidFactoryTypeException()
            : base(DefaultMessage)
        {

        }

        public InvalidFactoryTypeException(string message)
            : base(message)
        {

        }
    }
}
