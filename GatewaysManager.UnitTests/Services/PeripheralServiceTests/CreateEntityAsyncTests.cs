using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Models;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;
using GatewaysManager.Repositories.Interfaces;
using GatewaysManager.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace GatewaysManager.UnitTests.Services.PeripheralServiceTests
{
    [TestFixture]
    public class CreateEntityAsyncTests
    {
        private Mock<IPeripheralRepository> _repository;
        private Mock<IPeripheralFactory> _factory;

        private PeripheralService _service;

        [SetUp]
        public void SetUp()
        {
            _repository = new Mock<IPeripheralRepository>();
            _factory = new Mock<IPeripheralFactory>();
            
            _service = new PeripheralService(
                _repository.Object,
                _factory.Object);
        }

        [Test]
        public async Task ReturnSuccessfulCreateEntityOutcome()
        {
            _repository.Setup(r => r.AddAsync(It.IsAny<Peripheral>())).ReturnsAsync(new Peripheral());

            Assert.AreEqual(EntityActionOutcome.Success, await _service.CreateEntityAsync(ValidInputData()));
        }

        [Test]
        public async Task ReturnCreateFailedEntityOutcome()
        {
            _repository.Setup(r => r.AddAsync(It.IsAny<Peripheral>())).ReturnsAsync(It.IsAny<Peripheral>());

            Assert.AreEqual(EntityActionOutcome.CreateFailed, await _service.CreateEntityAsync(ValidInputData()));
        }

        [TestCase(0)]
        [TestCase(null)]
        public async Task ReturnMissingFullEntityDataOutcomeWhenUIDPropertyValueIsInvalid(int uid)
        {
            var invalidEntityData = ValidInputData();
            invalidEntityData.UID = uid;
            Assert.AreEqual(EntityActionOutcome.MissingFullEntityData, await _service.CreateEntityAsync(invalidEntityData));
        }

        [TestCase((DeviceStatus)14)]
        [TestCase((DeviceStatus)16)]
        public async Task ReturnMissingFullEntityDataOutcomeWhenStatusPropertyValueIsInvalid(DeviceStatus status)
        {
            var invalidEntityData = ValidInputData();
            invalidEntityData.Status = status;
            Assert.AreEqual(EntityActionOutcome.MissingFullEntityData, await _service.CreateEntityAsync(invalidEntityData));
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("This is very long string which is more than a ninety characters long and that is very long indeed")]
        public async Task ReturnMissingFullEntityDataOutcomeWhenVendorPropertyValueIsInvalid(string vendor)
        {
            var invalidEntityData = ValidInputData();
            invalidEntityData.Vendor = vendor;
            Assert.AreEqual(EntityActionOutcome.MissingFullEntityData, await _service.CreateEntityAsync(invalidEntityData));
        }

        [Test]
        public async Task ReturnPeripheralsLimitReachedEntityOutcome()
        {
            _repository.Setup(r => r.GetChildrenAssignedToParentAsync(new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"))).ReturnsAsync(10);
            
            Assert.AreEqual(EntityActionOutcome.PeripheralsLimitReached, await _service.CreateEntityAsync(ValidInputData()));
        }

        private PeripheralInputData ValidInputData()
        {
            return new PeripheralInputData
            {
                UID = 30004444,
                Vendor = "Cisco",
                GatewayId = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"),
                Status = DeviceStatus.Online
            };
        }
    }
}
