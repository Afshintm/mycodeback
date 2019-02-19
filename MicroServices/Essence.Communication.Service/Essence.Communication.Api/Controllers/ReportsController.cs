using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essence.Communication.BusinessServices;
using Essence.Communication.BusinessServices.ViewModels;
using Essence.Communication.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Communication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IResidentActivityService _residentActivityService;

        public ReportsController(IResidentActivityService residentActivityService)
        {
            _residentActivityService = residentActivityService;
        }

        // GET: api/Reports
        [Route("GetResidentActivity")]
        [HttpPost]
        public async Task<ActionResult<ResidentActivityViewModel>> GetResidentActivity(string account)
        {
            var activityReport = await _residentActivityService.GetLast24HrActivityReport(account);

            return Ok(activityReport);

            //var result = await _reportingService.GetResidentActivity(activityRequest);
            //return result;
        }
    }
}
