using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServiceBusQueueToolkit
{
    public class SomeClassThatHasMyMessageInfo
    {
        public long MessageNumber { get; set; }
        public string Message { get; set; }
    }
}
