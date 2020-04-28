using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public class OmsServerException : ApplicationException
    {
        public int Code { get; private set; }
        public OmsServerException(int errorCode, string errorMessage)
            : base(errorMessage)
        {
            Code = errorCode;
        }
    }
}
