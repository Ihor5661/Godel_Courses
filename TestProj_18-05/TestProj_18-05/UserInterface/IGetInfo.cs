using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.UserInterface
{
    internal interface IGetInfo
    {
        string GetInfo(string message);
        Software GetSoftware();
        User GetUserData();
    }
}
