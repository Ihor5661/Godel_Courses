using System;

namespace TestProj_18_05.Service
{
    public class NotFoundSoftNameException : Exception
    {
        public NotFoundSoftNameException() : base("Software with this name was not found!!!")
        {
            
        }
    }
}
