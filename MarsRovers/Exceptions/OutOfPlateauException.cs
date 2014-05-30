﻿using System;

namespace MarsRovers.Exceptions
{
    public class OutOfPlateauException : Exception
    {
        public OutOfPlateauException()
        {
        }

        public OutOfPlateauException(string message)
            : base(message)
        {
        }

        public OutOfPlateauException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}