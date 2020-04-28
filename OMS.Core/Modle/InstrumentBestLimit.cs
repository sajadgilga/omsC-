using OMS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public class InstrumentBestLimit// : IInstrumentBestLimit
    {
        /// <summary>
        /// حجم خرید 
        /// RLC04.QTitMeDem
        /// </summary>
        public long BuyVolume { get; set; }
        /// <summary>
        /// تعداد سفارش خرید 
        /// RLC04.ZOrdMeDem
        /// </summary>
        public long BuyOrderCount { get; set; }
        /// <summary>
        /// قیمت خرید 
        /// RLC04.PMeDem
        /// </summary>
        public long BuyPrice { get; set; }
        /// <summary>
        /// حجم فروش 
        /// RLC04.QTitMeOf
        /// </summary>
        public long SellVolume { get; set; }
        /// <summary>
        /// تعداد سفارش فروش 
        /// RLC04.ZOrdMeOf
        /// </summary>
        public long SellOrderCount { get; set; }
        /// <summary>
        /// قیمت فروش 
        /// RLC04.PMeOf
        /// </summary>
        public long SellPrice { get; set; }
    }
}
