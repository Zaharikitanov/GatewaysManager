using GatewaysManager.Controllers;
using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Models;
using GatewaysManager.Models.View;
using GatewaysManager.Services.Interfaces;
using Moq;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace GatewaysManager.UnitTests.Controllers.PeripheralControllerTests
{
    [TestFixture]
    public class CreateMethodTests
    {
        private PeripheralInputData inputData = new PeripheralInputData();
        private Mock<IPeripheralService> _service;
        private Mock<IStatusCodeResultFactory> _resultFactory;
        private PeripheralController _controller;

        [SetUp]
        public void SetUp()
        {
            _service = new Mock<IPeripheralService>();
            _resultFactory = new Mock<IStatusCodeResultFactory>();

            _controller = new PeripheralController(_service.Object, _resultFactory.Object);
        }


        [Test]
        public async Task UseTheCreateEntityAsyncToCreateNewEntity()
        {
            await _controller.Create(inputData);

            _service.Verify(s => s.CreateEntityAsync(inputData), Times.Once);
            _service.VerifyNoOtherCalls();
        }

        [Test]
        public async Task ReturnOkStatusCodeWhenEntityActionOutcomeIsSuccess()
            => await TestReturnsCorrectStatusCode(EntityActionOutcome.Success, HttpStatusCode.OK);

        [Test]
        public async Task ReturnConflictStatusCodeWhenEntityActionOutcomeIsCreateFailed()
            => await TestReturnsCorrectStatusCode(EntityActionOutcome.CreateFailed, HttpStatusCode.Conflict);

        [Test]
        public async Task ReturnUnprocessableEntityStatusCodeWhenEntityActionOutcomeIsMissingFullEntityData()
            => await TestReturnsCorrectStatusCode(EntityActionOutcome.MissingFullEntityData, HttpStatusCode.UnprocessableEntity);

        [Test]
        public async Task ReturnNotAcceptableStatusCodeWhenEntityActionOutcomeIsPeripheralsLimitReached()
            => await TestReturnsCorrectStatusCode(EntityActionOutcome.PeripheralsLimitReached, HttpStatusCode.NotAcceptable);

        [TestCase((EntityActionOutcome)19)]
        [TestCase((EntityActionOutcome)17)]
        [TestCase((EntityActionOutcome)18)]
        public async Task ReturnAnInternalServerErrorStatusCodeResultWhenOutcomeIsNotRecognized(EntityActionOutcome outcome)
            => await TestReturnsCorrectStatusCode(outcome, HttpStatusCode.InternalServerError);

        private async Task TestReturnsCorrectStatusCode(EntityActionOutcome outcome, HttpStatusCode statusCode)
        {
            _service.SetReturnsDefault(Task.FromResult(outcome));
            _resultFactory.Setup(x => x.Create(outcome)).Returns(statusCode);
            var response = await _controller.Create(inputData);

            Assert.AreEqual(statusCode, response);
        }
    }
}
