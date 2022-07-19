using System;

namespace TestProj_18_05.Service
{
    public class InvalidInputFormat : Exception
    {
        private string message;

        public InvalidInputFormat()
        {
            message = "Invalid input format!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
