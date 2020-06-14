using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GatewaysManager.Models;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Services.Interfaces
{
    public interface IPeripheralService
    {
        Task<EntityActionOutcome> CreateEntityAsync(PeripheralInputData viewData);
        Task<PeripheralViewData> GetEntityByIdAsync(Guid entityId);
        Task<EntityActionOutcome> UpdateEntityAsync(PeripheralInputData viewData, Guid id);
        Task<List<PeripheralViewData>> GetAllEntitiesAsync();
        Task<Peripheral> DeleteAsync(Guid id);
    }
}