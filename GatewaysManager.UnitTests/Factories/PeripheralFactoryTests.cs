using GatewaysManager.Factories;
using GatewaysManager.Models;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;
using NUnit.Framework;
using System;

namespace GatewaysManager.UnitTests.Factories
{
    [TestFixture]
    public class PeripheralFactoryTests
    {
        private const int uid = 90008000;
        private const string vendor = "Cisco";
        private static Guid gatewayId = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00");
        private const DeviceStatus status = DeviceStatus.Online;
        
        private PeripheralFactory _factory;

        [SetUp]
        public void SetUp()
        {
            _factory = new PeripheralFactory();
        }

        [Test]
        public void ReturnFactoryCreate()
        {
            Assert.NotNull(RunFactoryCreate());
        }

        [Test]
        public void CheckIfCreatedObjectIsOfExpectedType()
        {
            Assert.IsInstanceOf(typeof(Peripheral), RunFactoryCreate());
        }

        [Test]
        public void CheckForCorrectlyBuiltValues()
        {
            var result = RunFactoryCreate();

            Assert.AreEqual(uid, result.UID);
            Assert.AreEqual(vendor, result.Vendor);
            Assert.AreEqual(gatewayId, result.GatewayId);
            Assert.AreEqual(status, result.Status);
        }

        private Peripheral RunFactoryCreate()
        {
            return _factory.Create(new PeripheralInputData {
                UID = uid,
                Vendor = vendor,
                GatewayId = gatewayId,
                Status = status,
            });
        }
    }
}
