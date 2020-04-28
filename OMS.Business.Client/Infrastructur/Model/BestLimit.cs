using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class BestLimit
    {
        public long BuyOrderCount { get; private set; }
        public long BuyPrice { get; private set; }
        public long BuyVolume { get; private set; }
        public long SellOrderCount { get; private set; }
        public long SellPrice { get; private set; }
        public long SellVolume { get; private set; }


        public BestLimit(JToken data)
        {
            Update(data);
        }
        public void Update(JToken data)
        {
            BuyOrderCount = data[1].Value<long>();
            BuyPrice = data[2].Value<long>();
            BuyVolume = data[3].Value<long>();
            SellOrderCount = data[4].Value<long>();
            SellPrice = data[5].Value<long>();
            SellVolume = data[6].Value<long>();
        }
    }
}
