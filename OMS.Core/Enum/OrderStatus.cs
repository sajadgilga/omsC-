using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public enum OrderStatus : byte
    {
        Created = 1,
        Active = 2,
        Executed = 3,
        Canceled = 4,
        Error = 5,
        PartialExecuted = 6
    }
}
