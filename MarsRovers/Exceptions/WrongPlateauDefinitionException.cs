using System;

namespace MarsRovers.Exceptions
{
    public class WrongPlateauDefinitionException : Exception
    {
        public WrongPlateauDefinitionException()
        {
        }

        public WrongPlateauDefinitionException(string message)
            : base(message)
        {
        }

        public WrongPlateauDefinitionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
