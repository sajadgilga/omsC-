using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentTradeParam:IInstrumentParam
    {
        long HighestPrice { get;  }
        long LowestPrice { get;  }
        long LastTradePrice { get;  }
        DateTime LastTradeDate { get;  }
        long FirstPrice { get;  }
    }
}
