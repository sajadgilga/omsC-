using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class OmsError:ApplicationException
    {
        public long Id { get; private set; }
        public OmsError(long id,string message):base(message)
        {
            Id = id;
        }
    }
}
