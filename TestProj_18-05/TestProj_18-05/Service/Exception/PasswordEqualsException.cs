using System;

namespace TestProj_18_05.Service
{
    public class PasswordEqualsException : Exception
    {
        public PasswordEqualsException() : base("Password 1 and password 2 do not match!!!")
        {

        }
    }
}
