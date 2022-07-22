using System;

namespace TestProj_18_05.Service
{
    public class PasswordValidationException : Exception
    {
        public PasswordValidationException() : base("Password entered incorrectly!!!")
        {
            
        }
    }
}
