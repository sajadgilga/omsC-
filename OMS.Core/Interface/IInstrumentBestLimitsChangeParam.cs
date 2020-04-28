using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentBestLimitsChangeParam:IInstrumentParam
    {
        string Flags { get; set; }
        /// <summary>
        /// اولین عرضه و تقاضای 
        /// </summary>
        InstrumentBestLimit BestLimitFirst { get; }
        /// <summary>
        /// دومین عرضه و تقاضای 
        /// </summary>
        InstrumentBestLimit BestLimitSecond { get; }
        /// <summary>
        /// سومین عرضه و تقاضای 
        /// </summary>
        InstrumentBestLimit BestLimitThird { get; }
        /// <summary>
        /// چهارمین عرضه و تقاضای 
        /// </summary>
        InstrumentBestLimit BestLimitFourth { get; }
        /// <summary>
        /// پنجمین عرضه و تقاضای 
        /// </summary>
        InstrumentBestLimit BestLimitFifth { get;  }
    }
}
