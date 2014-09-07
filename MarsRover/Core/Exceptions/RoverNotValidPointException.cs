using System;

namespace MarsRover.Core.Exceptions
{
    public class RoverNotValidPointException : Exception
    {
        public RoverNotValidPointException(){}

        public RoverNotValidPointException(string exceptionMessage)
            : base(exceptionMessage){}

        public RoverNotValidPointException(string exceptionMessage, Exception inner)
            : base(exceptionMessage, inner){}
    }
}