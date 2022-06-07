using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal interface IDataController : IConnector, IUserConnector
    {
        void AddSoftware(Software software);
        List<Software> GetSoftwares();
        Software FindSoftwareByName(string name);
        Software FindSoftwareByType(string type);
    }
}
