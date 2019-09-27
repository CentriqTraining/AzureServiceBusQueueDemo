using AzureServiceBusQueueToolkit;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureServiceBusQueueDemoServer
{
    public class AzureServiceBusServer 
    {
        private CancellationTokenSource _tokenSource = null;
        private QueueClient _client;
        private string _OutGoingMessage;
        public ObservableCollection<string> Messages { get; set; }

        public AzureServiceBusServer()
        {
            Messages = new ObservableCollection<string>();
            //  Create a cancellationTokenSource which will be passed to the task
            _tokenSource = new CancellationTokenSource();

            //  Create a Queueclient that will connect to our 
            //  Service Bus item.
            var sb = QueueClient.CreateFromConnectionString(AzureServiceBusQueue.GetListenerConnectString());
            _client = sb.MessagingFactory.CreateQueueClient("testqueue");
        }
        public void StartReceiving()
        {
            _client.OnMessage(ProcessMessage, 
                new OnMessageOptions() { MaxConcurrentCalls = 1 });
        }

        private void ProcessMessage(BrokeredMessage obj)
        {
            //  Fetches the data from the Queue.
            //  If we fail here...no biggie.  It is simply
            //  locked so no other receivers can see it
            //  for 1 minute.
            string MessageBody = obj.GetBody<string>();

            //  Show this message
            App.Current.Dispatcher.Invoke(() => Messages.Add(MessageBody));
            if (Messages.Count ==16 )
            {
                //  only keep the last 15 items (0-14)
                App.Current.Dispatcher.Invoke(() => Messages.RemoveAt(0));
            }

            //  When you are done processing you mark it 
            //  complete.  This removes it from the queue
            obj.Complete();
        }
    }
}
