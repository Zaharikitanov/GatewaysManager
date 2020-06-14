using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Models;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;
using GatewaysManager.Repositories.Interfaces;
using GatewaysManager.Services.Interfaces;
using GatewaysManager.Validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GatewaysManager.Services
{
    public class GatewayService : IGatewayService
    {
        private IGatewayRepository _repository;
        private IGatewayFactory _factory;

        public GatewayService(IGatewayRepository repository, IGatewayFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<EntityActionOutcome> CreateEntityAsync(GatewayInputData viewData)
        {
            var newEntity = _factory.Create(viewData);
            var validator = new GatewayDataInputValidator();
            var result = validator.Validate(viewData);

            if (result.IsValid == false)
                return EntityActionOutcome.MissingFullEntityData;
            
            var upsertSuccessful = await _repository.AddAsync(newEntity);
            if (upsertSuccessful == null)
                return EntityActionOutcome.CreateFailed;

            return EntityActionOutcome.Success;
        }

        public async Task<EntityActionOutcome> UpdateEntityAsync(GatewayInputData viewData, Guid id)
        {
            var validator = new GatewayDataInputValidator();
            var result = validator.Validate(viewData);

            if (result.IsValid == false)
                return EntityActionOutcome.UpdateFailed;
            
            var updateSuccessful = await _repository.UpdateAsync(
                await PopulateEntityDataWithViewData(viewData, id));

            if (updateSuccessful == null)
                return EntityActionOutcome.EntityNotFound;

            return EntityActionOutcome.Success;
        }

        public async Task<GatewayViewData> GetEntityByIdAsync(Guid entityId)
        {
            return await _repository.GetEntityDetailsAsync(entityId);
        }

        public async Task<List<GatewayViewData>> GetAllEntitiesAsync()
        {
            return await _repository.GetEntitiesListAsync();
        }

        public async Task<Gateway> DeleteAsync(Guid id)
        {
            var getEntity = await _repository.GetByIdAsync<Gateway>(id);
            return await _repository.DeleteAsync(getEntity);
        }

        private async Task<Gateway> PopulateEntityDataWithViewData(GatewayInputData viewData, Guid entityId)
        {
            var getCurrent = await _repository.GetByIdAsync<Gateway>(entityId);

            getCurrent.IPv4 = viewData?.IPv4 ?? getCurrent.IPv4;
            getCurrent.Name = viewData.Name ?? getCurrent.Name;
            getCurrent.SerialNumber = viewData.SerialNumber ?? getCurrent.SerialNumber;

            return getCurrent;
        }
    }
}
