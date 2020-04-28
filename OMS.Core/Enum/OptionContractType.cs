using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public enum OptionContractType:byte
    {
        /// <summary>
        /// قرارداد اختیار خرید
        /// </summary>
        CallOption=1,
        /// <summary>
        /// قرارداد اختیار فروش
        /// </summary>
        PutOption=2
    }
}
