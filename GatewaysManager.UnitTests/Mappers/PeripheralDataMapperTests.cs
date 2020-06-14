using GatewaysManager.Mappers;
using GatewaysManager.Models;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;
using NUnit.Framework;
using System;

namespace GatewaysManager.UnitTests.Mappers
{
    [TestFixture]
    public class PeripheralDataMapperTests
    {
        private const int uid = 30004444;
        private const string vendor = "Cisco";
        private const string dateCreated = "11/06/2020";
        private static Guid gatewayId = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");
        private static Guid id = new Guid("c664f8af-09b8-496c-83f5-800abe51067d");
        private const DeviceStatus status = DeviceStatus.Online;

        private PeripheralDataMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _mapper = new PeripheralDataMapper();
        }

        [Test]
        public void ReturnMappedObject()
        {
            Assert.NotNull(RunMapperMapToViewModel());
        }

        [Test]
        public void CheckIfMappedObjectIsOfExpectedType()
        {
            Assert.IsInstanceOf(typeof(PeripheralViewData), RunMapperMapToViewModel());
        }

        [Test]
        public void CheckForCorrectlyMappedValues()
        {
            var result = RunMapperMapToViewModel();

            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(uid, result.UID);
            Assert.AreEqual(vendor, result.Vendor);
            Assert.AreEqual(gatewayId, result.GatewayId);
            Assert.AreEqual(status, result.Status);
            Assert.AreEqual(dateCreated, result.DateCreated);
        }

        private PeripheralViewData RunMapperMapToViewModel()
        {
            return _mapper.MapToViewModel(
              new Peripheral()
              {
                  Id = id,
                  UID = uid,
                  Vendor = vendor,
                  GatewayId = gatewayId,
                  Status = status,
                  DateCreated = dateCreated
              });
        }
    }
}
