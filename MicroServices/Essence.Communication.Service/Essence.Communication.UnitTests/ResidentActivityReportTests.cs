using Essence.Communication.BusinessServices;
using Essence.Communication.BusinessServices.ViewModels;
using Essence.Communication.DbContexts;
using Essence.Communication.Models;
using Essence.Communication.Models.Utility;
using Essence.Communication.Models.ValueObjects;
using Moq;
using Services.Utilities.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Xunit;

namespace Essence.Communication.UnitTests
{
    public class ResidentActivityReportTests
    {
        [Fact]
        public void Test1()
        {
            const string testAccountId = "9999";

            var unitOfWorkMoq = new Mock<IUnitOfWork<ApplicationDbContext>>();
            var repoMoq = new Mock<IRepository<EventBase>>();
            var testEvents = new EventBase[] { new Event<UnexpectedActivityDetails>(), new Event<UnexpectedEntryExitDetails>() };
            repoMoq.Setup(r => r.Query().Filter(It.IsAny<Expression<Func<EventBase, bool>>>()).Get(It.IsAny<Expression<Func<EventBase, bool>>>())).Returns(() => testEvents);

            var essenceReportingServiceMoq = new Mock<IReportingService>();
            essenceReportingServiceMoq.Setup(e => e.GetResidentActivity(new Models.Dtos.ActivityRequest { account = testAccountId }).Result).Returns(new Models.Dtos.ActivityResult());

            var resActivityServiceMoq = new Mock<ResidentActivityMetaService>(essenceReportingServiceMoq, unitOfWorkMoq);
            resActivityServiceMoq.Setup(s => s.GetLast24HrActivityReportAndBeyond(testAccountId).Result).Returns(new ResidentActivityViewModel { ResidentName = "Test Teser" });

            var service = new ResidentActivityMetaService(essenceReportingServiceMoq.Object, unitOfWorkMoq.Object, new EventCreator(new HSCCodeDetailsMapper(new HSCEventCodeList()), new HSCAlertTypeRules(new HSCEventCodeList())), new ModelMapper());

            var last24HrActivity = service.GetLast24HrActivityReportAndBeyond(testAccountId);

            //unitOfWorkMoq.Setup<IRepository<EventBase>>(r=> r.Repository<EventBase>()).Returns(
            //    //arrange
            //    var stubMapper = new Mock<IEventCodeDetailsTypeMapper>();
            //    var stubEvent = new BusinessServices.Model.Event();
            //    stubEvent.Details = null;
            //    var eventDetailsCreater = new EventDetailsCreater(stubMapper.Object);

            //    //action
            //    var result = eventDetailsCreater.Create(stubEvent);

            //    //assert
            //    Assert.Null(result);
        }
    }
}
