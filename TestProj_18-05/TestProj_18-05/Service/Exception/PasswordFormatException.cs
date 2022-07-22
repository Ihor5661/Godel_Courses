using System;

namespace TestProj_18_05.Service
{
    public class PasswordFormatException : Exception
    {
        public PasswordFormatException() : base("Password format is invalid!!!")
        {

        }
    }
}
