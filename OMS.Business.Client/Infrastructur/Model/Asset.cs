using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class Asset
    {
        public string InstrumentId { get; private set; }
        public long Quantity { get; private set; }
        public long Price { get; private set; }
        public long LastTradePrice { get; private set; }

        public Asset(JToken data)
        {
            Change(data);
        }

        internal static Dictionary<string, Asset> LoadAssets(JToken data)
        {
            var retVal = new Dictionary<string,Asset>();
            foreach (var item in data)
            {
                var asset = new Asset(item);
                retVal.Add(asset.InstrumentId, asset);
            }
            return retVal;
        }

        internal void PriceChange(JToken data)
        {
            LastTradePrice = data[1].Value<long>();
        }

        internal void Change(JToken data)
        {
            InstrumentId = data[0].Value<string>();
            Quantity = data[1].Value<long>();
            Price = data[2].Value<long>();
            LastTradePrice = data[3].Value<long>();
        }
    }
}
