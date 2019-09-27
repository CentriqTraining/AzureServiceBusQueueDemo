using AzureServiceBusQueueToolkit;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AzureServiceBusQueueDemoClient
{
    public class AzureServiceBusClient : INotifyPropertyChanged
    {
        public static int NumberOfMessagesSent = 0;
        private CancellationTokenSource _tokenSource = null;
        private QueueClient _client;
        private string _MessageText;
        private bool _CanStart, _CanStop;

        public event PropertyChangedEventHandler PropertyChanged;
        private string _OutGoingMessage;

        public string Message
        {
            get
            {
                return _OutGoingMessage;
            }
            set
            {
                _OutGoingMessage = value;
                RaisePropertyChanged(nameof(Message));
            }
        }

        public bool CanStart
        {
            get { return _CanStart; }
            private set
            {
                _CanStart = value;
                RaisePropertyChanged(nameof(CanStart));
            }
        }
        public bool CanStop
        {
            get { return _CanStop; }
            private set
            {
                _CanStop = value;
                RaisePropertyChanged(nameof(CanStop));
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AzureServiceBusClient()
        {
            //  Set the buttons to enabled/disabled
            CanStart = true;
            CanStop = false;

            //  Create a cancellationTokenSource which will be passed to the task
            _tokenSource = new CancellationTokenSource();

            //  Create a Queueclient that will connect to our 
            //  Service Bus item.
            var sb = QueueClient.CreateFromConnectionString(AzureServiceBusQueue.GetSenderConnectString());
            _client = sb.MessagingFactory.CreateQueueClient("testqueue");
        }
        public void StartSending(string messageText)
        {
            //  Set the text we'll be putting in each message
            _MessageText = messageText;

            //  Adjust our buttons so we can't run again
            //  until we stop this one
            CanStart = false;
            CanStop = true;

            //  Start our thread to send messages in an infinite loop
            ThreadPool.QueueUserWorkItem(SomeWork_Method, _tokenSource.Token);
        }
        public void StopSending()
        {
            CanStop = false;
            CanStart = true;
            _tokenSource.Cancel();
        }
        private void SomeWork_Method(object state)
        {
            var token = ( CancellationToken)state ;
            while (true)
            {
                Message = string.Format($"Message from {_MessageText} (#{NumberOfMessagesSent})");
                var msgItem = new SomeClassThatHasMyMessageInfo()
                {
                    MessageNumber = ++NumberOfMessagesSent,
                    Message = this.Message
                };
                var msg = new BrokeredMessage(JsonConvert.SerializeObject(msgItem));
                _client.Send(msg);

                token.ThrowIfCancellationRequested();
            }
        }
    }
}
