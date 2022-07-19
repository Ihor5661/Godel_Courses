using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj_18_05.Service
{
    internal class SoftwareComparer : IComparer<Software>
    {
        public int Compare(Software x, Software y)
        {
            return string.Compare(x.SoftwareName, y.SoftwareName);
        }
    }
}
