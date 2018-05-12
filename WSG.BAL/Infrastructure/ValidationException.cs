using System;

namespace WSG.BAL.Infrastructure
{
    public class ValidationException : Exception
    {
        public string Property { get; set; }
        public ValidationException(string message, string prop)
            :base(message)
        {
            Property = prop;
        }
    }
}
