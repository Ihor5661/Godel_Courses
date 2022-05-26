using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal interface IErrorCatcher
    {
        void Error(string message);
        void Error(int NumberError);
    }
}
