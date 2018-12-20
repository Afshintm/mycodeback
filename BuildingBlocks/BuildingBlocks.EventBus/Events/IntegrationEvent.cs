using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.EventBus.Events
{
    public class IntegrationEvent
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }

        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
        }
    }
}
