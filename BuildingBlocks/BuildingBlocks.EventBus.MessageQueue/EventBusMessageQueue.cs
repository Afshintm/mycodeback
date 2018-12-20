using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Interfaces;
using BuildingBlocks.EventBus.MessageQueue.Interfaces;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace BuildingBlocks.EventBus.MessageQueue
{
    public class EventBusMessageQueue : IEventBus
    {
        private readonly IMQPersistentConnection _persistentConnection;

        public EventBusMessageQueue(IMQPersistentConnection persistentConnection)
        {
            _persistentConnection = persistentConnection;
        }

        public void Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;
            var awsCreds = new BasicAWSCredentials("AKIAIA4CFFZ7W3DI7GAA", "obuTJzJ0Qiuiv9g4kNmZCbH1lE3ru9VQpFma96+Z");

            IAmazonSQS amazonSQS = new AmazonSQSClient(awsCreds, RegionEndpoint.APSoutheast2);

            var sqsRequest = new CreateQueueRequest
            {
                QueueName = "HSCTestQueue"
            };

            var createQueueResponse = amazonSQS.CreateQueueAsync(sqsRequest).Result;

            var myQueueUrl = createQueueResponse.QueueUrl;

            var listQueueRequest = new ListQueuesRequest();
            var listQueueResponse = amazonSQS.ListQueuesAsync(listQueueRequest);

            var sqsMessageRequest = new SendMessageRequest
            {
                QueueUrl = myQueueUrl,
                MessageBody = JsonConvert.SerializeObject(@event)
            };

            amazonSQS.SendMessageAsync(sqsMessageRequest);
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var awsCreds = new BasicAWSCredentials("AKIAIA4CFFZ7W3DI7GAA", "obuTJzJ0Qiuiv9g4kNmZCbH1lE3ru9VQpFma96+Z");
            IAmazonSQS amazonSQS = new AmazonSQSClient(awsCreds, RegionEndpoint.APSoutheast2);

            var queueUrl = amazonSQS.GetQueueUrlAsync("HSCTestQueue").Result.QueueUrl;

            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = queueUrl
            };

            var receiveMessageResponse = amazonSQS.ReceiveMessageAsync(receiveMessageRequest).Result;

            var messageRecptHandler = receiveMessageResponse.Messages.FirstOrDefault()?.ReceiptHandle;

            var message = JsonConvert.DeserializeObject<IntegrationEvent>(messageRecptHandler);

            var message1 = message;
        }

    }
}
