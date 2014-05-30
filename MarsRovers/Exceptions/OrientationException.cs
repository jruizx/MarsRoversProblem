using System;

namespace MarsRovers.Exceptions
{
    public class OrientationException : Exception
    {
        public OrientationException()
        {
        }

        public OrientationException(string message)
            : base(message)
        {
        }

        public OrientationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
