using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentBestLimit
    {
        /// <summary>
        /// حجم خرید 
        /// RLC04.QTitMeDem
        /// </summary>
        long BuyVolume { get; set; }
        /// <summary>
        /// تعداد سفارش خرید 
        /// RLC04.ZOrdMeDem
        /// </summary>
        long BuyOrderCount { get; set; }
        /// <summary>
        /// قیمت خرید 
        /// RLC04.PMeDem
        /// </summary>
        long BuyPrice { get; set; }
        /// <summary>
        /// حجم فروش 
        /// RLC04.QTitMeOf
        /// </summary>
        long SellVolume { get; set; }
        /// <summary>
        /// تعداد سفارش فروش 
        /// RLC04.ZOrdMeOf
        /// </summary>
        long SellOrderCount { get;set; }
        /// <summary>
        /// قیمت فروش 
        /// RLC04.PMeOf
        /// </summary>
        long SellPrice { get; set; }
    }
}
