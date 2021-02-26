using System;

namespace Sbt.Test.Refactoring.Exceptions
{
    public class PlaceIsNotEmptyException : Exception
    {
        public PlaceIsNotEmptyException(string message) : base(message)
        {
        }
        public PlaceIsNotEmptyException() : base()
        {
        }
    }
}
