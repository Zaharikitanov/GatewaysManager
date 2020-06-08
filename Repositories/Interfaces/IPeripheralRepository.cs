using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GatewaysManager.Models.View;

namespace GatewaysManager.Repositories.Interfaces
{
    public interface IPeripheralRepository : IBaseRepository
    {
        Task<List<PeripheralViewData>> GetEntitiesListAsync();
        Task<PeripheralViewData> GetEntityDetailsAsync(Guid entityId);
    }
}