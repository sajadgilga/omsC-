using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentEPSDataParam:IInstrumentParam
    {
        decimal SectorPE { get; set; }
        decimal EstimatedEPS { get; set; }
    }
}
