using System;

namespace TestProj_18_05.Service
{
    public class NoUserInformationException : Exception
    {
        public NoUserInformationException() : base("No user information!!!")
        {
            
        }
    }
}
