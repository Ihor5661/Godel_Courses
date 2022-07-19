using System;

namespace TestProj_18_05.Service
{
    public class PasswordValidation : Exception
    {
        public PasswordValidation() : base("Password entered incorrectly!!!")
        {
            
        }
    }
}
