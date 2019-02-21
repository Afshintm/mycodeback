using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.Models.Config;
using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Services.Utils;
using System;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IMessageService
    {
        Task<bool> ReceiveMessage(EssenceEventObjectStructure eventObjectStructure);
    }

    public class MessageService : EssenceService, IMessageService
    {
        private readonly IEventBus _eventBus;


        public MessageService(
            IHttpClientManager httpClientManager,
            IOptionsMonitor<ConfigOptions> monitor,
            IAuthenticationService authenticationService,
            IEventBus eventBus
            ) : base(httpClientManager, monitor, authenticationService, null, null)
        {
            _eventBus = eventBus;
        }

        public async Task<bool> ReceiveMessage(EssenceEventObjectStructure eventObjectStructure)
        {
            return await Task.Run(() => true);
        }
    }
}
