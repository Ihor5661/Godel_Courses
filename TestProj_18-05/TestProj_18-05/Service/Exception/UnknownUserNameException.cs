using System;

namespace TestProj_18_05.Service
{
    public class UnknownUserNameException : Exception
    {
        public UnknownUserNameException() : base("This username is not logged in!!!")
        {
            
        }
    }
}
