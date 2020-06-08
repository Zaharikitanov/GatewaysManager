using FluentValidation.Results;
using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.Outcomes;
using GatewaysManager.Models.View;
using GatewaysManager.Repositories.Interfaces;
using GatewaysManager.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewaysManager.Services
{
    public class PeripheralService
    {
        private IPeripheralRepository _repository;
        private IPeripheralFactory _factory;

        public PeripheralService(IPeripheralRepository repository, IPeripheralFactory factory)
        {
            _repository = repository;
            _factory = factory;
        }

        public async Task<CreateEntityOutcome> CreateEntityAsync(PeripheralInputData viewData)
        {
            var newEntity = _factory.Create(viewData);

            PeripheralDataInputValidator validator = new PeripheralDataInputValidator();

            ValidationResult result = validator.Validate(viewData);

            if (result.IsValid == false)
            {
                return CreateEntityOutcome.MissingFullEntityData;
            }

            var upsertSuccessful = await _repository.AddAsync(newEntity);
            if (upsertSuccessful == null)
            {
                return CreateEntityOutcome.CreateFailed;
            }

            return CreateEntityOutcome.Success;
        }

        public async Task<UpdateEntityOutcome> UpdateEntityAsync(PeripheralInputData viewData, Guid id)
        {
            var getCurrent = await _repository.GetByIdAsync<Peripheral>(id);

            getCurrent.UID = viewData.UID ?? getCurrent.UID;
            getCurrent.URL = viewData.URL ?? getCurrent.URL;
            getCurrent.Category = viewData.Category != getCurrent.Category ? viewData.Category : getCurrent.Category;
            getCurrent.HomepageSnapshot = viewData.HomepageSnapshot ?? getCurrent.HomepageSnapshot;
            getCurrent.Email = viewData.LoginDetails.Email ?? getCurrent.Email;
            getCurrent.Password = viewData.LoginDetails.Password ?? getCurrent.Password;

            PeripheralDataInputValidator validator = new PeripheralDataInputValidator();

            ValidationResult result = validator.Validate(viewData);

            if (result.IsValid == false)
            {
                return UpdateEntityOutcome.UpdateFailed;
            }

            var updateSuccessful = _repository.Update(getCurrent);
            if (updateSuccessful == null)
            {
                return UpdateEntityOutcome.EntityNotFound;
            }

            return UpdateEntityOutcome.Success;
        }

        public async Task<PeripheralViewData> GetEntityByIdAsync(Guid entityId)
        {
            return await _repository.GetEntityDetailsAsync(entityId);
        }
        
    }
}
