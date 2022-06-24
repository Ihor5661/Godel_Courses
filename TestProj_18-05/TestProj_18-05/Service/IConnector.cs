using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal interface IConnector
    {
        bool Connect(string host, string port);
        bool Disconnect(string host, string port);

        User Connect(string userName);
        bool Disconnect();
        bool SaveChanges(User user);
    }
}
