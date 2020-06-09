using AutoMapper;
using GatewaysManager.Mappers.Interfaces;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Mappers
{
    public class GatewayDataMapper : IGatewayDataMapper
    {
        public GatewayViewData MapToViewModel(Gateway entity)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Gateway, GatewayViewData>();
            });

            var mapper = configuration.CreateMapper();

            return mapper.Map<GatewayViewData>(entity);
        }

        public Gateway MapToDataModel(GatewayInputData entity)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GatewayInputData, Gateway>();
            });

            var mapper = configuration.CreateMapper();

            return mapper.Map<Gateway>(entity);
        }
    }
}
