using HomeScheduler.Common.Dto;
using HomeScheduler.Data;
using HomeScheduler.Data.Entity;
using HomeScheduler.Data.Repository;
using HomeScheduler.Service.Service;
using Moq;

namespace HomeScheduler.Service.Test
{
    public class AvailabilityServiceTest
    {
        private Mock<IAvailabilityRepository> _availabilityRepositoryMock;
        private Availability _entity;
        private AvailabilityDto _dto;

        [SetUp]
        public void Setup()
        {
            DateTime dt = DateTime.UtcNow;

            _entity = new Availability
            {
                AvailabilityId = 1,
                Available = true,
                UserId = 1,
                CreatedBy = "SYSTEM",
                CreatedDate = dt,
                UpdatedBy = "SYSTEM",
                UpdatedDate = dt,
            };
            _dto = new AvailabilityDto
            {
                AvailabilityId = 1,
                Available = true,
                UserId = 1,
                CreatedBy = "SYSTEM",
                CreatedDate = dt,
                UpdatedBy = "SYSTEM",
                UpdatedDate = dt,
            };

            _availabilityRepositoryMock = new Mock<IAvailabilityRepository>();
            _availabilityRepositoryMock.Setup(x => x.UpdateAvailability(It.IsAny<int>(), It.IsAny<Availability>()))
                .Returns(new UpdateResponse<Availability>
                {
                    Data = _entity,
                    ChangeCount = 1
                });
            _availabilityRepositoryMock.Setup(x => x.AddAvailability(It.IsAny<Availability>()))
                .Returns(new UpdateResponse<Availability>
                {
                    Data = _entity,
                    ChangeCount = 1
                });
        }

        [Test]
        public void ToggleAvailability_ExistingEntity_Test()
        {
            _availabilityRepositoryMock.Setup(x => x.GetAvailabilityByUserId(It.IsAny<int>()))
                .Returns(_entity);

            IAvailabilityService service = new AvailabilityService(_availabilityRepositoryMock.Object);
            UpdateResponseDto<AvailabilityDto> result = service.ToggleAvailability(1, new NoDataRequestDto("SYSTEM"));
            Assert.That(result.Data.AvailabilityId, Is.EqualTo(_dto.AvailabilityId));
            Assert.That(result.Data.Available, Is.Not.EqualTo(_dto.Available));
            Assert.That(result.Data.UserId, Is.EqualTo(_dto.UserId));
            Assert.That(result.Data.CreatedBy, Is.EqualTo(_dto.CreatedBy));
            Assert.That(result.Data.UpdatedBy, Is.EqualTo(_dto.UpdatedBy));
        }

        [Test]
        public void ToggleAvailability_NullEntity_Test()
        {
            _availabilityRepositoryMock.Setup(x => x.GetAvailabilityByUserId(It.IsAny<int>()))
                .Returns((Availability)null);

            IAvailabilityService service = new AvailabilityService(_availabilityRepositoryMock.Object);
            UpdateResponseDto<AvailabilityDto> result = service.ToggleAvailability(1, new NoDataRequestDto("SYSTEM"));
            Assert.That(result.Data.AvailabilityId, Is.EqualTo(_dto.AvailabilityId));
            Assert.That(result.Data.Available, Is.EqualTo(_dto.Available));
            Assert.That(result.Data.UserId, Is.EqualTo(_dto.UserId));
            Assert.That(result.Data.CreatedBy, Is.EqualTo(_dto.CreatedBy));
            Assert.That(result.Data.UpdatedBy, Is.EqualTo(_dto.UpdatedBy));
        }
    }
}
