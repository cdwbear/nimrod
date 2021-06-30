using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Xml;
//using ApexWebServiceToolV2.ApexLocal9557;
using ApexWebServiceToolV2.ApexSandbox;
// using ApexWebServiceToolV2.ApexProduction;
//using ApexWebServiceToolV2.ApexProd;
//using ApexWebServiceToolV2.ApexLocal;
// using ApexWebServiceToolV2.ApexProd;


namespace ApexWebServiceToolV2
{
    internal class ClientHelper
    {
        #region bindingSettings

        private const int maxBufferPoolSize = 2147483647;
        private const int maxBufferSize = 2147483647;
        private const int maxReceivedMessageSize = 2147483647;
        private readonly TimeSpan _openTimeOut = new TimeSpan(0, 30, 0);
        private readonly TimeSpan _sendTimeOut = new TimeSpan(5, 0, 0);
        private readonly TimeSpan _receiveTimeOut = new TimeSpan(0, 30, 0);

        #endregion

        #region readerQuotas

        private const int maxDepth = 32;
        private const int maxStringContentLength = 2147483647;
        private const int maxArrayLength = 2147483647;
        private const int maxBytesPerRead = 1024000;
        private const int maxNameTableCharCount = 1024000;

        #endregion

        private ClientHelper()
        {

        }

        private static ClientHelper _clientHelper = null;
        private OneTouchServicesClient _client15 = new OneTouchServicesClient();

        public static ClientHelper Instance
        {
            get { return _clientHelper ?? (_clientHelper = new ClientHelper()); }
        }

        public OneTouchServicesClient ApexClient
        {
            get { return _client15; }
        }

        public OneTouchServicesClient ChangeBinding(ChannelEndpointElement endpoint)
        {
            if (_client15.Endpoint.Contract.ConfigurationName != endpoint.Contract)
            {
                var config =
                    ConfigurationManager.GetSection("system.serviceModel/bindings") as BindingsSection;

                BasicHttpBindingElement basicHttpBinding = null;
                BasicHttpSecurityMode configuredSecurityMode = BasicHttpSecurityMode.None;
                foreach (BasicHttpBindingElement bindingElement in config.BasicHttpBinding.Bindings)
                {
                    if (bindingElement.Name.Contains(endpoint.Name))
                    {
                        configuredSecurityMode = bindingElement.Security.Mode;
                        basicHttpBinding = bindingElement;
                        break;
                    }
                }

                //var contractName = endpoint.Contract.Substring(0, endpoint.Contract.LastIndexOf("."));
                //Type t = Type.GetType(
                //    string.Format("ApexWebServiceToolV2.{0}.OneTouchServicesClient", contractName));

                //object _dynamicClient = null;
                //if (null != t)
                //{
                //    _dynamicClient = Activator.CreateInstance(t);
                //    //_client15 = _dynamicClient;
                //}
                //else
                //{
                //    _client15 = new OneTouchServicesClient(endpoint.Name);
                //}

                _client15 = new OneTouchServicesClient(new BasicHttpBinding()
                    {
                        MaxBufferPoolSize =
                            basicHttpBinding.MaxBufferPoolSize > 0
                                ? basicHttpBinding.MaxBufferPoolSize
                                : maxBufferPoolSize,
                        MaxReceivedMessageSize =
                            basicHttpBinding.MaxReceivedMessageSize > 0
                                ? basicHttpBinding.MaxReceivedMessageSize
                                : maxReceivedMessageSize,
                        MaxBufferSize =
                            basicHttpBinding.MaxBufferSize > 0 ? maxBufferSize : basicHttpBinding.MaxBufferSize,
                        Security = new BasicHttpSecurity() {Mode = configuredSecurityMode},
                        OpenTimeout =
                            TimeSpan.Compare(basicHttpBinding.OpenTimeout, new TimeSpan(0, 0, 0)) > 0
                                ? basicHttpBinding.OpenTimeout
                                : _openTimeOut,
                        ReceiveTimeout =
                            TimeSpan.Compare(basicHttpBinding.ReceiveTimeout, new TimeSpan(0, 0, 0)) > 0
                                ? basicHttpBinding.ReceiveTimeout
                                : _receiveTimeOut,
                        SendTimeout =
                            TimeSpan.Compare(basicHttpBinding.SendTimeout, new TimeSpan(0, 0, 0)) > 0
                                ? basicHttpBinding.SendTimeout
                                : _sendTimeOut,
                        ReaderQuotas = new XmlDictionaryReaderQuotas()
                            {
                                MaxDepth =
                                    basicHttpBinding.ReaderQuotas.MaxDepth > 0
                                        ? basicHttpBinding.ReaderQuotas.MaxDepth
                                        : maxDepth,
                                MaxArrayLength =
                                    basicHttpBinding.ReaderQuotas.MaxArrayLength > 0
                                        ? basicHttpBinding.ReaderQuotas.MaxDepth
                                        : maxArrayLength,
                                MaxStringContentLength =
                                    basicHttpBinding.ReaderQuotas.MaxStringContentLength > 0
                                        ? basicHttpBinding.ReaderQuotas.MaxStringContentLength
                                        : maxStringContentLength,
                                MaxBytesPerRead =
                                    basicHttpBinding.ReaderQuotas.MaxBytesPerRead > 0
                                        ? basicHttpBinding.ReaderQuotas.MaxBytesPerRead
                                        : maxBytesPerRead,
                                MaxNameTableCharCount =
                                    basicHttpBinding.ReaderQuotas.MaxNameTableCharCount > 0
                                        ? basicHttpBinding.ReaderQuotas.MaxNameTableCharCount
                                        : maxNameTableCharCount
                            }
                    },
                    new EndpointAddress(endpoint.Address.AbsoluteUri));
                _client15.Endpoint.Contract.ConfigurationName = endpoint.Contract;
            }
            return _client15;
        }
    }
}
