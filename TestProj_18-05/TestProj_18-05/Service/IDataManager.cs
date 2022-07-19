using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal interface IDataManager
    {
        bool AddSoftware(Software software);
        bool DeleteSoftware(string softName);
        List<Software> GetSoftwares();
        List<Software> SortSoftwares();
        List<Software> FindSoftwaresByName(string name);
        List<Software> FindSoftwaresByType(string type);
    }
}
