using System;

namespace MarsRover.Core.Exceptions
{
    public class PositionNotValidException : Exception
    {
        public PositionNotValidException(){}

        public PositionNotValidException(string exceptionMessage)
            : base(exceptionMessage){}

        public PositionNotValidException(string exceptionMessage, Exception inner)
            : base(exceptionMessage, inner){}
    }
}