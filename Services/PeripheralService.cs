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
    public class PeripheralService : IPeripheralService
    {
        private IPeripheralRepository _repository;
        private IPeripheralFactory _factory;

        public PeripheralService(IPeripheralRepository repository, IPeripheralFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<EntityActionOutcome> CreateEntityAsync(PeripheralInputData viewData)
        {
            var newEntity = _factory.Create(viewData);
            var assignedChildrenAmount = await _repository.GetChildrenAssignedToParentAsync(viewData.GatewayId);
            var validator = new PeripheralDataInputValidator();
            var result = validator.Validate(viewData);

            if (result.IsValid == false)
                return EntityActionOutcome.MissingFullEntityData;

            if (viewData.GatewayId != null && assignedChildrenAmount > 10)
                return EntityActionOutcome.PeripheralsLimitReached;

            var upsertSuccessful = await _repository.AddAsync(newEntity);
            if (upsertSuccessful == null)
                return EntityActionOutcome.CreateFailed;

            return EntityActionOutcome.Success;
        }

        public async Task<EntityActionOutcome> UpdateEntityAsync(PeripheralInputData viewData, Guid id)
        {
            var assignedChildrenAmount = await _repository.GetChildrenAssignedToParentAsync(viewData.GatewayId);
            var validator = new PeripheralDataInputValidator();
            var result = validator.Validate(viewData);

            if (result.IsValid == false)
                return EntityActionOutcome.UpdateFailed;

            if (viewData.GatewayId != null && assignedChildrenAmount > 10)
                return EntityActionOutcome.PeripheralsLimitReached;

            var updateSuccessful = await _repository.UpdateAsync(
                await PopulateEntityDataWithViewData(viewData, id));

            if (updateSuccessful == null)
                return EntityActionOutcome.EntityNotFound;

            return EntityActionOutcome.Success;
        }

        public async Task<PeripheralViewData> GetEntityByIdAsync(Guid entityId)
        {
            return await _repository.GetEntityDetailsAsync(entityId);
        }

        public async Task<List<PeripheralViewData>> GetAllEntitiesAsync()
        {
            return await _repository.GetEntitiesListAsync();
        }

        public async Task<Peripheral> DeleteAsync(Guid id)
        {
            var getEntity = await _repository.GetByIdAsync<Peripheral>(id);
            return await _repository.DeleteAsync(getEntity);
        }

        private async Task<Peripheral> PopulateEntityDataWithViewData(PeripheralInputData viewData, Guid entityId)
        {
            var getCurrent = await _repository.GetByIdAsync<Peripheral>(entityId);

            getCurrent.UID = viewData?.UID ?? getCurrent.UID;
            getCurrent.GatewayId = viewData?.GatewayId ?? getCurrent.GatewayId;
            getCurrent.Vendor = viewData.Vendor ?? getCurrent.Vendor;
            getCurrent.Status = viewData?.Status ?? getCurrent.Status;

            return getCurrent;
        }
    }
}
