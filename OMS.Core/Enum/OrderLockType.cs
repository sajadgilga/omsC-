using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public enum OrderLockType
    {
        UnLock = 1,
        LockForCreate = 2,
        LockForEdit = 3,
        LockForCancel = 4
    }
}
