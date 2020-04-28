using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public enum PositionType:byte
    {
        /// <summary>
        /// تنظیم نشده
        /// </summary>
        UnNone=1,
        /// <summary>
        /// موقعیت خرید
        /// </summary>
        Long=2,
        /// <summary>
        /// موقعیت فروش
        /// </summary>
        Short=3
    }
}
