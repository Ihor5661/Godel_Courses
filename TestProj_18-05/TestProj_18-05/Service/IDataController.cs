using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal interface IDataController
    {
        bool ExistError { get; }

        bool AddSoftware(Software software);
        bool DeleteSoftware(string softName);
        List<Software> GetSoftwares();
        List<Software> SortSoftwares();
        List<Software> FindSoftwareByName(string name);
        List<Software> FindSoftwareByType(string type);
    }
}
