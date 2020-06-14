using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;
using GatewaysManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace GatewaysManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private IGatewayService _service;
        private IStatusCodeResultFactory _resultFactory;

        public GatewayController(IGatewayService service, IStatusCodeResultFactory factory)
        {
            _service = service;
            _resultFactory = factory;
        }

        [HttpPost]
        public async Task<HttpStatusCode> Create(GatewayInputData inputData)
        {
            var createEntityOutcome = await _service.CreateEntityAsync(inputData);

            return _resultFactory.Create(createEntityOutcome);
        }

        [HttpGet]
        public async Task<List<GatewayViewData>> GetAllEntities()
        {
            return await _service.GetAllEntitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<GatewayViewData> GetEntityById(Guid id)
        {
            return await _service.GetEntityByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Update(GatewayInputData inputData, Guid id)
        {
            var updateEntityOutcome = await _service.UpdateEntityAsync(inputData, id);

            return _resultFactory.Create(updateEntityOutcome);
        }

        [HttpDelete("{id}")]
        public async Task<Gateway> Delete(Guid id)
        {
            return await _service.DeleteAsync(id);
        }
    }
}