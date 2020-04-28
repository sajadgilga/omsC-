using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public enum OrderValidity : byte
    {
        Day = 1,
        GoodTillCancelled = 2,
        GoodTillDate = 3,
        FillAndKill=4
    }
}
