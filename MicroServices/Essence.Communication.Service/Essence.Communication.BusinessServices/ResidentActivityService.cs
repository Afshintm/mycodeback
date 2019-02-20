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

        public ResidentActivityMetaService(IReportingService reportingService, IUnitOfWork<IDbContext> unitOfWork)
        {
            _reportingService = reportingService;
            _unitOfWork = unitOfWork;
        }
            
        public async Task<ResidentActivityViewModel> GetLast24HrActivityReport(string accountId)
        {
            var essenceDtFormatter = new EssenceDateFormatter(); //Trivial to inject to this class. better not to, to avoid cluttering the constructor and making unit tests complicated

            var residentAllActivities = new ResidentActivityViewModel();

            var last24HrActivityRequest = new Models.Dtos.ActivityRequest { account = accountId, startTime = DateTime.Now.AddHours(-24), endTime = DateTime.Now };
            var last24HrPanelTimeAsText = essenceDtFormatter.ToPanelTime(last24HrActivityRequest.startTime);

            //Source 1: Api call
            var activityReport = await _reportingService.GetResidentActivity(last24HrActivityRequest);
            
            //Source 2: events logged in the database
            var eventsFromDbQuery = _unitOfWork.Repository<EssenceEventObjectStructure>().Query().Filter(e =>
                e.Account.ToString() == accountId && 
                string.Compare(e.PanelTime, last24HrPanelTimeAsText) >= 0);
            var events = eventsFromDbQuery.Get().ToList();
            
            throw new NotImplementedException();
        }
    }

    public interface IResidentActivityService
    {
        Task<ResidentActivityViewModel> GetLast24HrActivityReport(string account);
    }
}
