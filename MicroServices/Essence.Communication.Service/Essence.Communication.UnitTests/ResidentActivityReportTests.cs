using Essence.Communication.BusinessServices;
using Essence.Communication.BusinessServices.ViewModels;
using Essence.Communication.Models;
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
            var unitOfWorkMoq = new Mock<IUnitOfWork<IDbContext>>();
            var reportingServiceMoq = new Mock<IReportingService>();
            var resActivityServiceMoq = new Mock<ResidentActivityMetaService>(reportingServiceMoq, unitOfWorkMoq);
            var repoMoq = new Mock<IRepository<EventBase>>();
            var testEvents = new EventBase[] { new Event<UnexpectedActivityDetails>(), new Event<UnexpectedEntryExitDetails>() };
            repoMoq.Setup(r => r.Query().Filter(It.IsAny<Expression<Func<EventBase, bool>>>()).Get(It.IsAny<Expression<Func<EventBase, bool>>>())).Returns(()=> testEvents);

            var service = new ResidentActivityMetaService(reportingServiceMoq.Object, unitOfWorkMoq.Object);

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
