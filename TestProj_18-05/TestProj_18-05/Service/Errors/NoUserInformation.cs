using System;

namespace TestProj_18_05.Service
{
    public class NoUserInformation : Exception
    {
        private string message;

        public NoUserInformation()
        {
            message = "No user information!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
