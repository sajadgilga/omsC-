using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public class TradeSignalEventArgs : EventArgs
    {
        //public string InstrumentId { get; set; }
        public long Price { get; set; }
        public OrderSide OrderType { get; set; }
        public long Sequence { get; set; }

    }
}
