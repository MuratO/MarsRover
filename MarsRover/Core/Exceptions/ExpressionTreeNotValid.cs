using System;

namespace MarsRover.Core.Exceptions
{
    public class ExpressionTreeNotValid : Exception
    {
        public ExpressionTreeNotValid(){}

        public ExpressionTreeNotValid(string exceptionMessage)
            : base(exceptionMessage){}

        public ExpressionTreeNotValid(string exceptionMessage, Exception inner)
            : base(exceptionMessage, inner){}
    }
}