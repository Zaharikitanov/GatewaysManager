using AutoMapper;
using GatewaysManager.Mappers.Interfaces;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;

namespace GatewaysManager.Mappers
{
    public class PeripheralDataMapper : IPeripheralDataMapper
    {
        public PeripheralViewData MapToViewModel(Peripheral entity)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Peripheral, PeripheralViewData>();
            });

            var mapper = configuration.CreateMapper();

            return mapper.Map<PeripheralViewData>(entity);
        }

        public Peripheral MapToDataModel(PeripheralInputData entity)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PeripheralInputData, Peripheral>();
            });

            var mapper = configuration.CreateMapper();

            return mapper.Map<Peripheral>(entity);
        }
    }
}
