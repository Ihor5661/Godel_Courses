using System;

namespace TestProj_18_05.Service
{
    public class UserNameException : Exception
    {
        public UserNameException() : base("This username is already registered!!!")
        {

        }
    }
}
