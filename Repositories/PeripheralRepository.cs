using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GatewaysManager.DatabaseContext;
using GatewaysManager.Mappers.Interfaces;
using GatewaysManager.Models.View;
using GatewaysManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GatewaysManager.Repositories
{
    public class PeripheralRepository : BaseRepository, IPeripheralRepository
    {
        private IPeripheralDataMapper _mapper;

        public PeripheralRepository(GatewaysManagerContext dbContext, IPeripheralDataMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<PeripheralViewData>> GetEntitiesListAsync()
        {
            var entities = await _dbContext.Peripherals
                .Select(f => _mapper.MapToViewModel(f)).ToListAsync();

            return entities;
        }

        public async Task<PeripheralViewData> GetEntityDetailsAsync(Guid entityId)
        {
            var entity = await _dbContext.Peripherals.Where(f => f.Id == entityId)
                .Select(f => _mapper.MapToViewModel(f)).SingleOrDefaultAsync();

            return entity;
        }
    }
}
