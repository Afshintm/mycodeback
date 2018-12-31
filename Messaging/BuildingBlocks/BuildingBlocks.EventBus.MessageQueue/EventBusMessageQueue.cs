using Amazon;
using Amazon.Runtime;
using Amazon.SQS;
using Amazon.SQS.Model;
using BuildingBlocks.EventBus.Events;
using BuildingBlocks.EventBus.Interfaces;
using BuildingBlocks.EventBus.MessageQueue.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.EventBus.MessageQueue
{
    public class EventBusMessageQueue : IEventBus
    {
        private readonly IMQPersistentConnection _persistentConnection;
        private readonly IConfiguration _configuration;
        private AmazonSQSClient _amazonSQSClient;

        public EventBusMessageQueue(IMQPersistentConnection persistentConnection, IConfiguration configuration)
        {
            _persistentConnection = persistentConnection;
            _configuration = configuration;
        }
        BasicAWSCredentials _basicAWSCredentials;
        BasicAWSCredentials SQSAWSCredential
        {
            get => _basicAWSCredentials ?? (_basicAWSCredentials = new BasicAWSCredentials(_configuration.GetSection("SQSSettings")["AccessKey"], _configuration.GetSection("SQSSettings")["SecretKey"]));
            set => _basicAWSCredentials = value;
        }

        public void Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;
            //var awsCreds = new BasicAWSCredentials(_configuration.GetSection("SQSSettings")["AccessKey"], _configuration.GetSection("SQSSettings")["SecretKey"]);

            _amazonSQSClient = new AmazonSQSClient(SQSAWSCredential, RegionEndpoint.APSoutheast2);

            //TODO: FIFO Queue

            var sqsRequest = new CreateQueueRequest
            {
                QueueName = _configuration.GetSection("SQSSettings")["QueueName"]
            };

            var createQueueResponse = _amazonSQSClient.CreateQueueAsync(sqsRequest).Result;

            var myQueueUrl = createQueueResponse.QueueUrl;

            var message = JsonConvert.SerializeObject(@event);
            
            //TODO: Encoding Message Base64 Encoding
            var encodedMessage = Encoding.UTF8.GetBytes(message);

            var sqsMessageRequest = new SendMessageRequest
            {
                QueueUrl = myQueueUrl,
                MessageBody = message
            };

            _amazonSQSClient.SendMessageAsync(sqsMessageRequest);

            //TODO: Do we need to store the published messages for tracking purpose?
        }

        public async Task<CreateQueueResponse> CreateQueueAsync() {
            _amazonSQSClient = new AmazonSQSClient(SQSAWSCredential, RegionEndpoint.APSoutheast2);
            var sqsRequest = new CreateQueueRequest
            {
                QueueName = _configuration.GetSection("SQSSettings")["QueueName"]
            };
            return await _amazonSQSClient.CreateQueueAsync(sqsRequest);

        }

        public async Task<ISendMessageResponse> PublishAsync(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;

            var createQueueResponse = await CreateQueueAsync();

            var message = JsonConvert.SerializeObject(@event);

            var encodedMessage = Encoding.UTF8.GetBytes(message);

            var sqsMessageRequest = new SendMessageRequest
            {
                QueueUrl = createQueueResponse.QueueUrl,
                MessageBody = message
            };
            var result =  await _amazonSQSClient.SendMessageAsync(sqsMessageRequest) ;
            var str = JsonConvert.SerializeObject(result);
            var r = JsonConvert.DeserializeObject<BuildingBlocks.EventBus.Events.SendMessageResponse>(str);
            return r;
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
