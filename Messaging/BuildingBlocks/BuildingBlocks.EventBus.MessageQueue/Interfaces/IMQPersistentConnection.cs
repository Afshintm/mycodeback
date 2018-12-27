using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.EventBus.MessageQueue.Interfaces
{
    public interface IMQPersistentConnection : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

    }
}
