using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace OMS.Business.Client
{
    public class MarketDataClient : SignalRClientProxyBase
    {
        public Dictionary<string, Instrument> Instruments { get; set; }
        public static MarketDataClient Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new MarketDataClient();
                }
                return _current;
            }
        }

        private MarketDataClient() : base(ConfigurationManager.AppSettings["rlc.url"], ConfigurationManager.AppSettings["rlc.hub"], "Rlc Client Hub", true, null)
        {

        }

        public override void InitHub(IHubProxy _hub)
        {
            _hub.On<JToken>("CreationOfInstrumentCharacteristics", param => CreationOfInstrumentCharacteristics(param));
            _hub.On<JToken>("MarketMessage", param => MarketMessage(param));
            _hub.On<JArray>("InstrumentBestLimitChange", param => InstrumentBestLimitChange(param));
            _hub.On<JToken>("InstrumentTrade", param => InstrumentTrade(param));
            _hub.On<JToken>("InstrumentStateChange", param => InstrumentStateChange(param));
            _hub.On<JToken>("InstrumentStaticThresholdsChange", param => InstrumentStaticThresholdsChange(param));
            _hub.On<JToken>("InstrumentClosingPriceChange", param => InstrumentClosingPriceChange(param));
            _hub.On<JToken>("InstrumentMarketTradePercentChange", param => InstrumentMarketTradePercentChange(param));
            _hub.On<JToken>("OverallStatisticsChange", param => OverallStatisticsChange(param));
            _hub.On<JToken>("CowFactorChange", param => CowFactorChange(param));
            _hub.On<JToken>("StartOfDay", param => StartOfDay(param));
            _hub.On<JToken>("InstrumentEPSDataChage", param => InstrumentEPSDataChage(param));
            _hub.On<JToken>("BourseContractChange", param => BourseContractChange(param));

        }
        protected virtual Instrument BourseContractChange(JToken data)
        {
            Console.WriteLine("BourseContractChange");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;

        }
        protected virtual Instrument InstrumentEPSDataChage(JToken data)
        {
            Console.WriteLine("InstrumentEPSDataChage");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;

        }
        protected virtual Instrument StartOfDay(JToken data)
        {
            Console.WriteLine("StartOfDay");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;

        }
        protected virtual Instrument CowFactorChange(JToken data)
        {
            Console.WriteLine("CowFactorChange");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;

        }
        protected virtual Instrument InstrumentMarketTradePercentChange(JToken data)
        {
            Console.WriteLine("InstrumentClosingPriceChange");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;
        }
        protected virtual Instrument InstrumentClosingPriceChange(JToken data)
        {
            Console.WriteLine("InstrumentClosingPriceChange");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;
        }
        protected virtual Instrument InstrumentStaticThresholdsChange(JToken data)
        {
            Console.WriteLine("InstrumentStaticThresholdsChange");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;
        }
        protected virtual Instrument CreationOfInstrumentCharacteristics(JToken data)
        {
            Console.WriteLine("CreationOfInstrumentCharacteristics");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;
        }
        protected virtual Instrument InstrumentBestLimitChange(JArray data)
        {
            Console.WriteLine("ActiveInstrumentBestLimitChange");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //data.RemoveAt(0);
            //instrument.UpdateBestLimit(data);
            return null;
            
        }

        protected virtual void OverallStatisticsChange(JToken data)
        {
            Console.WriteLine("OverallStatisticsChange");
        }

        protected virtual void MarketMessage(JToken data)
        {
            Console.WriteLine("MarketMessage");
        }

        protected virtual Instrument InstrumentTrade(JToken data)
        {
            Console.WriteLine("InstrumentTrade");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //instrument.Trade(data);
            //return instrument;
            return null;
        }

        protected virtual Instrument InstrumentStateChange(JToken data)
        {
            Console.WriteLine("InstrumentStateChange");

            //var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            //instrument.StateChange(data);
            return null;
        }

        private static MarketDataClient _current;

        
    }
}
