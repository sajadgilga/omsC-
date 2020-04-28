using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentMarketTradePercentParam:IInstrumentParam
    {
        long ActualBuyCount { get; }
        long ActualBuyQuantity { get; }
        long ActualSellCount { get; }
        long ActualSellQuantity { get; }
        long LegalBuyCount { get; }
        long LegalBuyQuantity { get; }
        long LegalSellCount { get; }
        long LegalSellQuantity { get; }
    }
}
