using System;

namespace TestProj_18_05.Service
{
    public class OperationNotFoundException : Exception
    {
        public OperationNotFoundException() : base("Operation not found!!!")
        {

        }
    }
}
