using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public enum OrderSource
    {
        Web = 1,
        Notification = 2,
        Algorithmic = 3,
        API = 4,
        Admin = 5,
        InitialOffering = 6,
        Backoffice = 7,
        Old = 8
    }
}
