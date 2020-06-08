using GatewaysManager.Factories.Interfaces;
using GatewaysManager.Mappers.Interfaces;
using GatewaysManager.Models.Database;
using GatewaysManager.Models.View;
using System;

namespace GatewaysManager.Factories
{
    public class PeripheralFactory : IPeripheralFactory
    {
        private IPeripheralDataMapper _mapper;

        public PeripheralFactory(IPeripheralDataMapper mapper)
        {
            _mapper = mapper;
        }

        public Peripheral Create(PeripheralInputData viewData)
        {
            Peripheral entity = _mapper.MapToDataModel(viewData);
            entity.DateCreated = DateTime.Now.ToString();

            return entity;
        }
    }
}
