using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentClosingPriceParam:IInstrumentParam
    {
        long NumberOfTrades { get; }
        long MarketVolume { get; }
        long FinalPrice { get; }
        long YesterdayFinalPrice { get; }
        long YesterdayLastTradePrice { get; }
    }
}
