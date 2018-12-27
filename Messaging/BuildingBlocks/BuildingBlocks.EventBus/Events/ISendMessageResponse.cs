using System.Net;

namespace BuildingBlocks.EventBus.Events
{
    public interface ISendMessageResponse
    {
        string MD5OfMessageAttributes { get; set; }
        string MD5OfMessageBody { get; set; }
        string MessageId { get; set; }
        string SequenceNumber { get; set; }
        HttpStatusCode HttpStatusCode { get; set; }
    }
}