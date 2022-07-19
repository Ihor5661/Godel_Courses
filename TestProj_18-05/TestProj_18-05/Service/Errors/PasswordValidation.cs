using System;

namespace TestProj_18_05.Service
{
    public class PasswordValidation : Exception
    {
        private string message;

        public PasswordValidation()
        {
            message = "Password entered incorrectly!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
