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
    public class GatewayController : ControllerBase
    {
        private IPeripheralService _service;
        private IStatusCodeResultFactory _resultFactory;

        public GatewayController(IPeripheralService service, IStatusCodeResultFactory factory)
        {
            _service = service;
            _resultFactory = factory;
        }

        [HttpPost]
        public async Task<HttpStatusCode> Create(PeripheralInputData inputData)
        {
            var createEntityOutcome = await _service.CreateEntityAsync(inputData);

            return _resultFactory.Create(createEntityOutcome);
        }

        [HttpGet]
        public async Task<List<PeripheralViewData>> GetAllEntities()
        {
            return await _service.GetAllEntitiesAsync();
        }

        [HttpGet("{id}")]
        public async Task<PeripheralViewData> GetEntityById(Guid id)
        {
            return await _service.GetEntityByIdAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Update(PeripheralInputData inputData, Guid id)
        {
            var updateEntityOutcome = await _service.UpdateEntityAsync(inputData, id);

            return _resultFactory.Create(updateEntityOutcome);
        }

        [HttpDelete("{id}")]
        public async Task<Peripheral> Delete(Guid id)
        {
            return await _service.DeleteAsync(id);
        }
    }
}