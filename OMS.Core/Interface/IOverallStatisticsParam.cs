using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IOverallStatisticsParam
    {
        decimal TotalTradePrice { get; }
        decimal TotalTradeQuantity { get; }
        decimal TotalTradeCount { get;  }
        decimal OverallIndex { get; }
        decimal OverallIndexPercent { get; }
        int CowFactor { get;  }
    }
}
