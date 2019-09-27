using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceBusQueueToolkit
{

    public class AzureServiceBusConfiguration
    {
        public object AliasPrimaryConnectionString { get; set; }
        public object AliasSecondaryConnectionString { get; set; }
        public string KeyName { get; set; }
        public string PrimaryConnectionString { get; set; }
        public string PrimaryKey { get; set; }
        public string SecondaryConnectionString { get; set; }
        public string SecondaryKey { get; set; }
    }
}
