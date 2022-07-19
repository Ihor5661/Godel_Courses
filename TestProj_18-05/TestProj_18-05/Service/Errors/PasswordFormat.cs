using System;

namespace TestProj_18_05.Service
{
    public class PasswordFormat : Exception
    {
        private string message;

        public PasswordFormat()
        {
            message = "Password format is invalid!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
