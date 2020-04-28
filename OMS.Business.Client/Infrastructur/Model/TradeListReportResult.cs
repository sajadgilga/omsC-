using Newtonsoft.Json.Linq;
using OMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class TradeListReportResult
    {
        public string InvestorId { get; private set; }
        public string InstrumentId { get; private set; }
        public OrderSide Side { get; private set; }
        public long Quantity { get; private set; }
        public long TotalPrice { get; private set; }
        public long UnitPriceWithWage { get; private set; }
        public long UnitPrice { get; private set; }
        public long TradeCount { get; private set; }

        public TradeListReportResult(JToken data)
        {
            Update(data);
        }
        public void Update(JToken data)
        {
            InvestorId = data[0].Value<string>();
            InstrumentId = data[1].Value<string>();
            Side = ((byte)data[2].Value<long>()).ToOrderSide();
            Quantity = data[3].Value<long>();

            TotalPrice = data[4].Value<long>();
            UnitPriceWithWage = data[5].Value<long>();
            UnitPrice = data[6].Value<long>();
            TradeCount = data[7].Value<long>();
        }
    }
}
