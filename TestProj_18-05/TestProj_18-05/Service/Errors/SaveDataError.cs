using System;

namespace TestProj_18_05.Service
{
    public class SaveDataError : Exception
    {
        private string message;

        public SaveDataError()
        {
            message = "User data could be saved!!! \nSystem error!!!";
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
