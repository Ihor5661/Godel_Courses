using System;

namespace TestProj_18_05.Service
{
    public class UserNameUnknown : Exception
    {
        private string message;

        public UserNameUnknown()
        {
            message = "This username is not logged in!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
