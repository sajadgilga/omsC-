using Newtonsoft.Json.Linq;
using OMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class OrderFlatListReportResult
    {
        public long OrderId { get; set; }
        public string Hon { get; set; }
        public string InstrumentId { get; set; }
        public DateTime CreateDate { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public OrderSide OrderType { get; set; }
        public OrderValidity OrderValidity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderCreditSource CreditSource { get; set; }
        public string TradeNumber { get; set; }
        public DateTime TradeDate { get; set; }
        public long TradeQuantity { get; set; }
        public long TradePrice { get; set; }
        public long BrokerWage { get; set; }
        public long BurseWage { get; set; }
        public long DepositAgencyWage { get; set; }
        public long ExchangeWage { get; set; }
        public long TechnologyWage { get; set; }
        public long Tax { get; set; }
        public long TotalPrice { get; set; }

        public long ExecutedQuantity { get; set; }
        public OrderFlatListReportResult(JToken data)
        {
            
            Hon = data[0].Value<string>();
            InstrumentId = data[1].Value<string>();
            CreateDate = data[2].Value<DateTime>();
            Quantity = data[3].Value<long>();
            Price = data[4].Value<long>();
            ExecutedQuantity = data[5].Value<long>();
            OrderType = ((byte)data[6].Value<long>()).ToOrderSide();
            OrderValidity = ((byte)data[7].Value<long>()).ToOrderValidity();
            OrderStatus = ((byte)data[8].Value<long>()).ToOrderStatus();
            CreditSource = ((byte)data[9].Value<long>()).ToOrderCreditSource();
            TradeQuantity = data[10].Value<long>();
            TradePrice = data[11].Value<long>();
            TradeNumber = data[12].Value<string>();
            TradeDate = data[13].Value<DateTime>();
            
            
            BrokerWage = data[14].Value<long>();
            BurseWage = data[15].Value<long>();
            DepositAgencyWage = data[16].Value<long>();
            ExchangeWage = data[17].Value<long>();
            TechnologyWage = data[18].Value<long>();
            Tax = data[19].Value<long>();
            TotalPrice = data[20].Value<long>();
            OrderId = data[21].Value<long>();
        }
    }
}
