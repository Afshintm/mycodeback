using System.Net;

namespace BuildingBlocks.EventBus.Events
{
    
    public class SendMessageResponse : ISendMessageResponse
    { 
        //
        // Summary:
        //     Gets and sets the property MD5OfMessageAttributes.
        //     An MD5 digest of the non-URL-encoded message attribute string. You can use this
        //     attribute to verify that Amazon SQS received the message correctly. Amazon SQS
        //     URL-decodes the message before creating the MD5 digest. For information about
        //     MD5, see RFC1321.
        public string MD5OfMessageAttributes { get; set; }
        //
        // Summary:
        //     Gets and sets the property MD5OfMessageBody.
        //     An MD5 digest of the non-URL-encoded message attribute string. You can use this
        //     attribute to verify that Amazon SQS received the message correctly. Amazon SQS
        //     URL-decodes the message before creating the MD5 digest. For information about
        //     MD5, see RFC1321.
        public string MD5OfMessageBody { get; set; }
        //
        // Summary:
        //     Gets and sets the property MessageId.
        //     An attribute containing the MessageId of the message sent to the queue. For more
        //     information, see Queue and Message Identifiers in the Amazon Simple Queue Service
        //     Developer Guide.
        public string MessageId { get; set; }
        //
        // Summary:
        //     Gets and sets the property SequenceNumber.
        //     This parameter applies only to FIFO (first-in-first-out) queues.
        //     The large, non-consecutive number that Amazon SQS assigns to each message.
        //     The length of SequenceNumber is 128 bits. SequenceNumber continues to increase
        //     for a particular MessageGroupId.
        public string SequenceNumber { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
