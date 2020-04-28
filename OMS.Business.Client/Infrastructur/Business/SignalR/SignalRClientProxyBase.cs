using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.Business.Client
{
    public abstract class SignalRClientProxyBase : IDisposable
    {
        protected HubConnection Connection { get; private set; }
        protected IHubProxy Hub { get; private set; }
        public string ServiceUrl { get; private set; }
        public string HubName { get; private set; }
        private Task _connectionTask;
        public string ServerName { get; private set; }

        public SignalRClientProxyBase(string serverUrl, string hubName, string serverName, bool autoReconnect, Dictionary<string, string> queryString = null)
        {

            ServiceUrl = serverUrl;
            HubName = hubName;
            ServerName = serverName;
            if (queryString != null)
            {
                Connection = new HubConnection(serverUrl, queryString);
            }
            else
            {
                Connection = new HubConnection(serverUrl);
            }
            if (autoReconnect)
            {
                Connection.StateChanged += _connection_StateChanged;
            }
            Hub = Connection.CreateHubProxy(hubName);
            InitHub(Hub);
            StartConnection();
            try
            {
                Connection.Start().Wait();
            }
            catch (Exception ex) { /*Nothing*/}

        }

        public abstract void InitHub(IHubProxy hub);
        public void StartConnection()
        {
            if (_connectionTask == null)
            {
                _connectionTask = Task.Factory.StartNew(async () =>
                {
                    do
                    {
                        try
                        {
                            await Connection.Start();
                            _connectionTask.Dispose();
                            _connectionTask = null;
#if DEBUG
                            Console.WriteLine("Connect To {0} In {1}", ServerName, ServiceUrl);
#endif
                            break;
                        }
                        catch
                        {
#if DEBUG
                            Console.WriteLine("Try To Connect To {0} In {1}", ServerName, ServiceUrl);
#endif
                        }
                        await Task.Delay(1000);
                    } while (true);
                }, TaskCreationOptions.LongRunning);
            }
        }
        private void _connection_StateChanged(StateChange obj)
        {
            if (_connectionTask == null && obj.NewState == ConnectionState.Disconnected)
            {
                StartConnection();
            }
            else if (obj.NewState == ConnectionState.Reconnecting)
            {
#if DEBUG
                Console.WriteLine("Try To ReConnect To {0} In {1}", ServerName, ServiceUrl);
#endif
            }
            else if (obj.OldState == ConnectionState.Reconnecting && obj.NewState == ConnectionState.Connected)
            {
#if DEBUG
                Console.WriteLine("ReConnect To {0} In {1}", ServerName, ServiceUrl);
#endif
            }
        }

        public void CloseConnection()
        {
            Connection.Stop();
        }

        protected static void PreProcessResult(dynamic result)
        {
            dynamic ex = null;
            try
            {
                ex = result.ex;
            }
            catch { /*Nothing*/}
            
            if (result != null && !(result is string) && ex != null)
            {
                throw new OmsServerException((int)ex.i.Value, ex.m.Value);
            }

        }

        public void Dispose()
        {
            Connection.Dispose();
        }
    }
}
