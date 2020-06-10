using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GatewaysManager.Models;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Services.Interfaces
{
    public interface IGatewayService
    {
        Task<EntityActionOutcome> CreateEntityAsync(GatewayInputData viewData);
        Task<Gateway> DeleteAsync(Guid id);
        Task<List<GatewayViewData>> GetAllEntitiesAsync();
        Task<GatewayViewData> GetEntityByIdAsync(Guid entityId);
        Task<EntityActionOutcome> UpdateEntityAsync(GatewayInputData viewData, Guid id);
    }
}