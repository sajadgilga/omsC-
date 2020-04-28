using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class BankAccount
    {
        public long Code { get; private set; }
        public string Name { get; private set; }

        public BankAccount(JToken data)
        {
            Code = data[0].Value<long>();
            Name = data[1].Value<string>();
        }
        internal static BankAccount[] LoadBankAccounts(JToken data)
        {
            var retVal = new List<BankAccount>();
            foreach (var item in data)
            {
                retVal.Add(new BankAccount(item));
            }
            return retVal.ToArray();
        }
    }
}
