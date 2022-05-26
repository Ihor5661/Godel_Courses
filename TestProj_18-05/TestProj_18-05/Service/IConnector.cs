using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal interface IConnector
    {
        void Connect(string host, string port);
        void Disconnect(string host, string port);
    }
}
