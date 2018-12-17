using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essence.Communication.BusinessServices;
using Essence.Communication.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Communication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportingService _reportingService;
        public ReportsController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        // GET: api/Reports
        [Route("GetResidentActivity")]
        [HttpPost]
        public async Task<ActionResult<ActivityResult>> GetResidentActivity(ActivityRequest activityRequest)
        {
            var result = await _reportingService.GetResidentActivity(activityRequest);
            return result;
        }
    }
}
