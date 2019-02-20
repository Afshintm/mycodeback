using System;
using System.Linq;
using System.Threading.Tasks;

using Essence.Communication.BusinessServices.ViewModels;
using Essence.Communication.DbContexts;
using Essence.Communication.Models.Dtos;
using Essence.Communication.Models.Utility;
using Services.Utilities.DataAccess;

namespace Essence.Communication.BusinessServices
{
    /// <summary>
    /// Combines raw data (GetResidentActivity) and Essence events data from database into a view model object to pass onto UI
    /// </summary>
    public class ResidentActivityMetaService : IResidentActivityService
    {
        private readonly IReportingService _reportingService;
        private readonly IUnitOfWork<IDbContext> _unitOfWork;
        private readonly IEventCreator _eventCreator;
        private readonly IModelMapper _modelMapper;

        public ResidentActivityMetaService(
            IReportingService reportingService, 
            IUnitOfWork<IDbContext> unitOfWork, 
            IEventCreator eventCreator,
            IModelMapper modelMapper)
        {
            _reportingService = reportingService;
            _unitOfWork = unitOfWork;
            _eventCreator = eventCreator;
            _modelMapper = modelMapper; //Reza: I do not see a big gain in doing this for mappers
        }
            
        public async Task<ResidentActivityViewModel> GetLast24HrActivityReportAndBeyond(string accountId)
        //Funny naming but at this stage there is a chance that we may need to retrieve more than 24hr of activities
        {
            var essenceDtFormatter = new EssenceDateFormatter(); //Trivial to inject to this class. better not to, to avoid cluttering the constructor and making unit tests complicated

            var residentAllActivities = new ResidentActivityViewModel();

            var last24HrActivityRequest = new Models.Dtos.ActivityRequest { account = accountId, startTime = DateTime.Now.AddHours(-24), endTime = DateTime.Now };
            var last24HrPanelTimeAsText = essenceDtFormatter.ToPanelTime(last24HrActivityRequest.startTime);

            //Source 1: Api call
            var activityReport = await _reportingService.GetResidentActivity(last24HrActivityRequest);

            residentAllActivities.ActivityTypes = activityReport.ActivityTypes.Select(a=> new ActivityTypeViewModel
            {
                ActivityType = a.ActivityType,
                Activities = a.Activities.Select(ac => new ActivityViewModel
                {
                    StartTime = ac.StartTime,
                    EndTime = ac.EndTime,
                    PassThreshold = ac.PassThreshold
                }).ToList()
            }).ToList();

            //Source 2: events logged in the database
            var eventsFromDbQuery = _unitOfWork.Repository<EssenceEventObjectStructure>().Query().Filter(e =>
                e.Account.ToString() == accountId && 
                string.Compare(e.PanelTime, last24HrPanelTimeAsText) >= 0);
            var eventDtos = eventsFromDbQuery.Get().ToList();

            /* TODO (check with Reza)
             * 
             * if eventDtos.Count ==0 then fetch previous days
             * 
             */

            var events = eventDtos.Select(e => _eventCreator.Create(e, new Models.Account { Id = accountId }));

            residentAllActivities.Alerts = events.Select(e => _modelMapper.MapToViewModel(e)).ToList();

            return residentAllActivities;
        }
    }

    public interface IResidentActivityService
    {
        Task<ResidentActivityViewModel> GetLast24HrActivityReportAndBeyond(string accountId);
    }
}
