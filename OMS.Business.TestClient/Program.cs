using OMS.Business.Client;
using OMS.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.TestClient
{
    class Program
    {

        static void Main(string[] args)
        {
            //var proxy = new MyClient();
            Task t = Task.Run(async () =>
            {
                var i = await Investor.GetInvestorExAsync<Investor>();
                Console.WriteLine("Login...");

                //i.TrySetActiveInstrument("IRO1ABDI0001");
                //var t1 = await i.TryGetTradeListReportAsync(DateTime.Now, DateTime.Now);
                //var  k = t1.FirstOrDefault(x=>x.InstrumentId == "IRO1MADN0001");
                //int h = 0;
                //t.FirstOrDefault(x=>x.)
                ///Do Work

                //Console.ReadLine();
                //try
                //{
                //    i.TryAddOrderAsync(
                //        side: OrderSide.Buy,
                //        instrumentId: "IRO1MADN0001",
                //        quantity: 1,
                //        price: 1580,
                //        creditSource:OrderCreditSource.Broker,
                //        minimumQuantity:1,
                //        disclosedQuantity:0,
                //        validityType: OrderValidity.Day,
                //        validityDateYear:1396,
                //        validityDateMonth:7,
                //        validityDateDay:11,
                //        repeat:1,
                //        extraData:""
                //        ).Wait();
                //}catch(Exception ex)
                //{

                //}
                //var t = i.TryGetOrderFlatListReport("IRO1NAFT0001",  OrderStatus.Executed, DateTime.Now, DateTime.Now).Result ;
                //var t = i.TryGetExtraService("Arman.TodayTradeData", new object[] { "IRO1NAFT0001" }).Result;

                //var t = i.TryGetExtraService("Arman.HistoryTradeData", new object[] { "IRO1NAFT0001",1395,11,10,1395,12,29 }).Result;

                //Console.WriteLine("Press Enter to Edit Order");
                //Console.ReadLine();

                //var newOrder = i.Orders.Values.SingleOrDefault(x => x.ExtraData == exData);

                //i.TryEditOrderAsync(
                //    newOrder.Id,
                //    quantity: newOrder.Quantity + 10,
                // price: newOrder.Price + 5).Wait();

                //Console.WriteLine("Press Enter to Cancel Order");
                Console.ReadLine();

                //i.TryCancelOrderAsync(newOrder.Id).Wait();
            });
            t.Wait();
            

            Console.WriteLine("Press Enter to Close App");
            Console.ReadLine();
        }

        static async Task Main_(string[] args)
        {
            var prop = MarketDataClient.Current;
            Console.WriteLine("Press Enter to Close App");
            Console.ReadLine();
        }
    }
}
