using System;

namespace MarsRovers.Exceptions
{
    public class WrongRoverDefinitionException : Exception
    {
        public WrongRoverDefinitionException()
        {
        }

        public WrongRoverDefinitionException(string message)
            : base(message)
        {
        }

        public WrongRoverDefinitionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
