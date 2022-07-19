using System;

namespace TestProj_18_05.Service
{
    public class NotFoundSoftName : Exception
    {
        private string message;

        public NotFoundSoftName()
        {
            message = "Software with this name was not found!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
