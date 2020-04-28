using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentStateChangeParam:IInstrumentParam
    {
        string State { get;  }
        string NSCState { get;  }
    }
}
