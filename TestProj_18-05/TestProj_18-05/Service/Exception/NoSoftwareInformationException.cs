using System;

namespace TestProj_18_05.Service
{
    public class NoSoftwareInformationException : Exception
    {
        public NoSoftwareInformationException() : base("No software information!!!")
        {
           
        }
    }
}
