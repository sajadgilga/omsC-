using Newtonsoft.Json.Linq;
using OMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OMS.Business.Client
{
    public class Instrument
    {
        public string Id { get; private set; }
        public long NumberOfTrades { get; private set; }
        public long MarketQuanity { get; private set; }
        public long LastTradePrice { get; private set; }
        public long FinalPrice { get; private set; }
        public string LastTradeDate { get; private set; }
        public decimal SectorPE { get; private set; }
        public long FirstPrice { get; private set; }
        public long ThresholdHigh { get; private set; }
        public long ThresholdLow { get; private set; }
        public long BaseVolume { get; private set; }
        public long YesterdayLastTradePrice { get; private set; }
        public long YesterdayFinalPrice { get; private set; }
        public long MaxValidBuyVolume { get; private set; }
        public long MaxValidSellVolume { get; private set; }
        public long MinValidVolume { get; private set; }
        public long LowestPrice { get; private set; }
        public long HighestPrice { get; private set; }
        public NscState NscState { get; private set; }
        public string InsCode { get; private set; }
        public TradePercentChage TradePercentChageData { get; private set; }
        public decimal EstimatedEPS { get; private set; }

        public BestLimit BestLimitFirst { get; private set; }
        public BestLimit BestLimitSecond { get; private set; }
        public BestLimit BestLimitThird { get; private set; }
        public BestLimit BestLimitFourth { get; private set; }
        public BestLimit BestLimitFifth { get; private set; }


        public Instrument(JToken data)
        {
            Update(data);
        }

        public void Update(JToken data)
        {
            Id = data[0].Value<string>();
            NumberOfTrades = data[1].Value<long>();
            MarketQuanity = data[2].Value<long>();
            LastTradePrice = data[3].Value<long>();
            FinalPrice = data[4].Value<long>();
            LastTradeDate = data[5].Value<string>();
            SectorPE = data[6].Value<decimal>();
            FirstPrice = data[8].Value<long>();
            ThresholdHigh = data[9].Value<long>();
            ThresholdLow = data[10].Value<long>();
            BaseVolume = data[11].Value<long>();
            YesterdayLastTradePrice = data[12].Value<long>();
            YesterdayFinalPrice = data[13].Value<long>();
            MaxValidBuyVolume = data[14].Value<long>();
            MaxValidSellVolume = data[15].Value<long>();
            MinValidVolume = data[16].Value<long>();
            LowestPrice = data[17].Value<long>();
            HighestPrice = data[18].Value<long>();
            NscState = data[19].Value<string>().ToNseState();
            InsCode = data[20].Value<string>();
            TradePercentChageData = new TradePercentChage(data[21]);
            EstimatedEPS = data[22].Value<decimal>();
        }

        internal void UpdateBestLimit(JArray data)
        {
            foreach (var item in data)
            {
                switch (item[0].Value<long>())
                {
                    case 1:
                        {
                            BestLimitFirst = new BestLimit(item);
                            break;
                        }
                    case 2:
                        {
                            BestLimitSecond = new BestLimit(item);
                            break;
                        }
                    case 3:
                        {
                            BestLimitThird = new BestLimit(item);
                            break;
                        }
                    case 4:
                        {
                            BestLimitFourth = new BestLimit(item);
                            break;
                        }
                    case 5:
                        {
                            BestLimitFifth = new BestLimit(item);
                            break;
                        }
                }

            }
        }
        public static Dictionary<string, Instrument> LoadMarketWatchItems(JToken data)
        {
            var retVal = new Dictionary<string, Instrument>();
            foreach (var item in data)
            {
                var ins = new Instrument(item[0]);
                ins.UpdateBestLimit(new JArray(item[1]));
                retVal.Add(ins.Id, ins);
            }
            return retVal;
        }

        internal void ThresholdsChange(JArray data)
        {
            ThresholdHigh = data[1].Value<long>();
            ThresholdLow = data[2].Value<long>();
        }

        internal void StateChange(JToken data)
        {
            NscState = data[2].Value<string>().ToNseState();
        }

        internal void TradePercentChage(JToken data)
        {
            NumberOfTrades = data[1].Value<long>();
            TradePercentChageData.Update(data[2]);
        }

        internal void Trade(JToken data)
        {
            HighestPrice = data[1].Value<long>();
            LowestPrice = data[2].Value<long>();
            FirstPrice = data[3].Value<long>();
            LastTradePrice = data[4].Value<long>();
            LastTradeDate = data[5].Value<string>();
            NumberOfTrades = data[6].Value<long>();
            MarketQuanity = data[7].Value<long>();
        }

        internal void ClosingPriceChange(JToken data)
        {
            NumberOfTrades = data[1].Value<long>();
            MarketQuanity = data[2].Value<long>();
            SectorPE = data[3].Value<long>();
            FinalPrice = data[4].Value<long>();
            YesterdayFinalPrice = data[5].Value<long>();
            YesterdayLastTradePrice = data[6].Value<long>();
        }

        internal void EPSDataChange(JToken data)
        {
            EstimatedEPS = data[1].Value<decimal>();
            SectorPE = data[2].Value<decimal>();

        }
    }
}
