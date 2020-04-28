using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.SignalR.Client;
using OMS.Core;
using System.Globalization;

namespace OMS.Business.Client
{
    public class Investor : SignalRClientProxyBase
    {
        public string InvestorId { get; private set; }
        public string FName { get; private set; }
        public string LName { get; private set; }
        public AccountInfo AccountInfo { get; private set; }
        public bool CanBlockFromSaman { get; private set; }
        public bool CanBlockFromMellat { get; private set; }
        public bool CanUseSamanGateway { get; private set; }
        public bool CanUseMellatGateway { get; private set; }
        public BankAccount[] BankAccounts { get; private set; }
        public string BourseCode { get; private set; }
        public long MaxOrderRepeat { get; private set; }
        public bool CanUsePaymentGateway { get; private set; }
        public MarketWatchBase[] MarketWatchs { get; private set; }
        public Dictionary<long, Order> Orders { get; private set; }
        public Dictionary<string, Asset> Assets { get; private set; }
        public MarketWatch ActiveMarketWatch { get; private set; }

       

        public override void InitHub(IHubProxy _hub)
        {
            _hub.On<JToken>("initUI", param => InitUI(param));
            _hub.On("Logout", param => Logout());
            _hub.On<JToken>("CreditInfoUpdate", param => CreditInfoUpdate(param));
            _hub.On<JToken>("ShowError", param => ShowError(param));

            _hub.On<JToken>("OrderAdded", param => OrderAdded(param));
            _hub.On<JToken>("OrderStateChange", param => OrderStateChange(param));
            _hub.On<JToken>("OrderExecution", param => OrderExecution(param));
            _hub.On<JToken>("OrderEdited", param => OrderEdited(param));
            _hub.On<JToken>("OrderError", param => OrderError(param));

            _hub.On<JToken>("AssetPriceChange", param => AssetPriceChange(param));
            _hub.On<JToken>("AssetChange", param => AssetChange(param));
            _hub.On<JToken>("RemoveAsset", param => RemoveAsset(param));

            _hub.On<JArray>("ActiveInstrumentBestLimitChange", param => ActiveInstrumentBestLimitChange(param));
            _hub.On<JArray>("ActiveInstrumentThresholdsChange", param => ActiveInstrumentThresholdsChange(param));
            _hub.On<JArray>("InstrumentFirstBestLimitChange", param => ActiveInstrumentBestLimitChange(param));
            _hub.On<JToken>("InstrumentTrade", param => InstrumentTrade(param));
            _hub.On<JToken>("InstrumentStateChange", param => InstrumentStateChange(param));
            _hub.On<JToken>("InstrumentTradePercentChage", param => InstrumentTradePercentChage(param));
            _hub.On<JToken>("InstrumentClosingPriceChange", param => InstrumentClosingPriceChange(param));
            _hub.On<JToken>("InstrumentEPSDataChange", param => InstrumentEPSDataChange(param));
        }


        [Obsolete("GetInvestorAsync() has been deprecated.  Use GetInvestorExAsync().", false)]
        public static Task<T> GetInvestorAsync<T>()
            where T : Investor
        {
            return GetInvestorAsync<T>(ConfigurationManager.AppSettings["ServerUrl"], ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"]);
        }
        public static Task<T> GetInvestorExAsync<T>()
            where T : Investor
        {
            return GetInvestorExAsync<T>(ConfigurationManager.AppSettings["ServerUrl"], ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"]);
        }
        [Obsolete("GetInvestorAsync(String serverUrl,string userName, string password) has been deprecated.  Use GetInvestorExAsync(String serverUrl,string userName, string password).", false)]
        public static Task<T> GetInvestorAsync<T>(string serverUrl, string userName, string passWord, params object[] args)
            where T : Investor
        {
            return Task.Run<T>(async () =>
            {
                Dictionary<string, string> queryString = new Dictionary<string, string>(1);
                using (TokenClientProxy t = new TokenClientProxy(serverUrl, "Token"))
                {
                    await Task.Delay(500);
                    var token = await t.GetTokenAsync(userName, passWord);
                    queryString.Add("token", token);
                }
                var param = new List<object>();
                param.Add(serverUrl);
                param.Add("Oms");
                param.Add(queryString);
                if (args != null)
                {
                    param.AddRange(args);
                }
                return (T)Activator.CreateInstance(typeof(T), param.ToArray());
            });
        }
        public static Task<T> GetInvestorExAsync<T>(string serverUrl, string userName, string passWord, params object[] args)
           where T : Investor
        {
            return Task.Run<T>(async () =>
            {
                Dictionary<string, string> queryString = new Dictionary<string, string>(1);
                using (TokenClientProxy t = new TokenClientProxy(serverUrl, "Token"))
                {
                    await Task.Delay(500);
                    var token = await t.GetNewAPITokenAsync(userName, passWord);
                    queryString.Add("token", token);
                }
                var param = new List<object>();
                param.Add(serverUrl);
                param.Add("Oms");
                param.Add(queryString);
                if (args != null)
                {
                    param.AddRange(args);
                }
                return (T)Activator.CreateInstance(typeof(T), param.ToArray());
            });
        }
        public Investor(string url, string serverName, Dictionary<string, string> queryString) : base(string.Format("{0}/realtime", url), "OmsClientHub", string.Format("{0} Hub", serverName), true, queryString)
        {

        }

        protected virtual void InitUI(JToken data)
        {
            //Console.WriteLine("InitUI");
            //var part0 = data[0];
            //var appVersion = part0[0].Value<string>();
            //var serverTime = part0[3].Value<string>();
            //investor Info
            var investorData = data[1];
            var invesrotInfo = investorData[0];
            InvestorId = invesrotInfo[0].Value<string>();
            FName = invesrotInfo[1].Value<string>();
            LName = invesrotInfo[2].Value<string>();
            AccountInfo = new AccountInfo(invesrotInfo[3]);
            CanBlockFromSaman = invesrotInfo[4].Value<bool>();
            CanBlockFromMellat = invesrotInfo[5].Value<bool>();
            CanUseSamanGateway = invesrotInfo[6].Value<bool>();
            CanUseMellatGateway = invesrotInfo[7].Value<bool>();
            BankAccounts = BankAccount.LoadBankAccounts(invesrotInfo[8]);
            BourseCode = invesrotInfo[10].Value<string>();
            MaxOrderRepeat = invesrotInfo[11].Value<long>();
            CanUsePaymentGateway = invesrotInfo[12].Value<bool>();
            MarketWatchs = MarketWatchBase.LoadMarketWatchs(investorData[1]);
            Orders = Order.LoadOrders(investorData[2]);
            Assets = Asset.LoadAssets(investorData[3]);
            ActiveMarketWatch = new MarketWatch(data[2]);
        }

        protected virtual void Logout()
        {
            //Console.WriteLine("Logout");
        }
        protected virtual void CreditInfoUpdate(JToken data)
        {
            //Console.WriteLine("CreditInfoUpdate");

            AccountInfo.Update(data);
        }
        protected virtual void ShowError(JToken data)
        {
            //Console.WriteLine("ShowError");

            var id = data["i"].Value<long>();
            var message = data["m"].Value<string>();
        }

        protected virtual Order OrderAdded(JToken data)
        {
            //Console.WriteLine("AddOrder");

            var order = new Order(data);
            Orders.Add(order.Id, order);
            return order;
        }

        protected virtual Order OrderStateChange(JToken data)
        {
            //Console.WriteLine("OrderStateChange");

            var order = Orders[data[0].Value<long>()];
            order.StateChange(data);
            return order;
        }

        protected virtual Order OrderExecution(JToken data)
        {
            //Console.WriteLine("OrderExecution");

            var order = Orders[data[0].Value<long>()];
            order.Execution(data);
            return order;
        }

        protected virtual Order OrderEdited(JToken data)
        {
            //Console.WriteLine("OrderEdited");

            var order = Orders[data[0][0].Value<long>()];
            order.Edited(data);
            return order;
        }

        protected virtual Order OrderError(JToken data)
        {
            //Console.WriteLine("OrderError");

            var order = Orders[data[0][0].Value<long>()];
            order.Error(data);
            return order;
        }

        protected virtual Asset AssetPriceChange(JToken data)
        {
            //Console.WriteLine("AssetPriceChange");

            var retVal = Assets[data[0].Value<string>()];
            retVal.PriceChange(data);
            return retVal;
        }

        protected virtual Asset AssetChange(JToken data)
        {
            Console.WriteLine("AssetChange");
            Asset retVal = null;
            try
            {
                retVal = Assets[data[0].Value<string>()];
                retVal.Change(data);
            }
            catch
            {
                retVal = new Asset(data);
                Assets.Add(retVal.InstrumentId, retVal);
            }
            return retVal;
        }

        protected virtual Asset RemoveAsset(JToken data)
        {
            Console.WriteLine("RemoveAsset");
            var retVal = Assets[data.Value<string>()];
            Assets.Remove(retVal.InstrumentId);
            return retVal;
        }

        protected virtual Instrument ActiveInstrumentBestLimitChange(JArray data)
        {
            //Console.WriteLine("ActiveInstrumentBestLimitChange");

            var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            data.RemoveAt(0);
            instrument.UpdateBestLimit(data);
            return instrument;
        }

        protected virtual Instrument ActiveInstrumentThresholdsChange(JArray data)
        {
            //Console.WriteLine("ActiveInstrumentThresholdsChange");

            var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            instrument.ThresholdsChange(data);
            return instrument;
        }

        protected virtual Instrument InstrumentStateChange(JToken data)
        {
            //Console.WriteLine("InstrumentStateChange");

            var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            instrument.StateChange(data);
            return instrument;
        }

        protected virtual Instrument InstrumentTradePercentChage(JToken data)
        {
            //Console.WriteLine("InstrumentTradePercentChage");

            var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            instrument.TradePercentChage(data);
            return instrument;
        }

        protected virtual Instrument InstrumentTrade(JToken data)
        {
            //Console.WriteLine("InstrumentTrade");

            var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            instrument.Trade(data);
            return instrument;
        }

        protected virtual Instrument InstrumentClosingPriceChange(JToken data)
        {
            //Console.WriteLine("InstrumentClosingPriceChange");

            var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            instrument.ClosingPriceChange(data);
            return instrument;
        }

        protected virtual Instrument InstrumentEPSDataChange(JToken data)
        {
            //Console.WriteLine("InstrumentEPSDataChange");

            var instrument = ActiveMarketWatch.Instruments[data[0].Value<string>()];
            instrument.EPSDataChange(data);
            return instrument;
        }

        public async virtual Task TryAddOrderAsync(
            OrderSide side,
            string instrumentId,
            long quantity,
            long price,
            OrderCreditSource creditSource = OrderCreditSource.Broker,
            long? minimumQuantity = null,
            long? disclosedQuantity = null,
            OrderValidity validityType = OrderValidity.Day,
            long? validityDateYear = null,
            byte? validityDateMonth = null,
            byte? validityDateDay = null,
            byte repeat = 1,
            string extraData = null)
        {
            var list = new List<object>();
            list.Add((byte)side);
            list.Add(instrumentId);
            list.Add(quantity);
            list.Add(price);
            list.Add((byte)creditSource);
            list.Add(minimumQuantity);
            list.Add(disclosedQuantity);
            list.Add((byte)validityType);
            list.Add(validityDateYear);
            list.Add(validityDateMonth);
            list.Add(validityDateDay);
            list.Add(repeat);
            list.Add(extraData);
            var result = await Hub.Invoke<dynamic>("AddOrder", list);
            PreProcessResult(result);
        }

        public virtual async Task TryEditOrderAsync(
            long orderId,
            long quantity,
            long price,
            long? minimumQuantity = null,
            long? disclosedQuantity = null,
           OrderValidity validityType = OrderValidity.Day,
            long? validityDateYear = null,
            byte? validityDateMonth = null,
            byte? validityDateDay = null)
        {
            //Console.WriteLine("TryEditOrderAsync");
            var list = new List<object>();
            list.Add(orderId);
            list.Add(quantity);
            list.Add(price);
            list.Add(minimumQuantity);
            list.Add(disclosedQuantity);
            list.Add((byte)validityType);
            list.Add(validityDateYear);
            list.Add(validityDateMonth);
            list.Add(validityDateDay);
            var result = await Hub.Invoke<dynamic>("EditOrder", list);
            PreProcessResult(result);
        }

        public async virtual Task TryCancelOrderAsync(long orderId)
        {
            var result = await Hub.Invoke<dynamic>("CancelOrder", orderId);
            PreProcessResult(result);
        }

        public async virtual Task<InstrumentInfo[]> TryGetInstrumentList()
        {
            var retVal = new List<InstrumentInfo>();
            var result = await Hub.Invoke<JToken>("GetInstrumentList");
            foreach (var item in result)
            {
                retVal.Add(new InstrumentInfo(item));
            }
            return retVal.ToArray();
        }

        public async virtual Task TryChangeMarketWatch(long marketwatchId)
        {
            var result = await Hub.Invoke<JToken>("ChangeMarketWatch", marketwatchId);
            PreProcessResult(result);
            if (result != null)
            {
                ActiveMarketWatch = new MarketWatch(result);
            }
        }

        public virtual async Task<Instrument> TrySetActiveInstrument(string instrumentId)
        {
            var result = await Hub.Invoke<JArray>("SetActiveInstrument", instrumentId);
            PreProcessResult(result);
            var instruemntId = result[0][0].Value<string>();
            Instrument instrument = null;
            try
            {
                instrument = ActiveMarketWatch.Instruments[instruemntId];
                instrument.Update(result[0]);
            }
            catch
            {
                instrument = new Instrument(result[0]);
                ActiveMarketWatch.Instruments.Add(instrument.Id, instrument);
            }
            instrument.UpdateBestLimit((JArray)result[1]);
            return instrument;
        }

        public async virtual Task<List<OrderListReportResult>> TryGetOrderListReport(string instrumentId, OrderStatus? orderStatus, DateTime from, DateTime to)
        {
            List<OrderListReportResult> retVal = new List<OrderListReportResult>();
            var pc = new PersianCalendar();
            var fromYear = pc.GetYear(from);
            var fromMonth = pc.GetMonth(from);
            var fromDay = pc.GetDayOfMonth(from);

            var toYear = pc.GetYear(to);
            var toMonth = pc.GetMonth(to);
            var toDay = pc.GetDayOfMonth(to);

            var result = await Hub.Invoke<JArray>("GetOrderListReport", instrumentId, orderStatus, fromYear, fromMonth, fromDay, toYear, toMonth, toDay);
            foreach (var item in result)
            {
                retVal.Add(new OrderListReportResult(item));

            }
            return retVal;
        }

        public virtual Task<JToken> TryGetExtraService(string serviceName, object[] data)
        {
            return Hub.Invoke<JToken>("GetExtraService", serviceName, data);
        }

        public async Task<List<TradeListReportResult>> TryGetTradeListReportAsync(DateTime from, DateTime to)
        {
            List<TradeListReportResult> retVal = new List<TradeListReportResult>();
            var pc = new PersianCalendar();
            var fromYear = pc.GetYear(from);
            var fromMonth = pc.GetMonth(from);
            var fromDay = pc.GetDayOfMonth(from);

            var toYear = pc.GetYear(to);
            var toMonth = pc.GetMonth(to);
            var toDay = pc.GetDayOfMonth(to);
            var result = await Hub.Invoke<JArray>("GetTradeListReport", fromYear, fromMonth, fromDay, toYear, toMonth, toDay);
            PreProcessResult(result);
            foreach (var item in result)
            {
                retVal.Add(new TradeListReportResult(item));

            }
            return retVal;
        }
        //public async Task<List<OrderFlatListReportResult>> TryGetOrderFlatListReport(string instrumentId, OrderStatus orderStatus, DateTime from, DateTime to)
        //{
        //    List<OrderFlatListReportResult> retVal = new List<OrderFlatListReportResult>();
        //    var pc = new PersianCalendar();
        //    var fromYear = pc.GetYear(from);
        //    var fromMonth = pc.GetMonth(from);
        //    var fromDay = pc.GetDayOfMonth(from);

        //    var toYear = pc.GetYear(to);
        //    var toMonth = pc.GetMonth(to);
        //    var toDay = pc.GetDayOfMonth(to);

        //    var result = await Hub.Invoke<JArray>("GetOrderFlatListReport", instrumentId, orderStatus, fromYear, fromMonth, fromDay, toYear, toMonth, toDay);
        //    foreach (var item in result)
        //    {
        //        retVal.Add(new OrderFlatListReportResult(item));

        //    }
        //    return retVal;
        //}
    }
}
