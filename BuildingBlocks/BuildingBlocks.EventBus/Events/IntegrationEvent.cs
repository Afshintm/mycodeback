using System;

namespace BuildingBlocks.EventBus.Events
{
    public class IntegrationEvent
    {
        public Guid Guid { get; set; }
        public DateTime CreationDate { get; set; }

        public IntegrationEvent()
        {
            Guid = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
    }
}
