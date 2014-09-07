using System;

namespace MarsRover.Core.Exceptions
{
    public class InputNotValidException : Exception
    {
        public InputNotValidException(){}

        public InputNotValidException(string exceptionMessage)
            : base(exceptionMessage){}

        public InputNotValidException(string exceptionMessage, Exception inner)
            : base(exceptionMessage, inner){}
    }
}