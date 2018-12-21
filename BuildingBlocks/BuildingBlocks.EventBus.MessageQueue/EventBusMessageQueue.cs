using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Interfaces;
using BuildingBlocks.EventBus.MessageQueue.Interfaces;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public EventBusMessageQueue(IMQPersistentConnection persistentConnection, IConfiguration configuration)
        {
            _persistentConnection = persistentConnection;
            _configuration = configuration;
        }

        public void Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;
            var awsCreds = new BasicAWSCredentials(_configuration.GetSection("SQSSettings")["AccessKey"], _configuration.GetSection("SQSSettings")["SecretKey"]);

            IAmazonSQS amazonSQS = new AmazonSQSClient(awsCreds, RegionEndpoint.APSoutheast2);

            //TODO: FIFO Queue

            var sqsRequest = new CreateQueueRequest
            {
                QueueName = _configuration.GetSection("SQSSettings")["QueueName"]
            };

            var createQueueResponse = amazonSQS.CreateQueueAsync(sqsRequest).Result;

            var myQueueUrl = createQueueResponse.QueueUrl;

            var message = JsonConvert.SerializeObject(@event);
            
            //TODO: Encoding Message Base64 Encoding
            var encodedMessage = Encoding.UTF8.GetBytes(message);

            var sqsMessageRequest = new SendMessageRequest
            {
                QueueUrl = myQueueUrl,
                MessageBody = message
            };

            amazonSQS.SendMessageAsync(sqsMessageRequest);

            //TODO: Do we need to store the published messages for tracking purpose?
        }

        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var awsCreds = new BasicAWSCredentials(_configuration.GetSection("SQSSettings")["AccessKey"], _configuration.GetSection("SQSSettings")["SecretKey"]);
            IAmazonSQS amazonSQS = new AmazonSQSClient(awsCreds, RegionEndpoint.APSoutheast2);

            var queueUrl = amazonSQS.GetQueueUrlAsync(_configuration.GetSection("SQSSettings")["QueueName"]).Result.QueueUrl;

            var receiveMessageRequest = new ReceiveMessageRequest
            {
                QueueUrl = queueUrl
            };

            var receiveMessageResponse = amazonSQS.ReceiveMessageAsync(receiveMessageRequest).Result;

            var messageRecptHandler = receiveMessageResponse.Messages.FirstOrDefault()?.ReceiptHandle;

            var message = JsonConvert.DeserializeObject<IntegrationEvent>(messageRecptHandler);
            //TODO: Decode Message Base64 Decoding

            //TODO: Invoke the Integration Event Handler

            //TODO: Check same subscriber is not picked the message from the queue before deletion

            //TODO: Delete the message from queue once the subscribers has processed the message

            var message1 = message;
        }

    }
}
