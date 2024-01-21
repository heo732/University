using System;

namespace MainTool.Exceptions
{
    public class InvalidDataException : Exception
    {
        public InvalidDataException(string message)
            : base(message)
        {
        }
    }
}