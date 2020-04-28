using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentStaticThresholdsParam : IInstrumentParam
    {
        long ThresholdHigh { get; }
        long ThresholdLow { get; }
    }
}
