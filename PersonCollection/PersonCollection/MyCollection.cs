using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCollection
{
    interface IMyCollection<T> : ICollection<T>, IEnumerator<T>, IEnumerator
    {

    }
}
