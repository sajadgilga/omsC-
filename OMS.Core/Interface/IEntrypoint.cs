using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public delegate void TradeSignalEventHandler(TradeSignalEventArgs e);
    public interface IEntrypoint
    {
        Task InitAsync(TradeSignalEventHandler signaler);
        Task CreationOfInstrumentCharacteristicsAsync(IInstrumentCharacteristicsParam param);
        Task InstrumentBestLimitChangeAsync(IInstrumentBestLimitsChangeParam param);
        Task InstrumentClosingPriceChangeAsync(IInstrumentClosingPriceParam param);
        Task InstrumentTradeAsync(IInstrumentTradeParam param);
        Task InstrumentStateChangeAsync(IInstrumentStateChangeParam param);
        Task InstrumentStaticThresholdsAsync(IInstrumentStaticThresholdsParam param);
        Task InstrumentMarketTradePercentChageAsync(IInstrumentMarketTradePercentParam param);
        Task OverallStatisticsChangeAsync(IOverallStatisticsParam param);
        Task StartOfDayAsync(IOverallStatisticsParam param);
        Task InstrumentEPSDataChangeAsync(IInstrumentEPSDataParam param);
    }
}
