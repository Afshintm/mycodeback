﻿using BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.EventBus.Interfaces
{
    public interface IEventBus
    {
        void Publish(IntegrationEvent @event);
        void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;
    }
}