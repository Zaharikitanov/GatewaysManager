using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GatewaysManager.Models.View;

namespace GatewaysManager.Repositories.Interfaces
{
    public interface IGatewayRepository
    {
        Task<List<GatewayViewData>> GetEntitiesListAsync();
        Task<GatewayViewData> GetEntityDetailsAsync(Guid entityId);
    }
}