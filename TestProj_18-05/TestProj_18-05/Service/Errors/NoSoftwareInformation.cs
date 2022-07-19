using System;

namespace TestProj_18_05.Service
{
    public class NoSoftwareInformation : Exception
    {
        private string message;

        public NoSoftwareInformation()
        {
            message = "No software information!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
