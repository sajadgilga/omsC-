using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OMS.Business.Client
{
    public class MarketWatch : MarketWatchBase
    {
        public MarketWatch(JToken data) : base(data)
        {
            Instruments = Instrument.LoadMarketWatchItems(data[2]);
        }

        public Dictionary<string, Instrument> Instruments { get; private set; }
    }
}
