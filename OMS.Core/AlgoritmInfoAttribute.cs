using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Core
{
    [AttributeUsage(AttributeTargets.Class)]
    class AlgoritmInfoAttribute : Attribute
    {
        public string InstrumentId { get; private set; }
        public string Name { get; private set; }
        public string Descriptions { get; private set; }
        public string ProviderName { get; private set; }
        public string ProviderUrl { get; private set; }
    }
}
