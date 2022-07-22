using System;

namespace TestProj_18_05.Service
{
    public class SaveDataException : Exception
    {
        public SaveDataException() : base("User data could be saved!!! \nSystem error!!!")
        {
            
        }
    }
}
