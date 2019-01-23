using BuildingBlocks.EventBus.Interfaces;
using Essence.Communication.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Services.Utils;
using System;
using System.Threading.Tasks;

namespace Essence.Communication.BusinessServices
{
    public interface IMessageService
    {
        Task<bool> ReceiveMessage(EssenceEventObjectStructure eventObjectStructure);
    }

    public class MessageService : BaseBusinessServices<SuccessResponse>, IMessageService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEventBus _eventBus;


        public MessageService(
            IHttpClientManager httpClientManager, 
            IConfiguration configuration, 
            IAuthenticationService authenticationService,
            IEventBus eventBus
            ) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _authenticationService = authenticationService;
            _eventBus = eventBus;
        }

        public async Task<bool> ReceiveMessage(EssenceEventObjectStructure eventObjectStructure)
        {
 
                return true; 
        }

        public override void SetApiEndpointAddress()
        {
            throw new NotImplementedException();
        }
    }
}
