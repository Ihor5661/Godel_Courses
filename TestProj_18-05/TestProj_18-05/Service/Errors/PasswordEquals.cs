using System;

namespace TestProj_18_05.Service
{
    public class PasswordEquals : Exception
    {
        private string message;

        public PasswordEquals()
        {
            message = "Password 1 and password 2 do not match!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
