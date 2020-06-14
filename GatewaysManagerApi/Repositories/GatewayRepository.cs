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
    public class GatewayRepository : BaseRepository, IGatewayRepository
    {
        private IPeripheralDataMapper _mapper;

        public GatewayRepository(GatewaysManagerContext dbContext, IPeripheralDataMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<GatewayViewData>> GetEntitiesListAsync()
        {
            var entities = await _dbContext.Gateways
                .Select(g => new GatewayViewData
                {
                    Id = g.Id,
                    Name = g.Name,
                    IPv4 = g.IPv4,
                    SerialNumber = g.SerialNumber,
                    Peripherals = g.Peripherals.Where(p => p.GatewayId == g.Id).Select(p => _mapper.MapToViewModel(p)).ToList()

                }).ToListAsync();

            return entities;
        }

        public async Task<GatewayViewData> GetEntityDetailsAsync(Guid entityId)
        {
            var entity = await _dbContext.Gateways.Where(g => g.Id == entityId)
                .Select(g => new GatewayViewData
                {
                    Id = g.Id,
                    Name = g.Name,
                    IPv4 = g.IPv4,
                    SerialNumber = g.SerialNumber,
                    Peripherals = g.Peripherals.Where(p => p.GatewayId == g.Id).Select(p => _mapper.MapToViewModel(p)).ToList()

                }).SingleOrDefaultAsync();

            return entity;
        }
    }
}
