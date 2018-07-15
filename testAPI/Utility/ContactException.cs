using System;

namespace testAPI.Utility
{
    public class ContactException : Exception
    {
        public ContactException(string message)
            : base(message)
        {
        }
    }
}