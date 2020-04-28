using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    class TokenClientProxy : SignalRClientProxyBase
    {
        public TokenClientProxy(string url, string rlcName)
            : base(string.Format("{0}/realtime", url), "OmsClientTokenHub", string.Format("{0} Hub", rlcName),false)
        {

        }
        public override void InitHub(Microsoft.AspNet.SignalR.Client.IHubProxy hub)
        {

        }
        [Obsolete("GetTokenAsync(String userId, string password) has been deprecated.  Use GetNewAPITokenAsync(String userId, string password).", false)]
        public async Task<string> GetTokenAsync(string userId, string password)
        {
            var result = await base.Hub.Invoke<dynamic>("GetAPIToken", userId, password);
            PreProcessResult(result);
            return result;
        }
        public async Task<string> GetNewAPITokenAsync(string userId, string password)
        {
            var result = await base.Hub.Invoke<dynamic>("GetNewAPIToken", userId, password);
            PreProcessResult(result);
            return result;
        }
    }
}
