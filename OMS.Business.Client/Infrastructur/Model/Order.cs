using Newtonsoft.Json.Linq;
using OMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class Order
    {
        public long Id { get; private set; }
        public string InstrumentId { get; private set; }
        public string CreateDate { get; private set; }
        public long Quantity { get; private set; }
        public long Price { get; private set; }
        public long ExecutedQuantity { get; private set; }
        public OrderSide Side { get; private set; }
        public OrderValidity Validity { get; private set; }
        public Date ValidityDate { get; private set; }
        public OrderStatus Status { get; private set; }
        public OrderCreditSource CreditSource { get; private set; }
        public string HON { get; private set; }
        public bool IsEdited { get; private set; }
        public OrderLockType LockType { get; private set; }
        public long DisclosedQuantity { get; private set; }
        public long MinimumQuantity { get; private set; }
        public bool IsToday { get; private set; }
        public long BlockedCredit { get; private set; }
        public long Remain { get; private set; }
        public string ErrorMessage { get; private set; }
        public OrderSource Source { get; private set; }
        public string ExtraData { get; private set; }

        public Order(JToken data)
        {
            Id = data[0].Value<long>();
            InstrumentId = data[1].Value<string>();
            CreateDate = data[2].Value<string>();
            Quantity = data[3].Value<long>();
            Price = data[4].Value<long>();
            ExecutedQuantity = data[5].Value<long>();
            Side = ((byte)data[6].Value<long>()).ToOrderSide(); //(OrderSide)Enum.ToObject(typeof(OrderSide), data[6].Value<long>());
            Validity = data[7].Value<byte>().ToOrderValidity();
            ValidityDate = new Date(data[8]);
            Status = data[9].Value<byte>().ToOrderStatus();
            CreditSource = ((byte)data[10].Value<long>()).ToOrderCreditSource();
            HON = data[11].Value<string>();
            IsEdited = data[12].Value<bool>();
            LockType = data[13].Value<byte>().ToOrderLockType();
            DisclosedQuantity = data[14].Value<long>();
            MinimumQuantity = data[15].Value<long>();
            IsToday = data[16].Value<bool>();
            BlockedCredit = data[17].Value<long>();
            Remain = data[18].Value<long>();
            ErrorMessage = data[19].Value<string>();
            Source = data[20].Value<byte>().ToOrderSource();
            ExtraData = data[21].Value<string>();
        }
        internal static Dictionary<long, Order> LoadOrders(JToken data)
        {
            var retVal = new Dictionary<long, Order>();
            foreach (var item in data)
            {
                var order = new Order(item);
                retVal.Add(order.Id, order);
            }
            return retVal;
        }

        internal void StateChange(JToken data)
        {
            Status = data[1].Value<byte>().ToOrderStatus();
            HON = data[2].Value<string>();
            IsEdited = data[3].Value<bool>();
            LockType = data[4].Value<byte>().ToOrderLockType();
            BlockedCredit = data[5].Value<long>();
            Remain = data[6].Value<long>();
            Source = data[7].Value<byte>().ToOrderSource();
        }

        internal void Execution(JToken data)
        {
            ExecutedQuantity = data[1].Value<long>();
            Status = data[2].Value<byte>().ToOrderStatus();
            LockType = data[3].Value<byte>().ToOrderLockType();
            BlockedCredit = data[4].Value<long>();
            Remain = data[5].Value<long>();
            var executedQuantity = data[6].Value<long>();
            var executedPrice = data[7].Value<long>();
            var executionDraftAmount = data[8].Value<long>();
        }

        internal void Edited(JToken data)
        {
            Quantity = data[1].Value<long>();
            Price = data[2].Value<long>();
            ExecutedQuantity = data[3].Value<long>();
            Validity = data[4].Value<byte>().ToOrderValidity();
            ValidityDate = new Date(data[5]);
            DisclosedQuantity = data[6].Value<long>();
            MinimumQuantity = data[7].Value<long>();
            Remain = data[8].Value<long>();

            StateChange(data[0].Value<JToken>());
        }

        internal void Error(JToken data)
        {
            ErrorMessage = data[1].Value<string>();
            StateChange(data[0]);
        }



    }
}
