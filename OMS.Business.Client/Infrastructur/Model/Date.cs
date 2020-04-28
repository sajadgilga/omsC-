using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class Date
    {
        public int? Year;
        public int? Month;
        public int? Day;

        public Date(JToken data)
        {
            if (data.Type != JTokenType.Null)
            {
                Year = data[0].Value<int>();
                Month = data[1].Value<int>();
                Day = data[2].Value<int>();
            }
        }

    }
}
