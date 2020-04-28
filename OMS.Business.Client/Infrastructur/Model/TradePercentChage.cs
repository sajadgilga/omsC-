using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class TradePercentChage
    {
        public long ActualBuyCount { get; private set; }
        public long ActualBuyQuantity { get; private set; }
        public long ActualSellCount { get; private set; }
        public long ActualSellQuantity { get; private set; }
        public long LegalBuyCount { get; private set; }
        public long LegalBuyQuantity { get; private set; }
        public long LegalSellCount { get; private set; }
        public long LegalSellQuantity { get; private set; }

        public TradePercentChage(JToken data)
        {
            Update(data);
        }
        public void Update(JToken data)
        {
            ActualBuyCount = data[0].Value<long>();
            ActualBuyQuantity = data[1].Value<long>();
            ActualSellCount = data[2].Value<long>();
            ActualSellQuantity = data[3].Value<long>();

            LegalBuyCount = data[4].Value<long>();
            LegalBuyQuantity = data[5].Value<long>();
            LegalSellCount = data[6].Value<long>();
            LegalSellQuantity = data[7].Value<long>();
        }

    }
}
