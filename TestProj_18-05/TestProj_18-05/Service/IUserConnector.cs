using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal interface IUserConnector : IConnector
    {
        void SignIn(string username, string password);
        void SignUp(string username, string password);
    }
}
