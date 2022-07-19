using System;

namespace TestProj_18_05.Service
{
    public class UserNameToken : Exception
    {
        private string message;

        public UserNameToken()
        {
            message = "This username is already registered!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
