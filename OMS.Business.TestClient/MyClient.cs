using OMS.Business.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.TestClient
{
    class MyClient : OmsClient
    {
        public MyClient()
            : base(ConfigurationManager.AppSettings["ServerUrl"], ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"])
        {

        }

        public override void AcountInfoChange(long buyPower, long accountRemain, long credit, long block)
        {
            Console.WriteLine("AcountInfo\tBuyPower:{0},accountRemain:{1},credit:{2},block:{3}", buyPower, accountRemain, credit, block);
        }

        public override void OrderAdded(long id, string instrumentId, string createDate, long quantity, long price, long executedQuantity, byte orderType, byte orderValidity, long[] orderValidityDate, byte orderStatus, byte creditSource, string hon, bool edited, byte orderLockType, long disclosedQuantity, long minimumQuantity, bool isToday, long blockedCredit, long remain, string error, byte orderSource,string extraData)
        {
            Console.WriteLine("OrderAdded\tId:{0},InstrumentId:{1},quantity:{2},price:{3}", id, instrumentId, quantity, price);
        }

        public override void AssetAdded(string instrumentId, long quantity, long price, long lastPrice)
        {
            Console.WriteLine("AssetAdded\tInstrumentId:{0},quantity:{1},price:{2},lastPrice:{3}", instrumentId, quantity, price, lastPrice);
        }

        public override void Logout()
        {
            Console.WriteLine("Log out!");
        }

        public override void OrderStateChange(long Id, byte OrderStatus, string hon, bool edited, byte orderLockType, long blockedCredit, long remain, byte orderSource)
        {
            Console.WriteLine("OrderStateChange");
        }

        public override void InitUI(string fName, string lName, string investorId, string bourseCode, byte maxOrderRepeat)
        {
            Console.WriteLine("InitUI/tinvestorId:{0},bourseCode:{1}", investorId, bourseCode);
        }

        public override void OrderExecution(long id, long executedQuantity, byte orderStatus, byte orderLockType, long blockedCredit, long remain, long quantity, long price, long draftAmount)
        {
            Console.WriteLine("OrderExecution\tid:{0},executedQuantity:{1},remain:{2}", id, executedQuantity, remain);
        }

        public override void OrderEdited(long id, long quantity, long price, long executedQuantity, long orderValidity, long[] orderValidityDate, long disclosedQuantity, long minimumQuantity, long remain)
        {
            Console.WriteLine("OrderEdited\tid:{0},quantity:{1},price:{2},executedQuantity:{3}", id, quantity, price, executedQuantity);
        }

        public override void OrderError(long id, string errorMessage)
        {
            Console.WriteLine("OrderError\tid:{0},errorMessage:{1}", id, errorMessage);
        }

        public override void ShowError(long errorId, string errorMessage)
        {
            Console.WriteLine("ShowError\tErrorId:{0},ErrorMessage:{1}", errorId, errorMessage);
        }

        public override void AssetPriceChange(string instrumentId, long price)
        {
            Console.WriteLine("AssetPriceChange\tinstrumentId:{0},price:{1}", instrumentId, price);
        }

        public override void AssetChange(string instrumentId, long quantity, long price, long lastTradePrice)
        {
            Console.WriteLine("AssetChange\tinstrumentId:{0},quantity:{1},price:{2},lastTradePrice:{3}", instrumentId, quantity, price, lastTradePrice);
        }

        public override void RemoveAsset(string instrumentId)
        {
            Console.WriteLine("RemoveAsset\tinstrumentId:{0}", instrumentId);
        }
    }
}
