using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    public interface IInstrumentCharacteristicsParam:IInstrumentParam
    {
        string EInsCode { get;  }
        string EName { get;  }
        string CompanyName { get;  }
        string Symbol { get;  }
        string Name { get;  }
        string ISINCode { get;  }
        string Group { get;  }
        string Industry { get;  }
        string SettlementDelay { get;  }
        long MaxValidPrice { get;  }
        long MinValidPrice { get;  }
        long BaseVolume { get;  }
        string Type { get;  }
        long MinDealablePrice { get;  }
        long MinDealableCount { get;  }
        long MaxValidBuyVolume { get;  }
        long MaxValidSellVolume { get;  }
        long MinValidVolume { get;  }
        long YesterdayFinalPrice { get;  }
        long YesterdayLastTradePrice { get;  }
    }
}
