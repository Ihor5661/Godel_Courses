using System;

namespace TestProj_18_05.Service
{
    public class OperationNotFound : Exception
    {
        private string message;

        public OperationNotFound()
        {
            message = "Operation not found!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
