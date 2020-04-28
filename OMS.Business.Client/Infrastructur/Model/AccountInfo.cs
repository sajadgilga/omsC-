using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class AccountInfo
    {
        public long BuyPower { get; private set; }
        public long AccountRemain { get; private set; }
        public long Credit { get; private set; }
        public long Block { get; private set; }

        public AccountInfo(JToken data)
        {
            Update(data);
        }
        public void Update(JToken data)
        {
            BuyPower = data[0].Value<long>();
            AccountRemain = data[1].Value<long>();
            Credit = data[2].Value<long>();
            Block = data[3].Value<long>();
        }


    }
}
