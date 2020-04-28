using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class InstrumentInfo
    {
        public string InstrumentId { get; private set; }
        public string Symbol { get; private set; }
        public string Name { get; private set; }
        public string InstrumentTypeId { get; private set; }
        public byte InstrumentWageType { get; private set; }
        public bool CanBuy { get; private set; }
        public bool CanSale { get; private set; }

        public InstrumentInfo(JToken data)
        {
            InstrumentId = data[0].Value<string>();
            Symbol = data[1].Value<string>();
            Name = data[2].Value<string>();
            InstrumentTypeId = data[3].Value<string>();
            InstrumentWageType = data[4].Value<byte>();
            CanBuy = data[5].Value<bool>();
            CanSale = data[6].Value<bool>();
        }

    }
}
