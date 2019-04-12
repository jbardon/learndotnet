using System;

namespace SmartAdLibrary.Utils
{
    public class BusinessException : Exception
    {
        public BusinessException(string message)
        : base(message)
        {            
        }
    }
}