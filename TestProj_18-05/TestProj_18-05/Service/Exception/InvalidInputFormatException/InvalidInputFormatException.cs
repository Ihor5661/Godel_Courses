using System;

namespace TestProj_18_05.Service
{
    public class InvalidInputFormatException : Exception
    {
        public InvalidInputFormatException() : base("Invalid input format!!!")
        {

        }
        public InvalidInputFormatException(string message) : base(message)
        {

        }
    }
}
