using BuildingBlocks.EventBus.MessageQueue.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.EventBus.MessageQueue
{
    public class MQPersistantConnection : IMQPersistentConnection
    {

        public bool IsConnected => throw new NotImplementedException();

        public void Dispose()
        {
            //TODO
        }

        public bool TryConnect()
        {
            //TODO
            return true;
        }
    }
}
