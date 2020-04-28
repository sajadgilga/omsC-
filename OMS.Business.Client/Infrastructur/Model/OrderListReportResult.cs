using Newtonsoft.Json.Linq;
using OMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class OrderListReportResult
    {
        public OrderListReportResult(JToken Data)
        {
            OrderId = Data[9].Value<long>();
            Hon = Data[0].Value<string>();
            InstrumentId = Data[1].Value<string>();
            CreateDate = Data[2].Value<string>();
            Quantity = Data[3].Value<long>();
            Price = Data[4].Value<long>();
            OrderType =((byte) Data[5].Value<long>()).ToOrderSide();
            OrderValidity = ((byte)Data[6].Value<long>()).ToOrderValidity();
            OrderStatus = ((byte)Data[7].Value<long>()).ToOrderStatus();
            CreditSource = ((byte)Data[8].Value<long>()).ToOrderCreditSource();

            Trades = new List<OrderListReportDetailResult>();
            foreach(var item in Data[10])
            {
                Trades.Add(new OrderListReportDetailResult(item));
            }
        }
        public long OrderId { get; set; }
        public string Hon { get; set; }
        public string InstrumentId { get; set; }
        public string CreateDate { get; set; }
        public long Quantity { get; set; }
        public long Price { get; set; }
        public OrderSide OrderType { get; set; }
        public OrderValidity OrderValidity { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public OrderCreditSource CreditSource { get; set; }
        public List<OrderListReportDetailResult> Trades { get; set; }
        

        //order.Hon, order.InstrumentId, order.CreateDate.ToPersianDateTimeString(), order.Quantity, order.Price, order.OrderTypeId, order.OrderValidityId, order.OrderStatusId,
        //    order.CreditSourceId, order.OrderId, trades

        //    x.TradeNumber, ((DateTime)x.TradeDate).ToPersianDateTimeString(), x.TradeQuantity, x.TradePrice, x.BrokerWage, x.BurseWage, x.DepositAgencyWage, x.ExchangeWage, x.TechnologyWage, x.Tax, x.TotalPrice
    }

    public class OrderListReportDetailResult
    {
        public OrderListReportDetailResult(JToken data)
        {
            TradeNumber = data[0].Value<string>();
            TradeDate = data[1].Value<string>();
            TradeQuantity = data[2].Value<long>();
            TradePrice = data[3].Value<long>();
            BrokerWage = data[4].Value<long>();
            BurseWage = data[5].Value<long>();
            DepositAgencyWage = data[6].Value<long>();
            ExchangeWage = data[7].Value<long>();
            TechnologyWage = data[8].Value<long>();
            Tax = data[9].Value<long>();
            TotalPrice = data[10].Value<long>();
        }
        public string TradeNumber { get; set; }
        public string TradeDate { get; set; }
        public long TradeQuantity { get; set; }
        public long TradePrice { get; set; }
        public long BrokerWage { get; set; }
        public long BurseWage { get; set; }
        public long DepositAgencyWage { get; set; }
        public long ExchangeWage { get; set; }
        public long TechnologyWage { get; set; }
        public long Tax { get; set; }
        public long TotalPrice { get; set; }
    }
}
