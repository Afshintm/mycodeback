using Essence.Communication.BusinessServices;
using Essence.Communication.Models.Dtos;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Essence.Communication.UnitTests
{
    public class StubDetails : BaseDetails
    {
        public int MaximumThreshold { get; set; }
        public int ActualTemperature { get; set; }
    }

    public class EventDetailsCreaterTests
    {
        public EventDetailsCreaterTests()
        {
        }

        [Fact]
        public void CreateTest_SupportableEvent_ReturnConcreteDetails()
        {
            //arrange
            var stubMapper = new Mock<IEventCodeDetailsTypeMapper>();
            stubMapper.Setup(m => m.GetDetailType(It.IsAny<int>())).Returns(typeof(StubDetails));
            var stubDetails = new StubDetails { DeviceDescription = "Description", DeviceId = 11, DeviceType = 22, ActualTemperature = 333, MaximumThreshold = 444 };
            var stubEvent = CreateStubEvent( stubDetails);
            var eventDetailsCreater = new EventDetailsCreater(stubMapper.Object);

            //action
            var result = eventDetailsCreater.Create(stubEvent);

            //assert
            Assert.IsType< StubDetails>(result);
        }

        [Fact]
        public void CreateTest_EventDetailsIsNull_ReturnNull()
        {
            //arrange
            var stubMapper = new Mock<IEventCodeDetailsTypeMapper>();
            var stubEvent = new Event();
            stubEvent.Details = null;
            var eventDetailsCreater = new EventDetailsCreater(stubMapper.Object);

            //action
            var result = eventDetailsCreater.Create(stubEvent);

            //assert
            Assert.Null(result);
        }

        [Fact]
        public void CreateTest_EventIsNull_ReturnNull()
        {
            //arrange
            var stubMapper = new Mock<IEventCodeDetailsTypeMapper>(); 
            var eventDetailsCreater = new EventDetailsCreater(stubMapper.Object);

            //action
            var result = eventDetailsCreater.Create(null);

            //assert
            Assert.Null(result);
        }


        private Event CreateStubEvent(BaseDetails stubDetails = null)
        {
            var stub = new Event();
            stub.Code = 113;
            stub.Severity = 2222;

            if (stubDetails != null)
            {
                stub.Details = JObject.FromObject(stubDetails);
            }

            return stub;
        }
    }
}
