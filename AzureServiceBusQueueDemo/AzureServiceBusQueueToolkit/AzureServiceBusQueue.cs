using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceBusQueueToolkit
{
    public static class AzureServiceBusQueue
    {
        public static string GetListenerConnectString()
        {
            string JsonText = File.ReadAllText(@"../../../AzureServiceBusQueueToolkit/Configuration\ListenerConfig.json");
            var result = JsonConvert.DeserializeObject<AzureServiceBusConfiguration>(JsonText);
            return result.SecondaryConnectionString;
        }
        public static string GetSenderConnectString()
        {
            string JsonText = File.ReadAllText(@"../../../AzureServiceBusQueueToolkit/Configuration\SenderConfig.json");
            var result = JsonConvert.DeserializeObject<AzureServiceBusConfiguration>(JsonText);
            return result.SecondaryConnectionString;
        }
    }
}
