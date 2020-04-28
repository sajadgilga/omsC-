using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class MarketWatchBase
    {
        public long Code { get; private set; }
        public string Name { get; private set; }

        public MarketWatchBase(JToken data)
        {
            Code = data[0].Value<long>();
            Name = data[1].Value<string>();
        }

        internal static MarketWatchBase[] LoadMarketWatchs(JToken data)
        {
            var retVal = new List<MarketWatchBase>();
            foreach (var item in data)
            {
                retVal.Add(new MarketWatchBase(item));
            }
            return retVal.ToArray();
        }
    }
}
