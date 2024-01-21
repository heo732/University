using System;

namespace MainTool.Exceptions
{
    public class FlowImpossibleException : Exception
    {
        public FlowImpossibleException(string message)
            : base(message)
        {
        }
    }
}